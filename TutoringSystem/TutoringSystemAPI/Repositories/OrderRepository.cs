using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public ICollection<AdditionalOrder> GetOrders() => dbContext.AdditionalOrders
            .Include(o => o.Tutor)
            .ToList();

        public ICollection<AdditionalOrder> GetOrders(Tutor tutor) => GetOrders()
                .Where(o => o.Tutor.Equals(tutor))
                .ToList();

        public AdditionalOrder GetOrder(int id) => GetOrders()
            .FirstOrDefault(o => o.Id.Equals(id));
        
        public AdditionalOrder GetOrder(int id, Tutor tutor) => GetOrders()
                .FirstOrDefault(o => o.Id.Equals(id) && o.Tutor.Equals(tutor));
        
        public void CreateOrder(AdditionalOrder order)
        {
            dbContext.AdditionalOrders.Add(order);
            dbContext.SaveChanges();
        }

        public void UpdateOrder(int id, AdditionalOrder newOrder)
        {
            var order = GetOrder(id);

            order.Cost = newOrder.Cost;
            order.Deadline = newOrder.Deadline;
            order.Description = newOrder.Description;
            order.Name = newOrder.Name;

            dbContext.AdditionalOrders.Update(order);
            dbContext.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            var order = GetOrder(id);

            dbContext.AdditionalOrders.Remove(order);
            dbContext.SaveChanges();
        }
    }
}
