using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Threading.Tasks;

namespace HandChef.API.Controllers
{
    public class VersionController : Controller
    {
        [Route("api/versao")]
        [HttpGet]
        public async Task<IActionResult> ObterVersao()
        {
            var runtimeVersion = typeof(Startup)
            .GetTypeInfo()
            .Assembly
            .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
            .InformationalVersion;

            return Ok(new
            {
                Versao = runtimeVersion
            });
        }
    }
}
