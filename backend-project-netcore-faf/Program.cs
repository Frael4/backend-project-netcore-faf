var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuracion CORS

builder.Services.AddCors(
        options =>
        {
            options.AddPolicy("PoliticaAPI", api =>
            {
                //Permitir cualquier origen -> cabecera -> metodo
                api.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            });
        }
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Uso de la politca CORS creada
app.UseCors("PoliticaAPI");

app.UseAuthorization();

app.MapControllers();

app.Run();

