
using Jazani.Application.Admins.Dtos.Modules.Mappers;
using Jazani.Application.Admins.Dtos.Liabilities.Mappers;
using Jazani.Application.Cores.Contexts;
using Jazani.Domain.Admins.Models;
using Jazani.Infrastructure.Cores.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about config  uring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Infrastructure
builder.Services.addInfrastructureServices(builder.Configuration);


// Applications
builder.Services.AddApplicationServices();


//builder.Services.AddAutoMapper(typeof(ModuleMapper));
//builder.Services.AddAutoMapper(typeof(LiabilitieMapper));


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

