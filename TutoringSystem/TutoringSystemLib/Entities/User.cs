using System;
using System.Collections.Generic;
using System.Text;

namespace TutoringSystemLib.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhotoUrl { get; set; }
        public Role Role { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual School School { get; set; }
        public virtual Address Address { get; set; }
        public virtual List<Reservation> Reservations { get; set; }
        public virtual List<AdditionalOrder> AdditionalOrders { get; set; }
    }
}
