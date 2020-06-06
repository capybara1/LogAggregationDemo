using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using NLog.Web;

namespace Demo
{
  public class Program
  {
    public static void Main(string[] args)
    {
      NLog.LogManager.ThrowConfigExceptions = true;
      var logger = NLogBuilder
        .ConfigureNLog("nlog.config")
        .GetCurrentClassLogger();
      try
      {
        CreateHostBuilder(args).Build().Run();
      }
      catch (Exception exception)
      {
        logger.Error(exception, "Error during initialization");
        throw;
      }
      finally
      {
        NLog.LogManager.Shutdown();
      }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args)
        .ConfigureLogging(logging =>
        {
          logging.ClearProviders();
          logging.SetMinimumLevel(LogLevel.Trace); // Delegates filtering to NLog
        })
        .UseNLog()
        .ConfigureWebHostDefaults(webBuilder =>
        {
          webBuilder.UseStartup<Startup>();
        });
  }
}
