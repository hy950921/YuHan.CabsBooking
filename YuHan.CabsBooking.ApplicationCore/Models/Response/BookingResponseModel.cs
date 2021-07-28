using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuHan.CabsBooking.ApplicationCore.Models.Response
{
    public class BookingResponseModel
    {
        public int Id { get; set; }
        public DateTime? BookingDate { get; set; }
        public string BookingTime { get; set; }
        public int? FromPlaceId { get; set; }
        public int? ToPlaceId { get; set; }
        public string PickUpAddress { get; set; }
        public DateTime? PickupDate { get; set; }
        public string PickupTime { get; set; }
        public int? CabTypeId { get; set; }
        public string Status { get; set; }
        public string PickUpCity { get; set; }
        public string DestinationCity { get; set; }
        public string CarMake { get; set; }

        public PlaceResponseModel FromPlace { get; set; }
        public PlaceResponseModel ToPlace { get; set; }
        public CabTypeResponseModel CabType { get; set; }
    }
}
