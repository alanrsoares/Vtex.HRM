namespace Pingdom.Client.WebApi
{
    using System.Web.Http;

    public class ContactsController : ApiController
    {
        private readonly Controllers.ContactsController _resource = Resources.Contacts;

        // GET api/contacts
        public dynamic Get()
        {
            return _resource.GetContactsList().ToObject();
        }
    }
}
