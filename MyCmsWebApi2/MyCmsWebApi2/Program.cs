using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyCmsWebApi2.Applications.Repository;
using MyCmsWebApi2.Domain.Entities;
using MyCmsWebApi2.Infrastructure.Extensions;
using MyCmsWebApi2.Infrastructure.Middlewares;
using MyCmsWebApi2.Persistences.EF;
using MyCmsWebApi2.Persistences.QueryFacade;
using MyCmsWebApi2.Persistences.Repositories;
using MyCmsWebApi2.Presentations.QueryFacade;
using MyCmsWebApi2.Presentations.Validator.Image;
using Serilog;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using MyCmsWebApi2.Infrastructure.HostedServices;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File($"C://Users/User/OneDrive/Documents/Cms logs/Cms log {DateTime.Now:yyyy-MM-dd-}.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();


var builder = WebApplication.CreateBuilder(args);

var configurationBuilder = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
var configuration = configurationBuilder.Build();
var connectionString = configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CmsDbContext>(options => options.UseSqlServer(connectionString));

builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyCmsWebApi", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
        {
        new OpenApiSecurityScheme
        {
        Reference = new OpenApiReference
        {
        Type = ReferenceType.SecurityScheme,
        Id = "Bearer"
        }
        },
        new string[] {}
        }
        });
        });
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMemoryCache();
builder.Services.AddScoped<JwtTokenGenerator>();
builder.Services.AddScoped<TokenValidationParameters> ();


#region Repository
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<INewsRepository, NewsRepository>();
builder.Services.AddScoped<INewsGroupRepository, NewsGroupRepository>();
#endregion

#region QueryFacade
builder.Services.AddScoped<ICommentQueryFacade, CommentQueryFacade>();
builder.Services.AddScoped<INewsGroupQueryFacade, NewsGroupQueryFacade>();
builder.Services.AddScoped<INewsQueryFacade, NewsQueryFacade>();
builder.Services.AddScoped<ModelValidationFilter>();
builder.Services.AddMemoryCache();


#endregion

#region Authentication
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection(key: "Jwt:Secret")); 

var key = Encoding.ASCII.GetBytes(builder.Configuration[key: "Jwt:Key"]);

var tokenValidationParameter = new TokenValidationParameters
{
    ValidateIssuer = false,
    ValidateAudience = true,
    ValidateLifetime = true,
    RequireExpirationTime = true,
    ValidateIssuerSigningKey = false,
    ValidIssuer = builder.Configuration["Jwt:Issuer"],
    ValidAudience = "FaghatKhooba",
    IssuerSigningKey = new SymmetricSecurityKey(key),
};

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.TokenValidationParameters = tokenValidationParameter;
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 8;
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
    options.SignIn.RequireConfirmedEmail = true;
})
    .AddEntityFrameworkStores<CmsDbContext>()
    .AddDefaultTokenProviders()
    .AddRoles<IdentityRole<Guid>>()
    .AddUserManager<UserManager<ApplicationUser>>()
    .AddSignInManager<SignInManager<ApplicationUser>>();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Set the username field to the phone number field
    options.User.RequireUniqueEmail = true;
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ ";
    options.User.RequireUniqueEmail = true;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // Set the username field to the phone number field
});
builder.Services.AddTransient<IHostedService, RoleSeederHostedService>();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
        policy.RequireClaim("role", "admin"));
});

#endregion


#region FluentValidation

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
//builder.Services.AddScoped<IValidator<AdminAddImageDto>, AdminAddImageValidator>();
builder.Services.AddControllers()
    .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<AdminAddImageValidator>());

#endregion


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddSerilog(dispose: true);
});



var app = builder.Build();
//builder.Host.UseSerilog();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSerilogRequestLogging();

app.UseHttpsRedirection();
app.UseMiddleware<ApiExceptionHandlingMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();
//using (IServiceScope scope = app.Services.CreateAsyncScope())
//{
//    var content = scope.ServiceProvider.GetService<CmsDbContext>();
//    await content.Database.MigrateAsync();
//}

app.Run();

