using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuHan.CabsBooking.ApplicationCore.Models.Request;
using YuHan.CabsBooking.ApplicationCore.Models.Response;

namespace YuHan.CabsBooking.ApplicationCore.ServiceInterfaces
{
    public interface IPlaceService
    {
        Task<IEnumerable<PlaceResponseModel>> ListAll();
        Task<PlaceResponseModel> Update(PlaceUpdateRequestModel model);
        Task<PlaceResponseModel> Add(PlaceAddRequestModel model);
        Task<PlaceResponseModel> Delete(int id);
        Task<PlaceResponseModel> GetById(int id);
    }
}
