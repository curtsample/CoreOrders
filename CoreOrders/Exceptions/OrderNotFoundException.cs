using System;
using System.Collections.Generic;
using System.Text;

namespace CoreOrders.Exceptions {
   public class OrderNotFoundException : Exception {
      public int OrderId { get; }

      public OrderNotFoundException(int orderId) {
         OrderId = orderId;
      }
   }
}
