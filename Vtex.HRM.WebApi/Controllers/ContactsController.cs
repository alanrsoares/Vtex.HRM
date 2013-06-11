using System.Threading.Tasks;
using System.Web.Http;
using Pingdom.Client;

namespace Vtex.HRM.WebApi.Controllers
{
    public class ContactsController : ApiController
    {
        private readonly Pingdom.Client.Controllers.ContactsController _resource = Resources.Contacts;

        // GET api/contacts
        public async Task<dynamic> Get()
        {
            var result = await _resource.GetContactsList();
            return new JsonStringResult(result).ToDynamicObject();
        }
    }
}
