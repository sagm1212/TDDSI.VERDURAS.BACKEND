using Newtonsoft.Json;
using System.Net;
using TDDSI.VERDURAS.BACKEND.Api.Errors;
using TDDSI.VERDURAS.BACKEND.Application.Exceptions;

namespace TDDSI.VERDURAS.BACKEND.Api.Middlewares;
public class ExceptionMiddleware(
    RequestDelegate _next,
    ILogger<ExceptionMiddleware> _logger,
    IHostEnvironment _environment
    ) {

    public async Task InvokeAsync( HttpContext context ) {
        try {
            await _next( context );
        }
        catch (Exception ex) {
            _logger.LogError( "{@ex} {@message}", ex, ex.Message );
            context.Response.ContentType = "application/json";
            int statusCode;
            var result = string.Empty;

            switch (ex) {
                case NotFoundApplicationException _:
                    statusCode = (int)HttpStatusCode.NotFound;
                    break;

                case ValidationApplicationException validationException:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject(
                        new ExceptionCodeError(
                            statusCode,
                            ex.Message,
                            validationException.Errors
                        )
                    );
                    break;

                case BadRequestApplicationException _:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    break;

                case ErrorInternalApplicationException _:
                    statusCode = (int)HttpStatusCode.InternalServerError;
                    break;

                default: {
                        statusCode = (int)HttpStatusCode.InternalServerError;
                        result = JsonConvert.SerializeObject(
                            new ExceptionCodeError(
                                statusCode,
                                ex.Message,
                                new ErrorInternalApplicationException( ex.StackTrace )
                            )
                        );
                        break;
                    }
            }

            if (string.IsNullOrEmpty( result )) {
                if (_environment.IsDevelopment()) {
                    result = JsonConvert.SerializeObject(
                        new ExceptionCodeError(
                            statusCode,
                            ex.Message,
                            ex.StackTrace ) );
                }
                else {
                    result = JsonConvert.SerializeObject(
                        new ExceptionCodeError(
                            statusCode,
                            ex.Message ) );
                }
            }

            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsync( result );
        }
    }
}