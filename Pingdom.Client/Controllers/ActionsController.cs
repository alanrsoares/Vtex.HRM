using System.Threading.Tasks;

namespace Pingdom.Client.Controllers
{
    public class ActionsController : ResourceController
    {
        public async Task<JsonStringResult> GetActionsList()
        {
            return await Client.Get("actions/");
        }
    }
}