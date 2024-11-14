using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;



public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        // Configuraci�n de la autenticaci�n JWT
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))
                };
            });

        // Configuraci�n de la conexi�n a la base de datos
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddSingleton(new Database(connectionString));
        builder.Services.AddSingleton<CommerceRepository>();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddSingleton<AuthService>();


        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();
        // Configuraci�n de la API
        app.UseAuthentication(); // Habilitar autenticaci�n
        app.UseAuthorization();  // Habilitar autorizaci�n

        app.MapControllers();

        app.Run();
    }
}
