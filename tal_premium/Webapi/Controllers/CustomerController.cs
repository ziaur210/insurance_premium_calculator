using BusinessObject;
using DataManager;
using DataManager.Managers;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Webapi.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/customer")]
    public class CustomerController : BaseapiController 
    {
        private readonly IManager<Customer> _manager = null;
        private readonly  ICustomerManager<Customer> _customerManager = null;
        public CustomerController(): base()
        {
             _manager = new CustomerManager();
             _customerManager = new CustomerManager();
        }

        [HttpGet]   
        [Route("List/{searchKey}")]
        public virtual IList<Customer> List(string searchKey)
        {
            IList<Customer> items = _manager.GetAll(searchKey);
            return items;
        }
        [HttpGet]
        [Route("List")]
        public virtual IList<Customer> List()
        {
            IList<Customer> items = _customerManager.GetAllCustomerDetails("");
            return items;
        }

        [HttpPost]
        public virtual int Add(Customer item)
        {
            int newItemId = _manager.Add(item);
            return newItemId;
        }
    } // end of class
}