using System.Threading.Tasks;
using System.Web.Http;
using Pingdom.Client;
using WebAPI.OutputCache;

namespace Vtex.HRM.WebApi.Controllers
{
    public class AnalysisController : ApiController
    {
        private readonly Pingdom.Client.Controllers.AnalysisController _resource = Resources.Analysis;

        // GET api/analysis/9
        [CacheOutput(ClientTimeSpan = 60, ServerTimeSpan = 60)]
        public async Task<dynamic> Get(int id)
        {
            var checkId = id;
            var result = await _resource.GetRootCauseAnalysisResultsList(checkId);
            return new JsonStringResult(result).ToDynamicObject();
        }

        // GET api/analysis/5/6
        [CacheOutput(ClientTimeSpan = 60, ServerTimeSpan = 60)]
        public async Task<dynamic> Get(int id, int analysisId)
        {
            var checkId = id;
            var result = await _resource.GetRawAnalysisResults(checkId, analysisId);
            return new JsonStringResult(result).ToDynamicObject();
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
