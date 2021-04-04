using System.Collections.Generic;
using TutoringSystemLib.Entities;

namespace TutoringSystemAPI.Repositories
{
    public interface IContactRepository
    {
        Contact GetContact(int id);
        Contact GetContact(User user);
        ICollection<Contact> GetContacts();
        void UpdateContact(Contact oldContact, Contact newContact);
    }
}