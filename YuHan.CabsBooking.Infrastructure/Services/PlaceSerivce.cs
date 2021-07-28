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
    public class PlaceSerivce : IPlaceService
    {
        private readonly IPlaceRepository _placeRepository;

        public PlaceSerivce(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }

        public async Task<PlaceResponseModel> Add(PlaceAddRequestModel model)
        {
            var hasPlaceEntity = await _placeRepository.HasPlaceByNameAsync(model.PlaceName);

            if (hasPlaceEntity != null)
            {
                throw new Exception("Place exists");
            }
            var res = new PlaceResponseModel();

            var addedPlace = new Place { PlaceName = model.PlaceName };
            var place = await _placeRepository.AddAsync(addedPlace);
            res.PlaceId = place.PlaceId;
            res.PlaceName = place.PlaceName;

            return res;
        }

        public async Task<PlaceResponseModel> Delete(int id)
        {
            var place = await _placeRepository.GetByIdAsync(id);
            if (place == null)
            {
                throw new Exception("Place ID does not exist");
            }

            var res = new PlaceResponseModel();


            var deleted = await _placeRepository.DeleteAsync(place);
            res.PlaceName = deleted.PlaceName;
            res.PlaceId = deleted.PlaceId;

            return res;
        }

        public Task<PlaceResponseModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PlaceResponseModel>> ListAll()
        {
            var places = await _placeRepository.ListAllAsync();

            var res = new List<PlaceResponseModel>();
            foreach (var place in places)
            {
                res.Add(new PlaceResponseModel { PlaceId = place.PlaceId, PlaceName = place.PlaceName });
            }
            return res;
        }

        public async Task<PlaceResponseModel> Update(PlaceUpdateRequestModel model)
        {
            var place = await _placeRepository.HasPlaceByNameAsync(model.PlaceName);
            if (place != null)
            {
                throw new Exception("Place already exists");
            }
            place = await _placeRepository.GetByIdAsync(model.PlaceId);
            if (place == null)
            {
                throw new Exception("Place ID does not exist");
            }

            place.PlaceName = model.PlaceName;

            var updated = await _placeRepository.UpdateAsync(place);

            var res = new PlaceResponseModel { PlaceId = updated.PlaceId, PlaceName = updated.PlaceName };

            return res;
        }
    }
}
