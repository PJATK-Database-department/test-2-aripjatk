using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test2.Models;

namespace Test2 {
    public interface IOrdersService {
        public IEnumerable<ClientOrder> GetOrdersForClient(int IDClient);
        public IEnumerable<Confectionery_ClientOrder> GetConfectioneryItemsForOrder(ClientOrder order);
        public Task UpdateOrderAsync(int IDOrder, ClientOrder NewOrder, IEnumerable<Confectionery> NewOrderItems);
    }
}
