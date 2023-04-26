using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using MyCmsWebApi2.Applications.Commands.Comments;
using MyCmsWebApi2.Applications.Repository;
using MyCmsWebApi2.Infrastructure.Extensions;
using MyCmsWebApi2.Infrastructure.Middlewares;
using MyCmsWebApi2.Persistences.EF;
using MyCmsWebApi2.Persistences.QueryFacade;
using MyCmsWebApi2.Persistences.Repositories;
using MyCmsWebApi2.Presentations.Dtos.CommentsDto.User;
using MyCmsWebApi2.Presentations.QueryFacade;
using MyCmsWebApi2.Presentations.Validator;
using Serilog;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File($"C://Users/User/OneDrive/Documents/Cms logs/Cms log {DateTime.Now:yyyy-MM-dd-}.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();


var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMemoryCache();

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

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<CommentValidator>();

var configurationBuilder = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

var configuration = configurationBuilder.Build();
var connectionString = configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<CmsDbContext>(options => options.UseSqlServer(connectionString));
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
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();
//using (IServiceScope scope = app.Services.CreateAsyncScope())
//{
//    var content = scope.ServiceProvider.GetService<CmsDbContext>();
//    await content.Database.MigrateAsync();
//}

app.Run();

