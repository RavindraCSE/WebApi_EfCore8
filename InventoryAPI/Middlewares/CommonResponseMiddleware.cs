using Models.Common;
using System.Text.Json;

namespace InventoryAPI.Middlewares
{
    public class CommonResponseMiddleware
    {
        private readonly RequestDelegate _next;
        public CommonResponseMiddleware(RequestDelegate next)
        {
            _next= next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            // do your custom logic
            var orignalOutput = context.Response.Body;
            using (var memorystream = new MemoryStream())
            {
                context.Response.Body= memorystream;
                try
                {
                    await _next(context);

                    if(context.Response.ContentType!=null 
                        && context.Response.ContentType.Contains("application/json"))
                    {
                        memorystream.Seek(0, SeekOrigin.Begin); // start reading memory stream
                        var responseBody = await new StreamReader(memorystream).ReadToEndAsync();
                        var responseObject = new ApiResponseModel<object>
                            (
                            success: context.Response.StatusCode >= 200 &&
                                        context.Response.StatusCode <= 300,
                            data: JsonSerializer.Deserialize<object>(responseBody)!,
                            message: "Request completed successfully!!!"
                            );

                        var jsonResponse = JsonSerializer.Serialize(responseObject);
                        context.Response.Body = orignalOutput;
                        await context.Response.WriteAsync(jsonResponse);


                    }
                }
                catch (Exception ex)
                {
                    throw;
                }

            }

        }
    }
}
