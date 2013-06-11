using System.Threading.Tasks;

namespace Pingdom.Client.Controllers
{
    public class ContactsController : ResourceController
    {
        public async Task<JsonStringResult> GetContactsList()
        {
            return await Client.Get("contacts/");
        }
    }
}