using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TravelCompanionApp;
using TravelCompanionApp.controllers;
using TravelCompanionApp.mapper;
using TravelCompanionApp.repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(AppMappingProfile));
builder.Services.AddScoped<PostMapper>();
builder.Services.AddScoped<PostResponseMapper>();
builder.Services.AddScoped<ReviewMapper>();
builder.Services.AddScoped<UserMapper>();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserController>();
builder.Services.AddScoped<PostRepository>();
builder.Services.AddScoped<PostController>();
builder.Services.AddScoped<PostResponseRepository>();
builder.Services.AddScoped<PostResponseController>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();   
app.MapControllers();

app.Run();
