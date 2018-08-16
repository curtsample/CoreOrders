using CoreOrders.Exceptions;
using CoreOrders.Models;
using CoreOrders.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
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

      [TestMethod]
      public void Update_WhenItemFound_ChangesItemQuantity() {
         // arrange
         var orderId = 1;
         var itemId = 1;
         var currentQuantity = 1;

         var existingOrders = new List<Order> {
            new Order {
               Id = orderId,
               Items = new Dictionary<int, int>{ { itemId, currentQuantity } }
            }
         };
         _repository = new OrderRepository(existingOrders);

         var updatedQuantity = 5;

         // act
         _repository.Update(orderId, itemId, updatedQuantity);

         // assert
         var savedQuantity = _repository
            .Orders
            .First(w => w.Id == orderId)
            .Items[itemId];
         Assert.AreEqual(updatedQuantity, savedQuantity);
      }

      [TestMethod]
      [ExpectedException(typeof(OrderNotFoundException))]
      public void Clear_WhenOrderNotFound_ThrowsOrderNotFoundException() {
         // arrange
         _repository = new OrderRepository(new List<Order>());

         // act & assert
         _repository.Clear(-1);
      }

      [TestMethod]
      public void Clear_EmptiesItemsFromOrder() {
         // arrange
         var orderId = 1;
         var existingOrders = new List<Order> {
            new Order {
               Id = orderId,
               Items = new Dictionary<int, int> {
                  { 1, 1 },
                  { 2, 5 },
                  { 3, 2 }
               }
            }
         };
         _repository = new OrderRepository(existingOrders);

         // act
         _repository.Clear(orderId);

         // assert
         Assert.IsFalse(_repository.Orders.First(f => f.Id == orderId).Items.Keys.Any());
      }
   }
}
