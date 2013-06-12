using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Pingdom.Client.Controllers
{
    public sealed class TraceRouteController : ResourceController
    {
        public Task<string> MakeTraceroute(string host, int probeId)
        {
            return Client.GetAsync(string.Format("traceroute?host={0}&probeId={1}", host, probeId));
        }
    }
}
