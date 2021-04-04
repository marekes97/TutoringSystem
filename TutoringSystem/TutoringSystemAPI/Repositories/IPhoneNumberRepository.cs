using System.Collections.Generic;
using TutoringSystemLib.Entities;

namespace TutoringSystemAPI.Repositories
{
    public interface IPhoneNumberRepository
    {
        PhoneNumber GetPhoneNumber(int id);
        ICollection<PhoneNumber> GetPhoneNumbers();
        void UpdatePhoneNumber(PhoneNumber oldPhoneNumber, PhoneNumber newPhoneNumber);
    }
}