using Livraria.Interfaces.Repositories;
using Livraria.Interfaces.Services;
using Livraria.Repositories;
using Livraria.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAssuntoRepository, AssuntoRepository>();
builder.Services.AddScoped<IAutorRepository, AutorRepository>();
builder.Services.AddScoped<IFormaCompraRepository, FormaCompraRepository>();
builder.Services.AddScoped<ILivroAssuntoRepository, LivroAssuntoRepository>();
builder.Services.AddScoped<ILivroAutorRepository, LivroAutorRepository>();
builder.Services.AddScoped<ILivroFormaCompraRepository, LivroFormaCompraRepository>();
builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<ILivrosPorAutorViewRepository, LivrosPorAutorViewRepository>();

builder.Services.AddScoped<IAssuntoService, AssuntoService>();
builder.Services.AddScoped<IAutorService, AutorService>();
builder.Services.AddScoped<IFormaCompraService, FormaCompraService>();
builder.Services.AddScoped<ILivroAssuntoService, LivroAssuntoService>();
builder.Services.AddScoped<ILivroAutorService, LivroAutorService>();
builder.Services.AddScoped<ILivroFormaCompraService, LivroFormaCompraService>();
builder.Services.AddScoped<ILivroService, LivroService>();
builder.Services.AddScoped<ILivrosPorAutorViewService, LivrosPorAutorViewService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()   // Permite qualquer origem
                  .AllowAnyMethod()   // Permite qualquer método (GET, POST, etc.)
                  .AllowAnyHeader();  // Permite qualquer cabeçalho
        });
});

var app = builder.Build();

app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
