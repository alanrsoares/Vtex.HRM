using System.Web.Http;
using Pingdom.Client;

namespace Vtex.HRM.WebApi.Services
{
    public class ActionsController : ApiController
    {
        private readonly Pingdom.Client.Controllers.ActionsController _resource = Resources.Actions;

        // GET api/actions
        public dynamic Get()
        {
            return _resource.GetActionsList().ToDynamicObject();
        }
    }
}
