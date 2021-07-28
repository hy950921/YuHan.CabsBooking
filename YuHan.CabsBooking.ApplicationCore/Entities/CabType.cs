using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuHan.CabsBooking.ApplicationCore.Entities
{
    public class CabType
    {
        public int CabTypeId { get; set; }
        public string CabTypeName { get; set; }

        // Navigation
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<BookingHistory> BookingHistories { get; set; }
        
    }
}
