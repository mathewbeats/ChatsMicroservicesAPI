using ChatMicroserviceAPI.Api;
using ChatMicroserviceAPI.Data;
using ChatMicroserviceAPI.Hubs;
using ChatMicroserviceAPI.IRepository;
using ChatMicroserviceAPI.IRepository.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddSignalR(); // Añadir SignalR

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

ApiExtensions.MapEndPoints(app);

app.MapHub<ChatHub>("/chathub");

app.Run();