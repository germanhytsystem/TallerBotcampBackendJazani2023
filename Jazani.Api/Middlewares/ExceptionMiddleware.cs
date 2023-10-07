using Jazani.Application.Cores.Exceptions;
using System.Net;
using Jazani.Api.Exceptions;
using System.Net.Mail;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Jazani.Api.Middlewares
{

    //MIDDLEWARE PARA INTERCEPTAR NUESTRAS EXCEPCIONES
    public class ExceptionMiddleware : IMiddleware
    {
        //Creamos nuestro Logger
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            //throw new NotImplementedException();

            try{
                await next(context);

            }catch (Exception exception) {
                var errorResult = new ErrorModel();
                HttpStatusCode statusCode;

                switch (exception)
                {
                    case NotFoundCoreException e:
                        _logger.LogWarning("NotFounCoreException:: {exception}", exception.Message);
                        statusCode = HttpStatusCode.NotFound;
                        errorResult.Message = e.Message;
                        break;
                    default:
                        _logger.LogError("Exception:: {expcetion}",exception.Message);
                        statusCode = HttpStatusCode.InternalServerError;
                        errorResult.Message = "Se ha producido un error inesperado";
                        break;
                }


                var response = context.Response;

                if (!response.HasStarted)
                {
                    response.ContentType="application/json";
                    response.StatusCode = (int)statusCode;
                    await response.WriteAsync(JsonConvert.SerializeObject(errorResult));
                }

            }
        }
    }
}
