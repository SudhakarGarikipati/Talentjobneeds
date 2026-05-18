using JobsModule.API;
using JobsModule.Infrastructure;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ------------------------------------------------------------
// 1. Controllers
// ------------------------------------------------------------
builder.Services.AddControllers();

// ------------------------------------------------------------
// 2. API Versioning
// ------------------------------------------------------------
builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    options.ReportApiVersions = true;
});

// ------------------------------------------------------------
// 3. Versioned API Explorer (REQUIRED for Swagger UI)
// ------------------------------------------------------------
builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";   // v1, v2, v3
    options.SubstituteApiVersionInUrl = true;
});

// ------------------------------------------------------------
// 4. Swagger (Swashbuckle)
// ------------------------------------------------------------
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>(); // versioned docs

// ------------------------------------------------------------
// 5. Memory Cache
// ------------------------------------------------------------
builder.Services.AddMemoryCache(options =>
{
    options.SizeLimit = 4094;
});

// ------------------------------------------------------------
// 6. Register Module Services
// ------------------------------------------------------------
JobServiceRegistration.RegisteredServices(builder.Services, builder.Configuration);

// ------------------------------------------------------------
// 7. JWT Authentication
// ------------------------------------------------------------
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// ------------------------------------------------------------
// 8. Middleware Pipeline
// ------------------------------------------------------------
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

// ------------------------------------------------------------
// 9. Swagger UI with Version Dropdown
// ------------------------------------------------------------
var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

app.UseSwagger(); // generates JSON

app.UseSwaggerUI(options =>
{
    foreach (var desc in provider.ApiVersionDescriptions)
    {
        options.SwaggerEndpoint(
            $"/swagger/{desc.GroupName}/swagger.json",
            desc.GroupName.ToUpperInvariant()
        );
    }
});

// ------------------------------------------------------------
// 10. Map Controllers
// ------------------------------------------------------------
app.MapControllers();

app.Run();
