using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataAccess.DataRepository
{
    public class CustomerRepository : BaseRepository<talCustomer>, ICustomerRepository<ResultCustomerDetails>
    {
        public override IList<talCustomer> GetAll(string searchKey)
        {
            List<talCustomer> items = new List<talCustomer>();
            try
            {
                using (DataContext _db = new DataContext())
                {
                    searchKey = string.IsNullOrWhiteSpace(searchKey) ? "" : searchKey;
                    if (searchKey.Length == 0)
                    {
                        items = _db.talCustomers.AsNoTracking()
                                .ToList();
                    }
                    else
                    {
                        items = _db.talCustomers.AsNoTracking()
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

        public override int Add(talCustomer item)
        {
            int addedId = Save(item);
            return addedId;
        }

        public override int Delete(int id)
        {
            int deletedId = 0;
            try
            {
                using (var db = new DataContext())
                {
                    var itemToDelete = db.talCustomers.SingleOrDefault(x => x.CustomerId == id);
                    if (itemToDelete != null)
                    {
                        db.talCustomers.Remove(itemToDelete);
                        db.SaveChanges();
                    }
                    deletedId = itemToDelete.CustomerId;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return deletedId;
        }

        private int Save(talCustomer item)
        {
            int savedID = 0;
            try
            {
                using (var db = new DataContext())
                {
                    if (item.CustomerId == 0)
                    {
                        db.talCustomers.Add(item);
                    }
                    else
                    {
                        db.Entry(item).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                }
                savedID = item.CustomerId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return savedID;
        }

        public IList<ResultCustomerDetails> GetAllCustomerDetails(string searchKey)
        {
            List<ResultCustomerDetails> items = new List<ResultCustomerDetails>();
            try
            {
                using (DataContext _db = new DataContext())
                {
                    string sql = @" [dbo].[procCustomerDetails] ";
                    items = _db.Database.SqlQuery<ResultCustomerDetails>(sql)
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
