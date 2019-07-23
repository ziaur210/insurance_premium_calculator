using System;
using System.Collections.Generic;

namespace DataAccess.DataRepository
{
    public abstract class BaseRepository<T> : IRepository<T> where T:  class 
    {       
        public virtual T GetById(int id)
        {
            return default(T);
        }
        public virtual IList<T> GetAll(string searchKey)
        {
            return default(List<T>);
        }
        public virtual IList<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> whereCondition)
        {
            return default(List<T>);
        }
        public virtual int Add(T item)
        {
            return default(int);
        }        
        public virtual int Edit(T item)
        {
            return default(int);
        }      
        public virtual int Delete(int id)
        {
            return default(int);
        }

    } // end of class
}
