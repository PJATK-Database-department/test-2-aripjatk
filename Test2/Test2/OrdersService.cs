﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test2.Models;

namespace Test2 {
    public class OrdersService : IOrdersService {
        private OrdersDbContext DbContext;
        public OrdersService(OrdersDbContext Context) {
            DbContext = Context;
        }

        public IEnumerable<Confectionery_ClientOrder> GetConfectioneryItemsForOrder(ClientOrder order) {
            var result = from item in DbContext.Confectionery_ClientOrder
                         where item.IdClientOrder == order.IdClientOrder
                         select item;
            return result;
        }

        public IEnumerable<ClientOrder> GetOrdersForClient(int IDClient) {
            var result = from order in DbContext.ClientOrder
                         where order.IdClient == IDClient
                         select order;
            return result;
        }

        public async Task UpdateOrderAsync(int IDOrder, ClientOrder NewOrder, IEnumerable<Confectionery> NewOrderItems) {
            var oldOrder = (from order in DbContext.ClientOrder
                         where order.IdClientOrder == IDOrder
                         select order).Single();
            if (!(oldOrder.CompletionDate == null))
                throw new InvalidOperationException();
            if (!(NewOrderItems.Union(DbContext.Confectionery).Equals(DbContext.Confectionery)))
                throw new ArgumentException();
            oldOrder.OrderDate = NewOrder.OrderDate;
            oldOrder.CompletionDate = NewOrder.CompletionDate;
            oldOrder.Comments = NewOrder.Comments;
            oldOrder.IdClient = NewOrder.IdClient;
            oldOrder.IdEmployee = NewOrder.IdEmployee;
            await DbContext.SaveChangesAsync();
        }
    }
}
