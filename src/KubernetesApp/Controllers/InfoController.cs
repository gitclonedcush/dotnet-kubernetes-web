using KubernetesApp.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace KubernetesApp.Controllers 
{
    [ApiVersionNeutral]
    [Produces("application/json")]
    [Route("info")]
    public class InfoController : Controller
    {
        private readonly string _version;

        public InfoController(IOptions<Configuration> config)
        {
            _version = config.Value.Version;
        }

        [HttpGet]
        public object Info()
        {
            return new
            {
                Name = "KubernetesApp.API",
                Version = _version,
                ApiVersion = "v1.0"
            };
        }
    }
}