using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


/* configuracion de JWT Validaciones en el proyecto */
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(
                        builder.Configuration.GetSection("AppSettings:Token").Value
                    )
                ),
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    }
    );

/* Configuracion del token con swagger */

builder.Services.AddSwaggerGen(
     options =>
     {
         options.OperationFilter<SecurityRequirementsOperationFilter>();
         options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
         {
             Description = "Autorizacion : Uso de Bearer. Ejemplo \"baerer {token}\" ",
             In = ParameterLocation.Header,
             Name = "Authorization",
             Type = SecuritySchemeType.ApiKey, /* Tipo de schema */
             Scheme = "Bearer"
         });
     }
    );

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

/* Agregamos Authenticacion*/
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

