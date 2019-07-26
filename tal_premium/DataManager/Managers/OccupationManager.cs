
using BusinessObject;
using DataAccess;
using DataAccess.DataRepository;
using DataManager.Managers;
using System.Collections.Generic;

namespace DataManager
{
    public class OccupationManager : BaseManager<Occupation>, IOccupationManager<Occupation>
    {
        private readonly IOccupationRepository<ResultOccupationRating> _repOccupation = null;
        public OccupationManager() : base()
        {
            _repOccupation = new OccupationRepository();
        }
        public OccupationManager(IOccupationRepository<ResultOccupationRating> repOccupation) 
        {
            _repOccupation = repOccupation;
        }
        public IList<Occupation> GetAllOccupationRating()
        {
            IList<ResultOccupationRating> itemsRepository = _repOccupation.GetAllOccupationRating();
            IList<Occupation> items = new List<Occupation>();
            Occupation item = null;
            foreach (ResultOccupationRating o in itemsRepository)
            {
                item = new Occupation()
                {
                    Id = o.OccupationId,
                    Name = o.OccupationName,
                    RatingId = o.RatingId,
                    RatingName = o.RatingName,
                    RatingFactor = o.RatingFactor
                };
                items.Add(item);
            }
            return items;
        }
    } // class
}
