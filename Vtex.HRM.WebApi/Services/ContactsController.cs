using System.Web.Http;
using Pingdom.Client;

namespace Vtex.HRM.WebApi.Services
{
    public class ContactsController : ApiController
    {
        private readonly Pingdom.Client.Controllers.ContactsController _resource = Resources.Contacts;

        // GET api/contacts
        public dynamic Get()
        {
            return _resource.GetContactsList().ToDynamicObject();
        }
    }
}
