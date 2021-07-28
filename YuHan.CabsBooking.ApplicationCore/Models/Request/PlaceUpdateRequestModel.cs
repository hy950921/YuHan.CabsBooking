using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuHan.CabsBooking.ApplicationCore.Models.Request
{
    public class PlaceUpdateRequestModel
    {
        [Required]
        [MaxLength(30)]
        public string PlaceName { get; set; }

        [Required]
        public int PlaceId { get; set; }
    }
}
