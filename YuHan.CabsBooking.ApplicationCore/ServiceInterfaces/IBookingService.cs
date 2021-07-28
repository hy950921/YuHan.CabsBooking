using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuHan.CabsBooking.ApplicationCore.Models.Request;
using YuHan.CabsBooking.ApplicationCore.Models.Response;

namespace YuHan.CabsBooking.ApplicationCore.ServiceInterfaces
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingResponseModel>> ListAll();
        Task<BookingResponseModel> Update(BookingUpdateRequestModel model);
        Task<BookingResponseModel> Add(BookingAddRequestModel model);
        Task<BookingResponseModel> Delete(int id);
        Task<IEnumerable<BookingResponseModel>>  GetBookingsByCabId(int id);

        //Task<bool> IsBookingCompleted(BookingResponseModel model);
    }
}
