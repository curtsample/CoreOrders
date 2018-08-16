using System;
using System.Collections.Generic;
using System.Text;

namespace CoreOrders.Exceptions {
   public class OrderNotFoundException : Exception {
      public int OrderId { get; }

      public OrderNotFoundException(int orderId) 
         : base($"Couldn't find Order with Id {orderId}") {

         OrderId = orderId;
      }
   }
}
