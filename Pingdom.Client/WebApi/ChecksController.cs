using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using WebAPI.OutputCache;

namespace Pingdom.Client.WebApi
{
    using System.Web.Http;
    using Contracts.Checks;

    public class ChecksController : ApiController
    {
        private readonly Controllers.ChecksController _resource = Resources.Checks;

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
