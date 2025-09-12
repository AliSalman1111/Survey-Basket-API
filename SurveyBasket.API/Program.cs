using AutoMapper;
using FluentValidation; // Ensure AutoMapper namespace is included
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using SurveyBasket.API.DTOs.Requist;
using SurveyBasket.API.DTOs.Validation;
using SurveyBasket.API.Servece;
using SurveyBasket.API.Servece.IServece;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var conectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SurveyBasket.API.DBContext.ApplicationDBContext>(options =>
{
    options.UseSqlServer(conectionString);
});



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IServecePoll, Servecepoll>();
builder.Services.AddFluentValidationAutoValidation();
// Fix for CS1503: Provide a valid configuration action for AutoMapper
builder.Services.AddAutoMapper(cfg => cfg.AddMaps(typeof(Program).Assembly));

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());    


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

 app.Run();
