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
        public dynamic Get()
        {
            return _resource.GetChecksList().ToDynamicObject();
        }

        // GET api/checks/5
        [CacheOutput(ClientTimeSpan = 60, ServerTimeSpan = 60)]
        public dynamic Get(int id)
        {
            return _resource.GetDetailedCheckInformation(id).ToDynamicObject();
        }

        // POST api/checks
        public dynamic Post([FromBody]object check)
        {
            return _resource.CreateNewCheck(check).ToDynamicObject();
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
