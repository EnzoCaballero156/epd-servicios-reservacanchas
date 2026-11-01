using ReservaCanchas.Dtos;

using ReservaCanchas.Excepciones;

public class ManejoErrores(RequestDelegate siguiente, ILogger<ManejoErrores> logger)
{
    public async Task InvokeAsync(HttpContext contexto) 
    {
        try
        {
            await siguiente(contexto);
        }
        catch (Exception ex)
        {
            await ResponderErrorAsync(contexto, ex);
        }
    }

    private async Task ResponderErrorAsync(HttpContext contexto, Exception ex)
    {
        int status; 
        string mensaje;

        if (ex is ArgumentException)
        {
            status = 400;
            mensaje = ex.Message;
        }
        else if(ex is RecursoNoEncontradoException)
        {
            status = 404;
            mensaje = ex.Message;
        } 
        else if(ex is ConflictoException)
        {
            status = 409;
            mensaje = ex.Message;
        }
        else
        {
            status = 500;
            mensaje = "Error inesperado. Intentelo nuevamente.";

            logger.LogError(ex, "Error no controlado");
        } 

        ErrorRespuesta respuesta = new(status, mensaje);
        contexto.Response.StatusCode = status;
        await contexto.Response.WriteAsJsonAsync(respuesta);
    }
}