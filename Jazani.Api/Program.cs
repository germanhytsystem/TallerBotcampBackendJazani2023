using _Jazani.Core.Securities.Services;
using _Jazani.Core.Securities.Services.Implementations;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Jazani.Api.Filters;
using Jazani.Api.Middlewares;
using Jazani.Application.Cores.Contexts;
using Jazani.Infrastructure.Cores.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using System.Text;


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

//FILTERS
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ValidationFilter());

    AuthorizationPolicy authorizationPolicy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();

    options.Filters.Add(new AuthorizeFilter());
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

//PASSWORDHASHER
builder.Services.Configure<PasswordHasherOptions>(options=>
{
    options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV3;
});
//ISECURITYSERVICE
builder.Services.AddTransient<ISecurityService,SecurityService>();

//JWT
string jwtSecretKey = builder.Configuration.GetSection("Security:JwtSecrectKey").Get<string>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    byte[] key = Encoding.ASCII.GetBytes(jwtSecretKey);
    options.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateLifetime = true,
        ValidIssuer = "",
        ValidAudience = "",
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true
    };
});


// AUTHORIZEOPERATIONFILTER
builder.Services.AddSwaggerGen(options =>
{
    options.OperationFilter<AuthorizeOperationFilter>();

    string schemeName = "Bearer";
    options.AddSecurityDefinition(schemeName, new OpenApiSecurityScheme()
    {
        Name = schemeName,
        BearerFormat = "JWT",
        Scheme = "bearer",
        Description = "Add token.",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http
    });

});



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

