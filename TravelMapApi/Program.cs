using Microsoft.EntityFrameworkCore;
using TravelMapApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurar o serviço do DbContext com SQLite (ou outro banco local para desenvolvimento)
builder.Services.AddDbContext<TravelMapDbContext>(options =>
    options.UseSqlite("Data Source=travelmap.db"));

// Adicionar serviços necessários, como controllers e outros serviços para a API
builder.Services.AddControllers();

var app = builder.Build();

// Configurações de pipeline da aplicação
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Configurações do roteamento e dos endpoints
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
