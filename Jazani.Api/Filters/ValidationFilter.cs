using Jazani.Api.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Jazani.Api.Filters
{
    public class ValidationFilter : IAsyncActionFilter  
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Verifica si el modelo no es válido
            if (!context.ModelState.IsValid)
            {
                // Recopila los errores de validación en un diccionario
                var errorsModelState = context.ModelState
                    .Where(x => x.Value?.Errors.Count > 0)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value?.Errors.Select(x => x.ErrorMessage))
                    .ToList();

                // Crea una respuesta de error
                ErrorResponse errorResponse = new ErrorResponse();
                errorResponse.Message = "Ingrese todos los campos requeridos";
                errorResponse.Errors = new List<ErrorValidationModel>();

                // Itera a través de los errores de validación recopilados
                errorsModelState.ForEach(error =>
                {
                    foreach (var message in error.Value)
                    {
                        // Agrega detalles de errores de validación a la respuesta de error
                        errorResponse.Errors.Add(new()
                        {
                            FieldName = error.Key,
                            Message = message
                        });
                    }
                });

                // Configura el resultado de la acción como una respuesta de error BadRequest
                context.Result = new BadRequestObjectResult(errorResponse);
                return;
            }


            await next();
        }
    }
}