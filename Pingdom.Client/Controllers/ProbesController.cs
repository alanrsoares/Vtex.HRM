using System.Threading.Tasks;

namespace Pingdom.Client.Controllers
{
    public class ProbesController : ResourceController
    {
        public async Task<JsonStringResult> GetProbeServerList()
        {
            return await Client.Get("probes/");
        }
    }
}