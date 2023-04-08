using Microsoft.EntityFrameworkCore;
using MyCmsWebApi2.DataLayer.Context;
using MyCmsWebApi2.DataLayer.Repository;
using MyCmsWebApi2.DataLayer.Services;
using Serilog;
using System.Configuration;




Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/CmsInfo.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ICommentRepository,CommentService>();
builder.Services.AddScoped<IImageRepository, ImageService>();
builder.Services.AddScoped<INewsRepository,NewsService>();
builder.Services.AddScoped<INewsGroupRepository, NewsGroupService>();



var configurationBuilder = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

var configuration = configurationBuilder.Build();
var connectionString = configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<CmsDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddSerilog(dispose: true);
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


