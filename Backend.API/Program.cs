using Backend.API.Extensions;
using Backend.Application.IoC;
using Backend.Infrastructure.IoC;

var builder = WebApplication.CreateBuilder(args);

// Configuración de CORS
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Configuración de JWT (debe estar antes de AddControllers)
builder.AddJwtAuthentication();

// Inyección de dependencias - servicios de aplicación e infraestructura
builder.Services.AddServices(); // Desde Application
builder.Services.AddPersistenceServices(builder.Configuration); // Desde Infrastructure

// Configuración de controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Pipeline de HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllers();

app.Run();