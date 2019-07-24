using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.DataRepository
{
   public interface IOccupationRepository<T> where T: class
    {        
        IList<T> GetAllOccupationRating();              
    }
}
