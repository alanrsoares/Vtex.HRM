using System.Threading.Tasks;

namespace Pingdom.Client.Controllers
{
    public class AnalysisController : ResourceController
    {
        public async Task<JsonStringResult> GetRootCauseAnalysisResultsList(int checkId)
        {
            return await Client.Get(string.Format("analysis/{0}", checkId));
        }

        public async Task<JsonStringResult> GetRawAnalysisResults(int checkId, int analysisId)
        {
            return await Client.Get(string.Format("analysis/{0}/{1}", checkId, analysisId));
        }
    }
}