using BusinessObject;
using DataManager;
using DataManager.Managers;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Webapi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/occupation-rating")]
    public class OccupationRatingController : BaseapiController 
    {
        private readonly IManager<OccupationRating> _manager = null;
        public OccupationRatingController(): base()
        {
             _manager = new OccupationRatingManager();
        }
                
        [HttpGet]
        [Route("List")]
        public virtual IList<OccupationRating> List()
        {
            IList<OccupationRating> items = _manager.GetAll("");
            return items;
        }
        
    } // end of class
}