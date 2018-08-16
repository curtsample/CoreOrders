using CoreOrders.Models;
using CoreOrders.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreOrders.Tests {
   [TestClass]
   public class OrderRepositoryTests {
      private OrderRepository _repository;

      [TestMethod]
      public void Create_Success() {
         // arrange
         _repository = new OrderRepository(new List<Order>());

         var expectedId = 1;
         var item = new Item { Id = 1, Name = "Test" };

         // act
         var createdId = _repository.Create(item);

         // assert
         Assert.AreEqual(expectedId, createdId);
      }
   }
}
