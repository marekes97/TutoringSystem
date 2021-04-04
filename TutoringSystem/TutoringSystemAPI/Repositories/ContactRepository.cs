using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TutoringSystemLib.Entities;

namespace TutoringSystemAPI.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext dbContext;
        private readonly IPhoneNumberRepository phoneNumberRepo;

        public ContactRepository(AppDbContext dbContext, IPhoneNumberRepository phoneNumberRepo)
        {
            this.dbContext = dbContext;
            this.phoneNumberRepo = phoneNumberRepo;
        }

        public ICollection<Contact> GetContacts() => dbContext.Contacts
            .Include(c => c.User)
            .Include(c => c.PhoneNumbers)
            .ToList();

        public Contact GetContact(int id) => GetContacts()
            .FirstOrDefault(c => c.Id.Equals(id));

        public Contact GetContact(User user) => GetContacts()
            .FirstOrDefault(c => c.User.Equals(user));

        public void UpdateContact(Contact oldContact, Contact newContact)
        {
            oldContact.DiscordName = newContact.DiscordName;
            oldContact.Email = newContact.Email;

            for (int i = 0; i < oldContact.PhoneNumbers.Count; i++)
                phoneNumberRepo.UpdatePhoneNumber(oldContact.PhoneNumbers[i], newContact.PhoneNumbers[i]);

            if(newContact.PhoneNumbers.Count > oldContact.PhoneNumbers.Count)
                for (int i = oldContact.PhoneNumbers.Count; i < newContact.PhoneNumbers.Count; i++)
                    oldContact.PhoneNumbers.Add(newContact.PhoneNumbers[i]);

            dbContext.Contacts.Update(oldContact);
            dbContext.SaveChanges();
        }
    }
}
