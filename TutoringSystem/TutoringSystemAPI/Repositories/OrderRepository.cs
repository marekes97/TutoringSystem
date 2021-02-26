using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringSystemLib.Entities;

namespace TutoringSystemAPI.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext dbContext;

        public OrderRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ICollection<AdditionalOrder> GetOrders() => dbContext.AdditionalOrders.ToList();

        public AdditionalOrder GetOrder(int id)
        {
            return dbContext.AdditionalOrders
                .FirstOrDefault(o => o.Id.Equals(id));
        }

        public void AddOrder(AdditionalOrder order)
        {
            dbContext.AdditionalOrders.Add(order);
            dbContext.SaveChanges();
        }

        public void UpdateOrder(int id, AdditionalOrder newOrder)
        {
            var order = dbContext.AdditionalOrders
                .FirstOrDefault(o => o.Id.Equals(id));

            order.Cost = newOrder.Cost;
            order.Deadline = newOrder.Deadline;
            order.Description = newOrder.Description;
            order.Name = newOrder.Name;

            dbContext.AdditionalOrders.Update(order);
            dbContext.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            var order = dbContext.AdditionalOrders
                .FirstOrDefault(o => o.Id.Equals(id));

            dbContext.AdditionalOrders.Remove(order);
            dbContext.SaveChanges();
        }
    }
}
