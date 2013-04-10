namespace Pingdom.Client.WebApi
{
    using System.Web.Http;

    public class AnalysisController : ApiController
    {
        private readonly Controllers.AnalysisController _resource = Resources.Analysis;

        // GET api/analysis/9
        public dynamic Get(int checkId)
        {
            return _resource.GetRootCauseAnalysisResultsList(checkId).ToObject();
        }

        // GET api/analysis/5/6
        public dynamic Get(int checkId, int analysisId)
        {
            return _resource.GetRawAnalysisResults(checkId, analysisId).ToObject();
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
