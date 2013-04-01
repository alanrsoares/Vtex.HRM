namespace Pingdom.Client
{
    public class PingdomContollers
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

        public ChecksController Checkses
        {
            get
            {
                return new ChecksController();
            }
        }
    }

    #region Pingdom API Controllers
    public class ActionsController : ResourceController
    {
        public dynamic GetActionsList()
        {
            return Client.Get("actions/");
        }
    }

    public class AnalysisController : ResourceController
    {
        public dynamic GetRootCauseAnalysisResultsList(int checkId)
        {
            return Client.Get(string.Format("analysis/{0}", checkId));
        }

        public dynamic GetRawAnalysisResults(int checkId, int analysisId)
        {
            return Client.Get(string.Format("analysis/{0}/{1}", checkId, analysisId));
        }
    }

    public sealed class ChecksController : ResourceController
    {
        public dynamic GetChecksList()
        {
            return Client.Get("checks/");
        }

        public dynamic GetDetailedCheckInformation(int checkId)
        {
            return Client.Get(string.Format("checks/{0}", checkId));
        }

        public dynamic CreateNewCheck(object check)
        {
            return Client.Post("checks/", check);
        }
    }

    public class ContactsController : ResourceController
    {
        public dynamic GetContactsList()
        {
            return Client.Get("contacts/");
        }
    }
    #endregion

    public class ResourceController
    {
        internal readonly PingdomBaseClient Client;

        protected ResourceController()
        {
            Client = new PingdomBaseClient();
        }
    }
}