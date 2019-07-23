using System.Collections.Generic;

namespace DataManager.Managers
{
   public interface IManager<T>  where T: class
    {
        T GetById(int Id);
        IList<T> GetAll(string searchKey);
        int Add(T item);
        int Edit(T item);
        int Delete(int Id);
    }
}
