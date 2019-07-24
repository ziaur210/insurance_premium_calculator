using System.Collections.Generic;

namespace DataManager.Managers
{
    public interface ICustomerManager<T> where T: class
    {        
        IList<T> GetAllCustomerDetails(string searchKey);              
    }
}
