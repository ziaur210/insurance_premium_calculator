using BusinessObject;
using DataManager;
using DataManager.Managers;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Webapi.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/occupation")]
    public class OccupationController : BaseapiController 
    {
        private readonly IManager<Occupation> _manager = null;
        private readonly  IOccupationManager<Occupation> _occupationManager = null;
        public OccupationController(): base()
        {
             _manager = new OccupationManager();
             _occupationManager = new OccupationManager();
        }
                

        [HttpGet]
        [Route("List")]
        public virtual IList<Occupation> List()
        {
            IList<Occupation> items = _occupationManager.GetAllOccupationRating();
            return items;
        }
      
    } // end of class
}