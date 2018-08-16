using CoreOrders.Models;
using CoreOrders.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreOrders.Controllers {
   [Route("api/[controller]")]
   [ApiController]
   public class OrderController : ControllerBase {
      private readonly IOrderRepository _repository;

      public OrderController(IOrderRepository repository) {
         _repository = repository;
      }

      [HttpPost]
      [Route("Item/{id:int}")]
      public ActionResult<int> Create(int id) =>
         Ok(_repository.Create(id));

      [HttpPut]
      [Route("{orderId:int}/Item/{itemId:int}")]
      public ActionResult Update(int orderId, int itemId, [FromBody]int quantity = 1)
         => BadRequest(new NotImplementedException(""));
   }
}
