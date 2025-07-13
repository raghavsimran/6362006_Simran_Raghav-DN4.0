using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class CustomExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        // 🔍 Log the exception
        File.AppendAllText("Logs/exceptions.txt",
            $"[{DateTime.Now}] {context.Exception.Message}\n");

        // ✅ Return the actual exception message in JSON format
        context.Result = new ObjectResult(new
        {
            message = context.Exception.Message
        })
        {
            StatusCode = 500
        };

        context.ExceptionHandled = true;
    }
}
