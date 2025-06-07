using backend.Services;
using backend.Services.Implementations;
using backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyHomeworkDbContext>(options => {
    var connectionString = builder.Configuration.GetConnectionString("MyHomeworkDb");

    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<IHomeworkService, HomeworkService>();
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<IGradeService, GradeService>();
builder.Services.AddScoped(typeof(ICRUDBaseService<>), typeof(CRUDBaseService<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
{
    options.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
