using System;
using System.Collections.Generic;
using System.Text;

namespace CoreOrders.Models {    
   public class Order {
      public int Id { get; set; }

      /// <summary>
      /// Dictionary of items where the key refers to <see cref="Item.Id"/>
      /// and the value is the quantity of the items currently in the Order
      /// </summary>
      public IDictionary<int, int> Items { get; set; }
   }
}
