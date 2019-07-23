
using BusinessObject;
using DataAccess;
using DataAccess.DataRepository;
using DataManager.Managers;
using System;
using System.Collections.Generic;

namespace DataManager
{
    public class CustomerManager : BaseManager<Customer>
    {
        private IRepository<talCustomer> _rep = new CustomerRepository();
        public CustomerManager():base()
        {           
        }
        public CustomerManager(IRepository<talCustomer> rep)
        {
            _rep = rep;
        }        
        
        public override IList<Customer> GetAll(string searchKey)
        {
            IList<talCustomer> itemsRepository = _rep.GetAll(searchKey);
            IList<Customer> items = new List<Customer>();
            Customer item = null;
            foreach (talCustomer o in itemsRepository)
            {
                item = new Customer()
                {
                    Id = o.CustomerId,
                    OccupationId = o.OccupationId,
                    Name = o.Name,
                    DOB = o.DOB,
                    InsuranceAmount = o.InsuranceAmount,
                    InsuranceType = (byte)InsuranceType.Death,
                                         
                };
                items.Add(item);
            }
            return items;
        }
        public override int Add(Customer item)
        {
            talCustomer itemRepository = new talCustomer()
            {
                CustomerId = item.Id,
                Name = item.Name,
                DOB = item.DOB,
                CustomerStatus = (byte)CustomerStatus.Active,
                CreatedBy  = 1,
                CreatedOn = DateTime.Now,
                UpdatedBy = 1,
                UpdatedOn = DateTime.Now
            };
            int addedId = _rep.Add(itemRepository);
            return addedId;
        }
    } // end of class
}
