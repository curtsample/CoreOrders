using CoreOrders.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreOrders.Repositories {
   public interface IOrderRepository {
      int Create(int itemId);
   }
}
