using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProductRestApi.Models;
using ProductRestApi.Controllers;

var builder = WebApplication.CreateBuilder(args);

// 1) Registra DbContext y repositorio
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// 2) Registra controllers y Swagger
builder.Services.AddControllers();

// Estos dos vienen de Swashbuckle.AspNetCore:
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Student API",
        Version = "v1"
    });
});

var app = builder.Build();

// 3) Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Student API V1");
        c.RoutePrefix = string.Empty; // sirve UI en /
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();