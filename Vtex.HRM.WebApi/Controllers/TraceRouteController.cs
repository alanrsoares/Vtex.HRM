namespace Vtex.HRM.WebApi.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Http;
    using PingdomClient;
    using PingdomClient.Resources;
    using WebAPI.OutputCache;

    public class TraceRouteController : ApiController
    {
        private readonly TraceRouteResource _resource = Pingdom.Client.TraceRoute;

        // GET api/analysis/5/6
        [CacheOutput(ClientTimeSpan = 60, ServerTimeSpan = 60)]
        public async Task<dynamic> Get(string host, int probeId)
        {
            return await _resource.MakeTraceroute(host, probeId);
        }
    }
}
