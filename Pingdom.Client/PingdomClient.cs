namespace Pingdom.Client
{
    public class PingdomClient
    {
        public Resources Resources
        {
            get
            {
                return new Resources();
            }
        }

        private static PingdomContollers Contollers { get; set; }

        public PingdomClient()
        {
            Contollers = new PingdomContollers();
        }
    }

    public class Resources
    {
        public ActionsController Actions
        {
            get
            {
                return new ActionsController();
            }
        }

        public AnalysisController Analysis
        {
            get
            {
                return new AnalysisController();
            }
        }

        public ChecksController Checks
        {
            get
            {
                return new ChecksController();
            }
        }

        public ContactsController Contacts
        {
            get
            {
                return new ContactsController();
            }
        }
    }
    
}
