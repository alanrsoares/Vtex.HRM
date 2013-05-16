namespace Pingdom.Client
{
    using Controllers;

    public class Resources
    {
        public static ActionsController Actions
        {
            get
            {
                return new ActionsController();
            }
        }

        public static AnalysisController Analysis
        {
            get
            {
                return new AnalysisController();
            }
        }

        public static ChecksController Checks
        {
            get
            {
                return new ChecksController();
            }
        }

        public static ContactsController Contacts
        {
            get
            {
                return new ContactsController();
            }
        }

        public static ProbesController Probes
        {
            get
            {
                return new ProbesController();
            }
        }
    }
}