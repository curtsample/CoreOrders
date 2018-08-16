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

      public int Create(Item item) {
         var orderId = GetNextOrderId();
         _orders.Add(new Order {
            Id = orderId,
            Items = new Dictionary<int, int> { { item.Id, 1 } }
         });

         return orderId;
      }

      private int GetNextOrderId() =>
         _orders.Any() ? _orders.Max(m => m.Id) + 1 : 1;
   }
}
