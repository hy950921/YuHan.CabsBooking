using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuHan.CabsBooking.ApplicationCore.Models.Request
{
    public class BookingUpdateRequestModel
    {
        [Required]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }
        public DateTime? BookingDate { get; set; }
        [MaxLength(5)]
        public string BookingTime { get; set; }
        public int? FromPlaceId { get; set; }
        public int? ToPlaceId { get; set; }
        [MaxLength(200)]
        public string PickUpAddress { get; set; }
        [MaxLength(30)]
        public string Landmark { get; set; }
        public DateTime? PickupDate { get; set; }
        [MaxLength(5)]
        public string PickupTime { get; set; }
        public int? CabTypeId { get; set; }
        [MaxLength(25)]
        public string ContactNo { get; set; }
        [MaxLength(30)]
        public string Status { get; set; }
    }
}
