namespace Pingdom.Client
{
    public class ResourceController
    {
        internal readonly PingdomBaseClient Client;

        protected ResourceController()
        {
            Client = new PingdomBaseClient();
        }
    }
}