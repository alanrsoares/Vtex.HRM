using System.Threading.Tasks;
using System.Web.Http;
using PingdomClient;

namespace Vtex.HRM.WebApi.Controllers
{
    public class ContactsController : ApiController
    {
        // GET api/contacts
        public async Task<dynamic> Get()
        {
            return await Pingdom.Client.Contacts.GetContactsList();
        }
    }
}
