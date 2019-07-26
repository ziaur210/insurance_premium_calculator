
using BusinessObject;
using DataAccess;
using DataAccess.DataRepository;
using DataManager.Managers;
using System;
using System.Collections.Generic;

namespace DataManager
{
    public class CustomerManager : BaseManager<Customer>, ICustomerManager<Customer>
    {
        private readonly IRepository<talCustomer> _rep = null;
        private readonly ICustomerRepository<ResultCustomerDetails> _repCustomer = null;
        public CustomerManager() : base()
        {
            _rep = new CustomerRepository();
            _repCustomer = new CustomerRepository();
        }
        public CustomerManager(IRepository<talCustomer> rep, ICustomerRepository<ResultCustomerDetails> repCustomer)
        {
            _rep = rep;
            _repCustomer = repCustomer;
        }

        //public override IList<Customer> GetAll(string searchKey)
        //{
        //    IList<talCustomer> itemsRepository = _rep.GetAll(searchKey);
        //    IList<Customer> items = new List<Customer>();
        //    Customer item = null;
        //    foreach (talCustomer o in itemsRepository)
        //    {
        //        item = new Customer()
        //        {
        //            Id = o.CustomerId,
        //            OccupationId = o.OccupationId,
        //            Name = o.Name,
        //            DOB = o.DOB,
        //            InsuranceAmount = o.InsuranceAmount,
        //            InsuranceType = (byte)InsuranceType.Death,

        //        };
        //        items.Add(item);
        //    }
        //    return items;
        //}
        public override int Add(Customer item)
        {
            talCustomer itemRepository = new talCustomer()
            {
                Name = item.Name,
                OccupationId = item.OccupationId,
                DOB = item.DOB,
                InsuranceAmount = item.InsuranceAmount,
                InsuranceType = (byte)InsuranceType.Death,
                CustomerStatus = (byte)CustomerStatus.Active,  
                Description = "test customer",
                CreatedBy = 1,
                CreatedOn = DateTime.Now,
                UpdatedBy = 1,
                UpdatedOn = DateTime.Now
            };
            int addedId = _rep.Add(itemRepository);
            return addedId;
        }

        public IList<Customer> GetAllCustomerDetails(string searchKey)
        {
            IList<ResultCustomerDetails> itemsRepository = _repCustomer.GetAllCustomerDetails(searchKey);
            IList<Customer> items = new List<Customer>();
            Customer item = null;
            foreach (ResultCustomerDetails o in itemsRepository)
            {
                item = new Customer()
                {
                    Id = o.CustomerId,
                    OccupationId = o.OccupationId,
                    Name = o.Name,
                    DOB = o.DOB,
                    InsuranceAmount = o.InsuranceAmount,
                    InsuranceType = (byte)InsuranceType.Death,
                    OccupationName = o.OccupationName,
                    OccupationRatingId = o.RatingId,
                    OccupationRatingName = o.RatingName,
                    OccupationRatingFactor = o.RatingFactor
                };
                items.Add(item);
            }
            return items;
        }

    } // end of class
}
