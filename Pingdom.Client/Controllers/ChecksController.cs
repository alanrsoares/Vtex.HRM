namespace Pingdom.Client.Controllers
{
    using System.Collections.Generic;
    using Contracts.Checks;

    public sealed class ChecksController : ResourceController
    {
        public JsonStringResult GetChecksList()
        {
            return Client.Get("checks/");
        }

        public JsonStringResult GetDetailedCheckInformation(int checkId)
        {
            return Client.Get(string.Format("checks/{0}", checkId));
        }

        public JsonStringResult CreateNewCheck(object check)
        {
            return Client.Post("checks/", check);
        }

        public JsonStringResult ModifyCheck(int checkId, object check)
        {
            return Client.Put(string.Format("checks/{0}", checkId), check);
        }

        public JsonStringResult ModifyMultipleChecks(ModifyMultipleChecksRequest modifyMultipleChecksRequest)
        {
            return Client.Put("checks/", modifyMultipleChecksRequest);
        }

        public JsonStringResult DeleteCheck(int checkId)
        {
            return Client.Delete(string.Format("checks/{0}", checkId));
        }

        public JsonStringResult DeleteMultipleChecks(IEnumerable<int> checkIds)
        {
            return Client.Delete("checks/", new { checkIds = string.Join(",", checkIds) });
        }
    }
}