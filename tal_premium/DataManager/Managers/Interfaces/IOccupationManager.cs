using System.Collections.Generic;

namespace DataManager.Managers
{
    public interface IOccupationManager<T> where T: class
    {        
        IList<T> GetAllOccupationRating();              
    }
}
