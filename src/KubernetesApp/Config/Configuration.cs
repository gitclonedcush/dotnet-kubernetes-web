namespace KubernetesApp.Config
{
    public class Configuration
    {
        public string Version { get; set; }
        public string Environment { get; set; }

        // Add additional config values (like access key variables) here and they will be automatically populated by the 
        // corresponding environment var. 
        // See: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-2.2
    }
}