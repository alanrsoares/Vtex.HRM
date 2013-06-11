using System.Threading.Tasks;

namespace Pingdom.Client.Controllers
{
    using System.Collections.Generic;

    public sealed class ChecksController : ResourceController
    {
        public Task<string> GetChecksList()
        {
            return Client.GetAsync("checks/");
        }

        public Task<string> GetDetailedCheckInformation(int checkId)
        {
            return Client.GetAsync(string.Format("checks/{0}", checkId));
        }

        public Task<string> CreateNewCheck(object check)
        {
            return Client.PostAsync("checks/", check);
        }

        public Task<string> ModifyCheck(int checkId, object check)
        {
            return Client.PutAsync(string.Format("checks/{0}", checkId), check);
        }

        public Task<string> ModifyMultipleChecks(object modifyMultipleChecksRequest)
        {
            return Client.PutAsync("checks/", modifyMultipleChecksRequest);
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