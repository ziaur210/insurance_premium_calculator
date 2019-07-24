using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.DataRepository
{
   public interface ICustomerRepository<T> where T: class
    {        
        IList<T> GetAllCustomerDetails(string searchKey);              
    }
}
