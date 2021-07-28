using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuHan.CabsBooking.ApplicationCore.Entities;

namespace YuHan.CabsBooking.ApplicationCore.RepositoryInterfaces
{
    public interface IBookingHistoryRepository : IAsyncRepository<BookingHistory>
    {
    }
}
