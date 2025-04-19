using Microsoft.EntityFrameworkCore;
using RedONEEmployee.Data;
using Serilog;
using Serilog.Templates;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//Add Serillog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug() // Set minimum log level
    .WriteTo.Console(new ExpressionTemplate(
        "[{@t:HH:mm:ss} {@l:u3}] {@m}\n{@x}")) // Console output with custom format
    .WriteTo.File(
        path: "logs/log-.txt", // Log file path with date suffix
        rollingInterval: RollingInterval.Day, // Roll files daily
        retainedFileCountLimit: 7, // Keep logs for 7 days
        rollOnFileSizeLimit: true, // Roll if file size exceeds limit
        fileSizeLimitBytes: 10_000_000) // 10 MB file size limit
    .CreateLogger();

builder.Services.AddSerilog();
// Add services to the container.

builder.Host.UseSerilog();

// Add MVC services to the dependency injection container
builder.Services.AddControllersWithViews();

// Cycle Error Fix
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler =
        ReferenceHandler.IgnoreCycles;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//// Method 1: Set Connection Strings
//builder.Services.AddDbContext<MyDBContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// Method 2:
builder.Services.AddDbContext<MyDBContext>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// This code is for MapControllers of APIController Only
app.MapControllers();

// This code is for MapControllers of MVCController Only
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=EmployeeMVC}/{action=Index}/{id?}"
);

app.Run();
