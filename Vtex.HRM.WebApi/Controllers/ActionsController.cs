using System.Threading.Tasks;
using System.Web.Http;
using Pingdom.Client;

namespace Vtex.HRM.WebApi.Controllers
{
    public class ActionsController : ApiController
    {
        private readonly Pingdom.Client.Controllers.ActionsController _resource = Resources.Actions;

        // GET api/actions
        public async Task<dynamic> Get()
        {
            var result = await _resource.GetActionsList();
            return  result.ToDynamicObject();
        }
    }
}
