using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuHan.CabsBooking.ApplicationCore.Entities
{
    public class Place
    {
        public int PlaceId { get; set; }
        public string PlaceName { get; set; }

        // Navigation
        public ICollection<BookingHistory> ToBookingHistories { get; set; }
        public ICollection<BookingHistory> FromBookingHistories { get; set; }
        public ICollection<Booking> ToBookings { get; set; }
        public ICollection<Booking> FromBookings { get; set; }
    }
}
