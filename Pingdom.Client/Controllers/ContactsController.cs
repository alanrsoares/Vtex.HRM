namespace Pingdom.Client.Controllers
{
    public class ContactsController : ResourceController
    {
        public JsonStringResult GetContactsList()
        {
            return Client.Get("contacts/");
        }
    }
}