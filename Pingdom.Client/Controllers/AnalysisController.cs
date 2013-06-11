﻿using System.Threading.Tasks;

namespace Pingdom.Client.Controllers
{
    public class AnalysisController : ResourceController
    {
        public Task<string> GetRootCauseAnalysisResultsList(int checkId)
        {
            return Client.GetAsync(string.Format("analysis/{0}", checkId));
        }

        public Task<string> GetRawAnalysisResults(int checkId, int analysisId)
        {
            return Client.GetAsync(string.Format("analysis/{0}/{1}", checkId, analysisId));
        }
    }
}