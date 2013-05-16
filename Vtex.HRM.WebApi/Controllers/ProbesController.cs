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
        public dynamic Get()
        {
            return _resource.GetProbeServerList().ToDynamicObject();
        }
    }
}
