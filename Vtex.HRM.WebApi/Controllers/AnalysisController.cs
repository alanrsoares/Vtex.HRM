using System.Web.Http;
using Pingdom.Client;

namespace Vtex.HRM.WebApi.Controllers
{
    public class AnalysisController : ApiController
    {
        private readonly Pingdom.Client.Controllers.AnalysisController _resource = Resources.Analysis;

        // GET api/analysis/9
        public dynamic Get(int checkId)
        {
            return _resource.GetRootCauseAnalysisResultsList(checkId).ToDynamicObject();
        }

        // GET api/analysis/5/6
        public dynamic Get(int checkId, int analysisId)
        {
            return _resource.GetRawAnalysisResults(checkId, analysisId).ToDynamicObject();
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
