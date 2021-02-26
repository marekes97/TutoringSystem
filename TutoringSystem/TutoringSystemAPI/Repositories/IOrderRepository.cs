using System.Collections.Generic;
using TutoringSystemLib.Entities;

namespace TutoringSystemAPI.Repositories
{
    public interface IOrderRepository
    {
        void AddOrder(AdditionalOrder order);
        void DeleteOrder(int id);
        AdditionalOrder GetOrder(int id);
        ICollection<AdditionalOrder> GetOrders();
        void UpdateOrder(int id, AdditionalOrder newOrder);
    }
}