using System.Threading.Tasks;

namespace Pingdom.Client.Controllers
{
    public class ContactsController : ResourceController
    {
        public Task<string> GetContactsList()
        {
            return Client.GetAsync("contacts/");
        }
    }
}