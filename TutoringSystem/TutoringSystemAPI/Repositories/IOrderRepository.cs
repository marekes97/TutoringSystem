using System.Collections.Generic;
using TutoringSystemLib.Entities;

namespace TutoringSystemAPI.Repositories
{
    public interface IOrderRepository
    {
        void AddOrder(AdditionalOrder order);
        void DeleteOrder(int id);
        AdditionalOrder GetOrder(int id, Tutor tutor);
        ICollection<AdditionalOrder> GetOrders();
        ICollection<AdditionalOrder> GetOrders(Tutor tutor);
        void UpdateOrder(int id, AdditionalOrder newOrder);
    }
}