using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuHan.CabsBooking.ApplicationCore.Entities;
using YuHan.CabsBooking.ApplicationCore.Models.Request;
using YuHan.CabsBooking.ApplicationCore.Models.Response;
using YuHan.CabsBooking.ApplicationCore.RepositoryInterfaces;
using YuHan.CabsBooking.ApplicationCore.ServiceInterfaces;

namespace YuHan.CabsBooking.Infrastructure.Services
{
    public class CabTypeService : ICabTypeService
    {
        private readonly ICabTypeRepository _cabTypeRepository;
        public CabTypeService(ICabTypeRepository cabTypeRepository)
        {
            _cabTypeRepository = cabTypeRepository;
        }
        public async Task<CabTypeResponseModel> Add(CabTypeAddRequestModel model)
        {
            var hasCabEntity = await _cabTypeRepository.HasCabTypeByNameAsync(model.CabTypeName);

            if (hasCabEntity != null)
            {
                throw new Exception("CabType exists");
            }
            var res = new CabTypeResponseModel();

            var addedCab = new CabType { CabTypeName = model.CabTypeName };
            var cabType = await _cabTypeRepository.AddAsync(addedCab);
            res.CabTypeId = cabType.CabTypeId;
            res.CabTypeName = cabType.CabTypeName;
            
            return res;

        }

        public async Task<CabTypeResponseModel> Delete(int id)
        {
            var cab = await _cabTypeRepository.GetByIdAsync(id);
            if (cab == null)
            {
                throw new Exception("CabType ID does not exist");
            }

            var res = new CabTypeResponseModel();
            
            
            var deleted = await _cabTypeRepository.DeleteAsync(cab);
            res.CabTypeId = deleted.CabTypeId;
            res.CabTypeName = deleted.CabTypeName;
            
            return res;
        }

        public async Task<CabTypeResponseModel> GetById(int id)
        {
            var cabEntity = await _cabTypeRepository.GetByIdAsync(id);
            if (cabEntity == null)
            {
                throw new Exception("NO CABTYPE");
            }
            return new CabTypeResponseModel { CabTypeId = cabEntity.CabTypeId, CabTypeName = cabEntity.CabTypeName };
        }

        public async Task<IEnumerable<CabTypeResponseModel>> ListAll()
        {
            var cabEntites = await _cabTypeRepository.ListAllAsync();

            var res = new List<CabTypeResponseModel>();
            foreach (var cab in cabEntites)
            {
                res.Add(new CabTypeResponseModel { CabTypeId = cab.CabTypeId, CabTypeName = cab.CabTypeName });
            }
            return res;
        }

        public async Task<CabTypeResponseModel> Update(CabTypeUpdateRequestModel model)
        {
            var cabType = await _cabTypeRepository.HasCabTypeByNameAsync(model.CabTypeName);
            if (cabType != null)
            {
                throw new Exception("CabType already exists");
            }
            cabType = await _cabTypeRepository.GetByIdAsync(model.CabTypeId);
            if (cabType == null)
            {
                throw new Exception("CabType ID does not exist");
            }

            cabType.CabTypeName = model.CabTypeName;

            var updated = await _cabTypeRepository.UpdateAsync(cabType);
            var res = new CabTypeResponseModel { CabTypeId = model.CabTypeId, CabTypeName = model.CabTypeName };

            return res;
        }
    }
}
