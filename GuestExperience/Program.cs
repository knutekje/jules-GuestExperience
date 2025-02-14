using GuestExperience.Data;
using GuestExperience.Exception;
using GuestExperience.Repositories;
using GuestExperience.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    //.WriteTo.Console()
    .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddDbContext<GuestExperienceDbContext>(options =>
    options.UseSqlite("Data Source=guestexperience.db"));

builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IGuestRepository, GuestRepository>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IGuestService, GuestService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<GuestExperienceDbContext>();
    context.Database.Migrate();
    context.Database.EnsureCreated();
}
app.UseSwagger();
app.UseSwaggerUI();
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

        if (exception is ControllerException)
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("A controller error occurred.");
        }
        else if (exception is ServiceException)
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("A service error occurred.");
        }
        else if (exception is RepositoryException)
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("A repository error occurred.");
        }
    });
});


app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();