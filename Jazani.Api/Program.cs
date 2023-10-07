using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Jazani.Api.Filters;
using Jazani.Api.Middlewares;
using Jazani.Application.Cores.Contexts;
using Jazani.Infrastructure.Cores.Contexts;
using Serilog;
using Serilog.Events;


// Add services to the container.

// BUILDER PARA CONFIGURAR Y CONSTRUIR LA APP WEB
var builder = WebApplication.CreateBuilder(args);

//LOGGER
var logger = new LoggerConfiguration()
    .WriteTo.Console(LogEventLevel.Information)
    .WriteTo.File(
        ".."+ Path.DirectorySeparatorChar+"logapi.log",
        LogEventLevel.Warning,
        rollingInterval:RollingInterval.Day
        //LogEventLevel.Information
    )
    .CreateLogger();
builder.Logging.AddSerilog(logger);

//VALIDACIONES
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ValidationFilter());
});

builder.Services
    .AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();

builder.Services.AddControllers();

//ROUTES OPTIONS
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;  //Url en minúscula
    options.LowercaseQueryStrings= true;

});


// Learn more about config  uring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// INFRAESTRUCTURE
builder.Services.addInfrastructureServices(builder.Configuration);

// APPLICACIONS
builder.Services.AddApplicationServices();

//AUTOFAC
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(options =>
    {
        options.RegisterModule(new InfraestructureAutofacModule());
        options.RegisterModule(new ApplicationAutofacModule());
    });

// API
builder.Services.AddTransient<ExceptionMiddleware>();

//builder.Services.AddAutoMapper(typeof(ModuleMapper));
//builder.Services.AddAutoMapper(typeof(LiabilitieMapper));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// MIDDLEWARE
app.UseMiddleware<ExceptionMiddleware>();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

