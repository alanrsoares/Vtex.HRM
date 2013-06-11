using System.Threading.Tasks;
using System.Web.Http;
using Pingdom.Client;
using WebAPI.OutputCache;

namespace Vtex.HRM.WebApi.Controllers
{
    public class ProbesController : ApiController
    {
        private readonly Pingdom.Client.Controllers.ProbesController _resource = Resources.Probes;

        // GET api/probes/
        [CacheOutput(ClientTimeSpan = 6000, ServerTimeSpan = (60 * 60 * 5))]
        public async Task<dynamic> Get()
        {
            var result = await _resource.GetProbeServerList();
            return result.ToDynamicObject();
        }
    }
}
