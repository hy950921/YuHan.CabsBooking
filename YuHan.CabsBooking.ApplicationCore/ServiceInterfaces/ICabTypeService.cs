using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuHan.CabsBooking.ApplicationCore.Models.Request;
using YuHan.CabsBooking.ApplicationCore.Models.Response;

namespace YuHan.CabsBooking.ApplicationCore.ServiceInterfaces
{
    public interface ICabTypeService
    {
        Task<IEnumerable<CabTypeResponseModel>> ListAll();
        Task<CabTypeResponseModel> Update(CabTypeUpdateRequestModel model);
        Task<CabTypeResponseModel> Add(CabTypeAddRequestModel model);
        Task<CabTypeResponseModel> Delete(int id);
        Task<CabTypeResponseModel> GetById(int id);
    }
}
