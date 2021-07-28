using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuHan.CabsBooking.ApplicationCore.Models.Request;
using YuHan.CabsBooking.ApplicationCore.Models.Response;

namespace YuHan.CabsBooking.ApplicationCore.ServiceInterfaces
{
    public interface IBookingHistoryService
    {
        Task<IEnumerable<BookingHistoryResponseModel>> ListAll();
        Task<BookingHistoryResponseModel> Update(BookingHistoryUpdateRequestModel model);
        Task<BookingHistoryResponseModel> Add(BookingHistoryAddRequestModel model);
        Task<BookingHistoryResponseModel> Delete(int id);
    }
}
