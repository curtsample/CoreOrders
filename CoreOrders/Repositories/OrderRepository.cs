using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreOrders.Models;

namespace CoreOrders.Repositories {
   public class OrderRepository : IOrderRepository {
      public IReadOnlyCollection<Order> Orders => _orders.ToList().AsReadOnly();
      private IList<Order> _orders;

      public OrderRepository(IList<Order> orders) {
         _orders = orders ?? new List<Order>();
      }

      public int Create(Item item) => throw new NotImplementedException("");
   }
}
