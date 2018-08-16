using CoreOrders.Exceptions;
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
      public ActionResult Update(int orderId, int itemId, [FromBody]int quantity = 1) {
         try {
            _repository.Update(orderId, itemId, quantity);
            return Ok();
         }
         catch(Exception ex) {
            return BadRequest(ex.Message);
         }
      }

      [HttpPut]
      [Route("{orderId:int}/Clear")]
      public ActionResult Clear(int orderId) {
         try {
            _repository.Clear(orderId);
            return Ok();
         }
         catch (Exception ex) {
            return BadRequest(ex.Message);
         }
      }
   }
}
