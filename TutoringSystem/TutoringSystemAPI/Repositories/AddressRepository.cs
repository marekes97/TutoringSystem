using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TutoringSystemLib.Entities;

namespace TutoringSystemAPI.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        public readonly AppDbContext dbContext;

        public AddressRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ICollection<Address> GetAddresses() => dbContext.Addresses
            .Include(a => a.User)
            .ToList();

        public Address GetAddress(int id) => GetAddresses()
            .FirstOrDefault(a => a.Id.Equals(id));

        public Address GetAddress(Student student) => GetAddresses()
            .FirstOrDefault(a => a.User.Equals(student));

        public void UpdateAddress(Address oldAddress, Address newAddress)
        {
            oldAddress.City = newAddress.City;
            oldAddress.PostalCode = newAddress.PostalCode;
            oldAddress.Street = newAddress.Street;

            dbContext.Addresses.Update(oldAddress);
            dbContext.SaveChanges();
        }
    }
}
