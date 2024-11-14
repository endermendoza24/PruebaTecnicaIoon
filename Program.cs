public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configuración de la conexión a la base de datos
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddSingleton(new Database(connectionString));
        builder.Services.AddSingleton<CommerceRepository>();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.MapControllers();

        app.Run();
    }
}
