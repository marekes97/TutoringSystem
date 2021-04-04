using System.Collections.Generic;
using TutoringSystemLib.Entities;

namespace TutoringSystemAPI.Repositories
{
    public interface IOrderRepository
    {
        void CreateOrder(AdditionalOrder order);
        void DeleteOrder(int id);
        AdditionalOrder GetOrder(int id, Tutor tutor);
        AdditionalOrder GetOrder(int id);
        ICollection<AdditionalOrder> GetOrders();
        ICollection<AdditionalOrder> GetOrders(Tutor tutor);
        void UpdateOrder(int id, AdditionalOrder newOrder);
    }
}