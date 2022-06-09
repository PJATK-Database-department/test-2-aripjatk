using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test2.Models;

namespace Test2.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : Controller {
        internal class OrderRequestResult {
            public ClientOrder Order { get; set; }
            public IEnumerable<Confectionery_ClientOrder> Items { get; set; }
            public float TotalAmount { get; set; }
        }
        public class UpdateRequestParameters : ClientOrder {
            public IEnumerable<Confectionery> Confectionery { get; set; }
        }
        private IOrdersService Service;
        public OrdersController(IOrdersService service) {
            Service = service;
        }
        [HttpGet("/[controller]/getByClient")]
        public IActionResult GetOrdersByClient(int IDClient) {
            var results = new List<OrderRequestResult>();
            foreach(var order in Service.GetOrdersForClient(IDClient)) {
                results.Add(new OrderRequestResult { Order = order });
            }
            foreach(var result in results) {
                result.Items = new List<Confectionery_ClientOrder>();
                foreach (var item in Service.GetConfectioneryItemsForOrder(result.Order))
                    result.Items.Append(item);
                float amount = 0;
                foreach(var item in result.Items)
                    amount += item.Amount * Service.GetConfectioneryByID(item.IdConfectionery).PricePerOne;
                result.TotalAmount = amount;
            }
            return Ok(results);
        }
        [HttpPut("/[controller]/updateOrder")]
        public async Task<IActionResult> UpdateOrderAsync(int IDOrder, UpdateRequestParameters NewOrderData) {
            try {
                return Created("", await Service.UpdateOrderAsync(IDOrder, NewOrderData, NewOrderData.Confectionery));
            } catch(InvalidOperationException) {
                return NotFound();
            } catch(ArgumentException) {
                return NotFound();
            } catch(AccessViolationException) {
                return Forbid();
            }
        }
    }
}
