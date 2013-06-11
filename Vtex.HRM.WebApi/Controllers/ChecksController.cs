using System.Threading.Tasks;
using Vtex.HRM.WebApi.Contracts.Checks;
using System.Web.Http;
using Pingdom.Client;
using WebAPI.OutputCache;

namespace Vtex.HRM.WebApi.Controllers
{
    public class ChecksController : ApiController
    {
        private readonly Pingdom.Client.Controllers.ChecksController _resource = Resources.Checks;

        // GET api/checks
        [CacheOutput(ClientTimeSpan = 60, ServerTimeSpan = 60)]
        public async Task<dynamic> Get()
        {
            var result = await _resource.GetChecksList();
            return result.ToDynamicObject();
        }

        // GET api/checks/5
        [CacheOutput(ClientTimeSpan = 60, ServerTimeSpan = 60)]
        public async Task<dynamic> Get(int id)
        {
            var result = await _resource.GetDetailedCheckInformation(id);
            return result.ToDynamicObject();
        }

        // POST api/checks
        public async Task<dynamic> Post([FromBody]object check)
        {
            var result = await _resource.CreateNewCheck(check);
            return result.ToDynamicObject();
        }

        // PUT api/checks/5
        public dynamic Put(int checkId, [FromBody]object check)
        {
            return _resource.ModifyCheck(checkId, check);
        }

        // PUT api/checks/5
        public dynamic Put([FromBody]ModifyMultipleChecksRequest request)
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
