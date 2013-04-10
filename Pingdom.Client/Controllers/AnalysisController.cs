namespace Pingdom.Client.Controllers
{
    public class AnalysisController : ResourceController
    {
        public JsonStringResult GetRootCauseAnalysisResultsList(int checkId)
        {
            return Client.Get(string.Format("analysis/{0}", checkId));
        }

        public JsonStringResult GetRawAnalysisResults(int checkId, int analysisId)
        {
            return Client.Get(string.Format("analysis/{0}/{1}", checkId, analysisId));
        }
    }
}