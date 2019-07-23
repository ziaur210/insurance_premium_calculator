using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.DataRepository
{
   public interface IRepository<T> where T: class
    {
        T GetById(int Id);
        IList<T> GetAll(string searchKey);
        IList<T> GetAll(Expression<Func<T, bool>> whereCondition);
        int Add(T item);
        int Edit(T item);
        int Delete(int Id);        
    }
}
