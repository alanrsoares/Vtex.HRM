namespace Pingdom.Client.WebApi
{
    using System.Web.Http;

    public class ActionsController : ApiController
    {
        private readonly Controllers.ActionsController _resource = Resources.Actions;

        // GET api/actions
        public dynamic Get()
        {
            return _resource.GetActionsList().ToObject();
        }
    }
}
