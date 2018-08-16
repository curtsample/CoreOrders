using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreOrders.Models;

namespace CoreOrders.Repositories {
   public class OrderRepository : IOrderRepository {
      public IReadOnlyCollection<Order> Orders => _orders.ToList().AsReadOnly();
      private IList<Order> _orders;

      public OrderRepository() : this(new List<Order>()) { }

      public OrderRepository(IList<Order> orders) {
         _orders = orders ?? new List<Order>();
      }

      /// <summary>
      /// Creates a new <see cref="Order" containing the item provided with a quantity of 1 />
      /// </summary>
      /// <param name="itemId"></param>
      /// <returns></returns>
      public int Create(int itemId) {
         var orderId = GetNextOrderId();
         _orders.Add(new Order {
            Id = orderId,
            Items = new Dictionary<int, int> { { itemId, 1 } }
         });

         return orderId;
      }

      private int GetNextOrderId() =>
         _orders.Any() ? _orders.Max(m => m.Id) + 1 : 1;
   }
}
