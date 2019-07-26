using BusinessObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Webapi.Controllers.Tests
{
    [TestClass()]
    public class CustomerControllerTest
    {
        Mock<CustomerController> mockingController = null;

        public CustomerControllerTest()
        {
            mockingController = new Mock<CustomerController>();
        }

        [TestMethod()]
        public void Test_List()
        {
            // arrange
            string searchKey = "";
            int expectedCount = 2;
            int actualCount = 0;
            mockingController.Setup(x => x.List(It.IsAny<string>())).Returns(GetList());
            // Act
            try
            {
                actualCount = mockingController.Object.List(searchKey).Count();
            }
            catch (Exception ex)
            {
                string errMsg = ex.Message;
                actualCount = 0;
            }
            // Assert
            Assert.IsTrue(expectedCount == actualCount);

        }

        [TestMethod()]
        public void AddTest()
        {
            // arrange
            
            mockingController.Setup(x => x.Add(It.IsAny<Customer>())).Returns(1);
            BusinessObject.Customer projectToAdd = new BusinessObject.Customer()
            {
                Name = "customer1"
            };
            // Act
            int newCustomerID = 0;
            try
            {
                newCustomerID =  mockingController.Object.Add(projectToAdd);
            }
            catch (Exception)
            {
                newCustomerID = 2;
            }
            // Assert
            Assert.IsTrue(newCustomerID == 1);
        }

        #region Miscellaneous
        private IList<Customer> GetList()
        {
            var list = new List<Customer>() { new Customer()
            {
                Id = 1,
                Name = "customer1"               
            },
            new Customer()
            {
                Id = 2,
                Name = "customer2",
            },
        };
            return list;
        }

        #endregion Miscellaneous
    }
}