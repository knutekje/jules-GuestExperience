using GuestExperience.Data;
using GuestExperience.Repositories;
using GuestExperience.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<GuestExperienceDbContext>(options =>
    options.UseSqlite("Data Source=guestexperience.db"));

builder.Services.AddScoped<IRoomRepository, RoomRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRoomService, RoomService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<GuestExperienceDbContext>();
    // Uncomment the next line if you're using migrations:
    context.Database.Migrate();
    context.Database.EnsureCreated();
}
app.UseSwagger();
app.UseSwaggerUI();


app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();