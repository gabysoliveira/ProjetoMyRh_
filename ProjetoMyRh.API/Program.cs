using Microsoft.EntityFrameworkCore;
using ProjetoMyRh.API.Models.Contexts;
using ProjetoMyRh.API.Models.Startup;
using ProjetoMyRh.API.Services;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager config = builder.Configuration;

// Add services to the container.

builder.Services.AddDbContext<MyRhContext>(options =>
    options.UseSqlServer(config.GetConnectionString("MyRhConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Habilitando os services
builder.Services.AddScoped<CandidatosService>();
builder.Services.AddScoped<AreasService>();
builder.Services.AddScoped<InscricoesService>();


var app = builder.Build();
var scope = app.Services.CreateScope();
var provider = scope.ServiceProvider;
var context = provider.GetRequiredService<MyRhContext>();

// sincronizando com o banco de dados 
DbInitializer.Initializer(context);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
