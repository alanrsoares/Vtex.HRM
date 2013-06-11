using System.Threading.Tasks;

namespace Pingdom.Client.Controllers
{
    public class ActionsController : ResourceController
    {
        public Task<string> GetActionsList()
        {
            return Client.GetAsync("actions/");
        }
    }
}