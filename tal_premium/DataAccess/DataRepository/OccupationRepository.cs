using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataAccess.DataRepository
{
    public class OccupationRepository : BaseRepository<talOccupation>,IOccupationRepository<ResultOccupationRating>
    {
        public override IList<talOccupation> GetAll(string searchKey)
        {
            List<talOccupation> items = new List<talOccupation>();
            try
            {
                using (DataContext _db = new DataContext())
                {
                    searchKey = string.IsNullOrWhiteSpace(searchKey) ? "" : searchKey;
                    if (searchKey.Length == 0)
                    {
                        items = _db.talOccupations.AsNoTracking()
                                .ToList();
                    }
                    else
                    {
                        items = _db.talOccupations.AsNoTracking()
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
        public IList<ResultOccupationRating> GetAllOccupationRating()
        {
            List<ResultOccupationRating> items = new List<ResultOccupationRating>();
            try
            {
                using (DataContext _db = new DataContext())
                {
                    string sql = @" [dbo].[procOccupationRating] ";
                    items = _db.Database.SqlQuery<ResultOccupationRating>(sql)
                            .ToList();
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
