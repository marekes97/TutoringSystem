using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringSystemLib.Entities;

namespace TutoringSystemAPI.Repositories
{
    public class PhoneNumberRepository : IPhoneNumberRepository
    {
        private readonly AppDbContext dbContext;

        public PhoneNumberRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ICollection<PhoneNumber> GetPhoneNumbers() => dbContext.PhoneNumbers
            .Include(p => p.Contact)
            .ToList();

        public PhoneNumber GetPhoneNumber(int id) => GetPhoneNumbers()
            .FirstOrDefault(p => p.Id.Equals(id));

        public void UpdatePhoneNumber(PhoneNumber oldPhoneNumber, PhoneNumber newPhoneNumber)
        {
            oldPhoneNumber.Number = newPhoneNumber.Number;
            oldPhoneNumber.Owner = newPhoneNumber.Owner;

            dbContext.PhoneNumbers.Update(oldPhoneNumber);
            dbContext.SaveChanges();
        }
    }
}
