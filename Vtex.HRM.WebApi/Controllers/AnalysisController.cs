namespace Vtex.HRM.WebApi.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Http;
    using PingdomClient;
    using PingdomClient.Resources;
    using WebAPI.OutputCache;

    public class AnalysisController : ApiController
    {
        private readonly AnalysisResource _resource = Pingdom.Client.Analysis;

        // GET api/analysis/9
        [CacheOutput(ClientTimeSpan = 60, ServerTimeSpan = 60)]
        public async Task<dynamic> Get(int id)
        {
            var checkId = id;
            var result = await _resource.GetRootCauseAnalysisResultsList(checkId);
            return result;
        }

        // GET api/analysis/5/6
        [CacheOutput(ClientTimeSpan = 60, ServerTimeSpan = 60)]
        public async Task<dynamic> Get(int id, int analysisId)
        {
            var checkId = id;
            var result = await _resource.GetRawAnalysisResults(checkId, analysisId);
            return result;
        }

        // POST api/checks
        public void Post([FromBody]string value)
        {
        }

        // PUT api/checks/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/checks/5
        public void Delete(int id)
        {
        }
    }
}
