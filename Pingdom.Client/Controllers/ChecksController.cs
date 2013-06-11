using System.Threading.Tasks;

namespace Pingdom.Client.Controllers
{
    using System.Collections.Generic;

    public sealed class ChecksController : ResourceController
    {
        public async Task<JsonStringResult> GetChecksList()
        {
            return await Client.GetAsync("checks/");
        }

        public Task<JsonStringResult> GetDetailedCheckInformation(int checkId)
        {
            return Client.GetAsync(string.Format("checks/{0}", checkId));
        }

        public async Task<JsonStringResult> CreateNewCheck(object check)
        {
            return await Client.PostAsync("checks/", check);
        }

        public async Task<JsonStringResult> ModifyCheck(int checkId, object check)
        {
            return await Client.PutAsync(string.Format("checks/{0}", checkId), check);
        }

        public async Task<JsonStringResult> ModifyMultipleChecks(object modifyMultipleChecksRequest)
        {
            return await Client.PutAsync("checks/", modifyMultipleChecksRequest);
        }

        public Task<JsonStringResult> DeleteCheck(int checkId)
        {
            return Client.DeleteAsync(string.Format("checks/{0}", checkId));
        }

        public async Task<JsonStringResult> DeleteMultipleChecks(IEnumerable<int> checkIds)
        {
            return await Client.DeleteAsync("checks/", new { checkIds = string.Join(",", checkIds) });
        }
    }
}