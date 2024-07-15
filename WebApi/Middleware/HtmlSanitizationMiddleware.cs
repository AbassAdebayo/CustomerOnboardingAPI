using Ganss.Xss;
using Microsoft.Extensions.Primitives;

namespace WebApi.Middleware
{
    public class HtmlSanitizationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHtmlSanitizer _htmlSanitizer;

        public HtmlSanitizationMiddleware(RequestDelegate next, IHtmlSanitizer htmlSanitizer)
        {
            _next = next;
            _htmlSanitizer = htmlSanitizer;
        }

        // Sanitize request data, such as form inputs, query parameters, and route values
        public async Task Invoke(HttpContext context)
        {
            if (context.Request.HasFormContentType)
            {
                var form = context.Request.Form;

                var sanitizedForm = new FormCollection(
                    form.ToDictionary(
                        kvp => kvp.Key,
                        kvp => new StringValues(
                            kvp.Value.Select(value => _htmlSanitizer.Sanitize(value).ToString()).ToArray()
                        )
                    )
                );

                context.Request.Form = sanitizedForm;
            }

            await _next(context);
        }
    }
}
