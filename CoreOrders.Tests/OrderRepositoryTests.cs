using CoreOrders.Exceptions;
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

         // act
         var createdId = _repository.Create(1);

         // assert
         Assert.AreEqual(expectedId, createdId);
      }

      [TestMethod]
      [ExpectedException(typeof(OrderNotFoundException))]
      public void Update_WhenOrderNotFound_ThrowsOrderNotFoundException() {
         // arrange
         _repository = new OrderRepository(new List<Order>());         

         // act & assert
         _repository.Update(-1, -1, -1);
      }
   }
}
