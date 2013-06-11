using System.Threading.Tasks;

namespace Pingdom.Client.Controllers
{
    public class ProbesController : ResourceController
    {
        public Task<string> GetProbeServerList()
        {
            return Client.GetAsync("probes/");
        }
    }
}