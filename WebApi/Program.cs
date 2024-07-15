using Serilog;
using Infrastructure.IOC.Extensions;
using Microsoft.AspNetCore.Identity;
using Ganss.Xss;
using WebApi.Filters;
using Microsoft.OpenApi.Models;
using WebApi.Middleware;
using WebApi.ActionResults;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();



builder.Services.AddLogging()
    .AddCors();


// Add Database
builder.Services.AddDatabase(builder.Configuration.GetConnectionString("ApplicationContext"));


builder.Services.AddSingleton<IHtmlSanitizer>(_ =>
{
    var sanitizer = new HtmlSanitizer();

    return sanitizer;
});

builder.Services.AddInfrastructure(builder.Configuration)
    .AddCors();
builder.Services.Configure<DataProtectionTokenProviderOptions>(o =>
                o.TokenLifespan = TimeSpan.FromHours(3));
builder.Services.AddMvc(options =>
{
    options.Filters.Add<RequestLoggingFilter>();
    options.Filters.Add<HttpGlobalExceptionFilter>();

})
.ConfigureApiBehaviorOptions(options =>
{
    options.InvalidModelStateResponseFactory = context => new ValidationFailedResult(context.ModelState);
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "CUSTOMER-ONBOARDING API",
        Version = "v1",
        Description = "CUSTOMER-ONBOARDING API"
    });
    c.OperationFilter<SwaggerHeaderFilter>();
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
    c.CustomSchemaIds(x => x.FullName);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
     {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CUSTOMER-ONBOARDING v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseMiddleware<HtmlSanitizationMiddleware>();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.MapControllers();

app.Run();
