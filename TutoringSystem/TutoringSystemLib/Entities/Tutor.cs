﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TutoringSystemLib.Entities
{
    public class Tutor : User
    {
        public virtual List<AdditionalOrder> AdditionalOrders { get; set; }
        public virtual List<Reservation> Reservations { get; set; }
    }
}
