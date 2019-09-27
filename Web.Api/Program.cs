
namespace Generic
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Serilog;
    using Serilog.Events;

    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.RollingFile("C:\\Logs\\Generic.Web.Api")
                .CreateLogger();

            Log.Logger.Information("Starting Att.BillingManager.Web.Api");
            try
            {
                CreateWebHostBuilder(args).Build().Run();

            }
            catch(System.Exception ex)
            {
                Log.Error($"Exception caught: {ex.Message}. StackTrace: {ex.StackTrace}");
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseIISIntegration()
            .UseSerilog()
            .UseStartup<Startup>();
    }
}
