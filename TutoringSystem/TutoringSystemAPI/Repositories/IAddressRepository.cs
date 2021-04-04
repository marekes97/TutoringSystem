using System.Collections.Generic;
using TutoringSystemLib.Entities;

namespace TutoringSystemAPI.Repositories
{
    public interface IAddressRepository
    {
        Address GetAddress(int id);
        Address GetAddress(Student student);
        ICollection<Address> GetAddresses();
        void UpdateAddress(Address oldAddress, Address newAddress);
    }
}