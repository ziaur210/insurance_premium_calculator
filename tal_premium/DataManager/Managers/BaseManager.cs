using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Managers
{
    public abstract class BaseManager<T> : IManager<T> where T : class 
    {
        public virtual T GetById(int id)
        {
            return default(T);
        }
        public virtual IList<T> GetAll(string searchKey)
        {
            return default(List<T>);
        }
        public virtual int Add(T entry)
        {
            return 0;
        }
        public virtual int Delete(int id)
        {
            return 0;
        }
        public virtual int Edit(T entry)
        {
            return 0;
        }
              
    } // end of class
}
