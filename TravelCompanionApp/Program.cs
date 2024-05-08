using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TravelCompanionApp;
using TravelCompanionApp.controllers;
using TravelCompanionApp.dto;
using TravelCompanionApp.exception;
using TravelCompanionApp.mailsenders;
using TravelCompanionApp.mapper;
using TravelCompanionApp.repository;
using TravelCompanionApp.validators;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ExceptionFilter());
    options.Filters.Add(new ValidationExceptionFilter());
});
builder.Services.AddScoped<MailSender>();
builder.Services.AddAutoMapper(typeof(AppMappingProfile));
builder.Services.AddScoped<PostMapper>();
builder.Services.AddScoped<PostResponseMapper>();
builder.Services.AddScoped<ReviewMapper>();
builder.Services.AddScoped<UserMapper>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//validators
builder.Services.AddScoped<PostDTOValidator>();

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserController>();
builder.Services.AddScoped<PostRepository>();
builder.Services.AddScoped<PostController>();
builder.Services.AddScoped<PostResponseRepository>();
builder.Services.AddScoped<PostResponseController>();
builder.Services.AddScoped<ReviewRepository>();
builder.Services.AddScoped<ReviewController>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin(); 
            builder.AllowAnyMethod();
            builder.AllowAnyHeader();
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
app.UseRouting();   
app.MapControllers();
app.UseCors("AllowAllOrigins");
app.Run();
