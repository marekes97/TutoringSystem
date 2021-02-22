using System;
using System.Collections.Generic;
using System.Text;

namespace TutoringSystemLib.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Role Role { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual School School { get; set; }
        public virtual List<Reservation> Reservation { get; set; }
        public virtual List<AdditionalOrder> AdditionalOrders { get; set; }
    }
}
