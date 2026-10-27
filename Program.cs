using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using ScottishGlenApp.Data;
namespace ScottishGlenApp;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory);
        configuration.AddJsonFile("appsettings.Development.json", optional:false);
        var settings = configuration.Build();
        var connectionString = settings.GetConnectionString("ScottishGlenDatabase");
        var optionsBuilder = new DbContextOptionsBuilder<ScottishGlenDbContext>();
        optionsBuilder.UseSqlServer(connectionString);
        using var dbContext = new ScottishGlenDbContext(optionsBuilder.Options);
        Application.Run(new AddAssetForm(dbContext));
    }    
}