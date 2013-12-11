namespace Vtex.HRM.WebApi.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Http;
    using PingdomClient;
    using PingdomClient.Resources;
    using PingdomClient.Contracts;
    using WebAPI.OutputCache;

    public class ProbesController : ApiController
    {
        private readonly ProbesResource _resource = Pingdom.Client.Probes;

        // GET api/probes/
        [CacheOutput(ClientTimeSpan = 6000, ServerTimeSpan = (60 * 60 * 5))]
        public async Task<GetProbeServerListResponse> Get()
        {
            return await _resource.GetProbeServerList();
        }
    }
}
