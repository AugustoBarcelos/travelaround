using Microsoft.EntityFrameworkCore;
using TravelMapApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurar o serviço do DbContext com SQLite
builder.Services.AddDbContext<TravelMapDbContext>(options =>
    options.UseSqlite("Data Source=travelmap.db"));

// Adicionar serviços para controllers da API
builder.Services.AddControllers();

// Configurar Swagger para desenvolvimento
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();