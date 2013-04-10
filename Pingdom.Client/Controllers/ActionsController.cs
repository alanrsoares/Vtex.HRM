namespace Pingdom.Client.Controllers
{
    public class ActionsController : ResourceController
    {
        public JsonStringResult GetActionsList()
        {
            return Client.Get("actions/");
        }
    }
}