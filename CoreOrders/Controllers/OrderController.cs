using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreOrders.Controllers {
   [Route("api/[controller]")]
   [ApiController]
   public class OrderController : ControllerBase {
      [HttpPost]
      public ActionResult<int> Create() =>
         BadRequest(new NotImplementedException(""));
   }
}
