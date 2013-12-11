namespace Vtex.HRM.WebApi.Controllers
{
    using System.Threading.Tasks;
    using PingdomClient;
    using PingdomClient.Contracts;
    using PingdomClient.Resources;
    using System.Web.Http;
    using WebAPI.OutputCache;

    public class ChecksController : ApiController
    {
        private readonly ChecksResource _resource = Pingdom.Client.Checks;

        // GET api/checks
        [CacheOutput(ClientTimeSpan = 60, ServerTimeSpan = 60)]
        public async Task<GetCheckListResponse> Get()
        {
            var getCheckListResponse = await _resource.GetChecksList();
            return getCheckListResponse;
        }

        // GET api/checks/5
        [CacheOutput(ClientTimeSpan = 60, ServerTimeSpan = 60)]
        public async Task<GetDetailedCheckInformationResponse> Get(int id)
        {
            return await _resource.GetDetailedCheckInformation(id);
        }

        // POST api/checks
        public async Task<PingdomResponse> Post([FromBody]object check)
        {
            return await _resource.CreateNewCheck(check);
        }

        // PUT api/checks/5
        public async Task<PingdomResponse> Put(int checkId, [FromBody]object check)
        {
            return await _resource.ModifyCheck(checkId, check);
        }

        // PUT api/checks/5
        public dynamic Put([FromBody]object request)
        {
            return request;//_resource.ModifyMultipleChecks(request);
        }

        // DELETE api/checks/5
        public dynamic Delete(int checkId)
        {
            return _resource.DeleteCheck(checkId);
        }
    }
}
