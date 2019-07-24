using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataAccess.DataRepository
{
    public class OccupationRatingRepository : BaseRepository<talRating>
    {
        public override IList<talRating> GetAll(string searchKey)
        {
            List<talRating> items = new List<talRating>();
            try
            {
                using (DataContext _db = new DataContext())
                {
                    searchKey = string.IsNullOrWhiteSpace(searchKey) ? "" : searchKey;
                    if (searchKey.Length == 0)
                    {
                        items = _db.talRatings.AsNoTracking()
                                .ToList();
                    }
                    else
                    {
                        items = _db.talRatings.AsNoTracking()
                            .Where(x => x.Name.Equals(searchKey))
                            .ToList();
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return items;
        }
        
    } // end of class
}
