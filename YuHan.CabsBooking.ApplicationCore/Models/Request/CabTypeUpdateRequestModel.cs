using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuHan.CabsBooking.ApplicationCore.Models.Request
{
    public class CabTypeUpdateRequestModel
    {
        [Required]
        [MaxLength(30)]
        public string CabTypeName { get; set; }

        [Required]
        public int CabTypeId { get; set; }
    }
}
