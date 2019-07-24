
using BusinessObject;
using DataAccess;
using DataAccess.DataRepository;
using DataManager.Managers;
using System.Collections.Generic;

namespace DataManager
{
    public class OccupationRatingManager : BaseManager<OccupationRating>
    {
        private readonly IRepository<talRating> _rep = null;
        public OccupationRatingManager():base()
        {
            _rep = new OccupationRatingRepository();
        }
        public OccupationRatingManager(IRepository<talRating> rep)
        {
            _rep = rep;
        }        
        
        public override IList<OccupationRating> GetAll(string searchKey)
        {
            IList<talRating> itemsRepository = _rep.GetAll(searchKey);
            IList<OccupationRating> items = new List<OccupationRating>();
            OccupationRating item = null;
            foreach (talRating o in itemsRepository)
            {
                item = new OccupationRating()
                {
                    Id = o.RatingId,
                    Name = o.Name,
                    Factor = o.Factor,                    
                   // Description = o.Description                    
                };
                items.Add(item);
            }
            return items;
        }        
    } // class
}
