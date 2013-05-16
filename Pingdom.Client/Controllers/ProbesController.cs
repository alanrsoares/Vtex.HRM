namespace Pingdom.Client.Controllers
{
    public class ProbesController : ResourceController
    {
        public JsonStringResult GetProbeServerList()
        {
            return Client.Get("probes/");
        }
    }
}