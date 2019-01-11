using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using App.Metrics;
using App.Metrics.AspNetCore.Health;
using App.Metrics.Formatters.Prometheus;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;

namespace KubernetesApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseSerilog((hostingContext, loggerConfiguration) =>
                    loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration))
                .ConfigureMetricsWithDefaults(
                    builder =>
                    {
                        builder.OutputMetrics.AsPrometheusPlainText();
                    })
                .UseMetricsEndpoints(
                    options =>
                    {
                        options.MetricsEndpointOutputFormatter = new MetricsPrometheusTextOutputFormatter();
                    })
                .UseMetricsWebTracking()
                .UseHealth()
                .UseStartup<Startup>();
    }
}
