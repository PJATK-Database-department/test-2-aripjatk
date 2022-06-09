using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test2.Models;

namespace Test2 {
    public class OrdersDbContext : DbContext {
        public OrdersDbContext(DbContextOptions opts) : base(opts) { }
        public DbSet<Confectionery> Confectionery { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<ClientOrder> ClientOrder { get; set; }
        public DbSet<Confectionery_ClientOrder> Confectionery_ClientOrder { get; set; }
        public DbSet<Employee> Employee { get; set; }
    }
}
