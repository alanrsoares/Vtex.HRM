using System.Threading.Tasks;
using System.Web.Http;
using PingdomClient;
using PingdomClient.Resources;

namespace Vtex.HRM.WebApi.Controllers
{
    public class ActionsController : ApiController
    {
        private readonly ActionsResource _resource = Pingdom.Client.Actions;

        // GET api/actions
        public async Task<dynamic> Get()
        {
            var result = await _resource.GetActionsList();
            return result.Actions;
        }
    }
}
