namespace Shop.Presentation;

public class Program
{
    public static void Main(string[] args)
    {
        // --- Create Builder

        var builder = WebApplication.CreateBuilder(args);

        // --- Register Rate Limit

        builder.Services.RegisterRateLimit();

        // --- Register Main Services

        builder.Services.RegisterServices();

        // --- Register Database

        builder.Services.RegisterDatabase(builder.Configuration);

        // --- Register Api Versioning

        builder.Services.RegisterApiVersioning();

        // --- Register Dependency

        builder.Services.RegisterDependencyInjectionAndOptions(builder.Configuration);

        // --- Build

        var app = builder.Build();

        app.RegisterApplication();

        // --- Register Or Seed Data
        app.RegisterData();

        app.Run();
    }
}