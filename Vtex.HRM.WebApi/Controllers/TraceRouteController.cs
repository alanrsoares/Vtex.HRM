using System.Threading.Tasks;
using System.Web.Http;
using Pingdom.Client;
using WebAPI.OutputCache;

namespace Vtex.HRM.WebApi.Controllers
{
    public class TraceRouteController : ApiController
    {
        private readonly Pingdom.Client.Controllers.TraceRouteController _resource = Resources.TraceRoute;

        // GET api/analysis/5/6
        [CacheOutput(ClientTimeSpan = 60, ServerTimeSpan = 60)]
        public async Task<dynamic> Get(string host, int probeId)
        {
            var result = await _resource.MakeTraceroute(host, probeId);
            return new JsonStringResult(result).ToDynamicObject();
        }
    }
}
