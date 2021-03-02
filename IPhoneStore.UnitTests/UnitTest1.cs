using IPhoneStore.Domain.Abstract;
using IPhoneStore.Domain.Concrete;
using IPhoneStore.Domain.Entities;
using IPhoneStore.WebUI.Controllers;
using IPhoneStore.WebUI.HtmlHelpers;
using IPhoneStore.WebUI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace IPhoneStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
       

        [TestMethod]
        public void Can_Paginate()
        {
            //arrange
            Mock<IStoreRepository<IPhone>> mock = new Mock<IStoreRepository<IPhone>>();
            mock.Setup(m => m.Get()).Returns(new List<IPhone>
                {
                    new IPhone{Model = "IPhone 11"}
                });
            

            PhoneController controller = new PhoneController(mock.Object);
            //act
            IEnumerable<IPhone> result = controller.List().Model as IEnumerable<IPhone>;

            //assert
            List<IPhone> phones = result.ToList();
            Assert.IsTrue(phones.Count == 1);
            Assert.AreEqual(phones[0].Model, "IPhone 11");

        }

        [TestMethod]
        public void Can_Generate_Page_Links()
        {

            //arrange
            HtmlHelper myHelper = null;

            Pagination pagination = new Pagination
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };

            
            Func<int, string> pageUrlDelegate = i => "Page" + i;

            //act
            MvcHtmlString result = myHelper.PageLinks(pagination, pageUrlDelegate);

            //assert
            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
                + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"
                + @"<a class=""btn btn-default"" href=""Page3"">3</a>",
                result.ToString());
        }

        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            // Организация (arrange)
            Mock<IPhoneRepository> mock = new Mock<IPhoneRepository>();
            mock.Setup(m => m.Get()).Returns(new List<IPhone>
            {
                new IPhone { Model = "IPhone 11"},
                new IPhone { Model = "IPhone 12"},
                new IPhone { Model = "IPhone 13"},
                new IPhone { Model = "IPhone 14"},
                new IPhone { Model = "IPhone 15"}
            });
            PhoneController controller = new PhoneController(mock.Object);
            controller.pageSize = 3;

            // Act
            IPhoneListViewModel result
                = (IPhoneListViewModel)controller.List(2).Model;

            // Assert
            Pagination pagination = result.Pagination;
            Assert.AreEqual(pagination.CurrentPage, 2);
            Assert.AreEqual(pagination.ItemsPerPage, 3);
            Assert.AreEqual(pagination.TotalItems, 5);
            Assert.AreEqual(pagination.TotalPages, 2);
        }


    }
}
