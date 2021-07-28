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
    public class BookingHistoryService : IBookingHistoryService
    {
        private readonly IBookingHistoryRepository _bookingHistoryRepository;
        private readonly IPlaceRepository _placeRepository;
        private readonly ICabTypeRepository _cabTypeRepository;

        public BookingHistoryService(IBookingHistoryRepository bookingHistoryRepository, IPlaceRepository placeRepository, ICabTypeRepository cabTypeRepository)
        {
            _bookingHistoryRepository = bookingHistoryRepository;
            _placeRepository = placeRepository;
            _cabTypeRepository = cabTypeRepository;
        }

        public async Task<BookingHistoryResponseModel> Add(BookingHistoryAddRequestModel model)
        {
            var fromPlace = await _placeRepository.GetPlaceByIdAsync(model.FromPlaceId);
            if (fromPlace == null)
            {
                throw new Exception("Pick up place is invalid");
            }
            var toPlace = await _placeRepository.GetPlaceByIdAsync(model.ToPlaceId);
            if (toPlace == null)
            {
                throw new Exception("Drop off place is invalid");
            }
            var cab = await _cabTypeRepository.GetCabByIdAsync(model.CabTypeId);
            if (cab == null)
            {
                throw new Exception("CabType is invalid");
            }
            //var compeletedBooking = await _bookingRepository.IsBookingCompleted()

            var bookingHistoryEntity = new BookingHistory
            {
                Email = model.Email,
                BookingDate = DateTime.Now,
                BookingTime = model.BookingTime,
                Landmark = model.Landmark,
                PickupDate = model.PickupDate,
                PickupTime = model.PickupTime,
                CabTypeId = cab.CabTypeId,
                ContactNo = model.ContactNo,
                Status = model.Status,
                FromPlaceId = fromPlace.PlaceId,
                ToPlaceId = toPlace.PlaceId,
                PickUpAddress = model.PickUpAddress,
                CompTime = model.CompTime,
                Charge = model.Charge,
                Feedback = model.Feedback
            };

            var addedBookingHistory = await _bookingHistoryRepository.AddAsync(bookingHistoryEntity);
            var res = new BookingHistoryResponseModel
            {
                Id = addedBookingHistory.Id,
                BookingDate = addedBookingHistory.BookingDate,
                BookingTime = addedBookingHistory.BookingTime,
                PickupDate = addedBookingHistory.PickupDate,
                PickupTime = addedBookingHistory.PickupTime,
                CabTypeId = addedBookingHistory.CabTypeId,
                Status = addedBookingHistory.Status,
                FromPlaceId = addedBookingHistory.FromPlaceId,
                ToPlaceId = addedBookingHistory.ToPlaceId,
                PickUpAddress = addedBookingHistory.PickUpAddress,
                PickUpCity = addedBookingHistory.FromPlace.PlaceName,
                DestinationCity = addedBookingHistory.ToPlace.PlaceName,
                CarMake = addedBookingHistory.CabType.CabTypeName,
                CompTime = addedBookingHistory.CompTime,
                Charge = addedBookingHistory.Charge,
                Feedback = addedBookingHistory.Feedback
            };
            return res;
        }

        public async Task<BookingHistoryResponseModel> Delete(int id)
        {
            var bookingHistory = await _bookingHistoryRepository.GetByIdAsync(id);
            if (bookingHistory == null)
            {
                throw new Exception("Booking ID is invalid");
            }

            var deleted = await _bookingHistoryRepository.DeleteAsync(bookingHistory);
            var res = new BookingHistoryResponseModel
            {
                Id = deleted.Id,
                BookingDate = deleted.BookingDate,
                BookingTime = deleted.BookingTime,
                PickupDate = deleted.PickupDate,
                PickupTime = deleted.PickupTime,
                CabTypeId = deleted.CabTypeId,
                Status = deleted.Status,
                FromPlaceId = deleted.FromPlaceId,
                ToPlaceId = deleted.ToPlaceId,
                PickUpAddress = deleted.PickUpAddress,
                CompTime = deleted.CompTime,
                Charge = deleted.Charge,
                Feedback = deleted.Feedback
            };

            return res;
        }

        public async Task<IEnumerable<BookingHistoryResponseModel>> ListAll()
        {
            var bookingHistories = await _bookingHistoryRepository.ListAllAsync();

            var res = new List<BookingHistoryResponseModel>();

            foreach (var bh in bookingHistories)
            {
                res.Add(new BookingHistoryResponseModel
                {
                    Id = bh.Id,
                    BookingDate = bh.BookingDate,
                    BookingTime = bh.BookingTime,
                    FromPlaceId = bh.FromPlaceId,
                    ToPlaceId = bh.ToPlaceId,
                    PickUpAddress = bh.PickUpAddress,
                    PickupDate = bh.PickupDate,
                    PickupTime = bh.PickupTime,
                    CabTypeId = bh.CabTypeId,
                    Status = bh.Status,
                    CompTime = bh.CompTime,
                    Charge = bh.Charge,
                    Feedback = bh.Feedback,
                    PickUpCity = bh.FromPlace.PlaceName,
                    DestinationCity = bh.ToPlace.PlaceName,
                    CarMake = bh.CabType.CabTypeName
                    //FromPlace = new PlaceResponseModel { PlaceId = bh.FromPlace.PlaceId, PlaceName = bh.FromPlace.PlaceName },

                });
            }
            return res;
        }

        public async Task<BookingHistoryResponseModel> Update(BookingHistoryUpdateRequestModel model)
        {
            var bookingHistoryEntity = await _bookingHistoryRepository.GetByIdAsync(model.Id);
            if (bookingHistoryEntity == null)
            {
                throw new Exception("Booking History ID does not exist");
            }
            var fromPlace = await _placeRepository.GetPlaceByIdAsync(model.FromPlaceId);
            if (fromPlace == null)
            {
                throw new Exception("Pick up place is invalid");
            }
            var toPlace = await _placeRepository.GetPlaceByIdAsync(model.ToPlaceId);
            if (toPlace == null)
            {
                throw new Exception("Drop off place is invalid");
            }
            var cab = await _cabTypeRepository.GetCabByIdAsync(model.CabTypeId);
            if (cab == null)
            {
                throw new Exception("CabType is invalid");
            }
            //var compeletedBooking = await _bookingRepository.IsBookingCompleted()

            bookingHistoryEntity.Email = model.Email;
            bookingHistoryEntity.BookingDate = DateTime.Now;
            bookingHistoryEntity.BookingTime = model.BookingTime;
            bookingHistoryEntity.Landmark = model.Landmark;
            bookingHistoryEntity.PickupDate = model.PickupDate;
            bookingHistoryEntity.PickupTime = model.PickupTime;
            bookingHistoryEntity.CabTypeId = cab.CabTypeId;
            bookingHistoryEntity.ContactNo = model.ContactNo;
            bookingHistoryEntity.Status = model.Status;
            bookingHistoryEntity.FromPlaceId = fromPlace.PlaceId;
            bookingHistoryEntity.ToPlaceId = toPlace.PlaceId;
            bookingHistoryEntity.PickUpAddress = model.PickUpAddress;
            bookingHistoryEntity.CompTime = model.CompTime;
            bookingHistoryEntity.Charge = model.Charge;
            bookingHistoryEntity.Feedback = model.Feedback;

            var addedBookingHistory = await _bookingHistoryRepository.UpdateAsync(bookingHistoryEntity);
            var res = new BookingHistoryResponseModel
            {
                Id = addedBookingHistory.Id,
                BookingDate = addedBookingHistory.BookingDate,
                BookingTime = addedBookingHistory.BookingTime,
                PickupDate = addedBookingHistory.PickupDate,
                PickupTime = addedBookingHistory.PickupTime,
                CabTypeId = addedBookingHistory.CabTypeId,
                Status = addedBookingHistory.Status,
                FromPlaceId = addedBookingHistory.FromPlaceId,
                ToPlaceId = addedBookingHistory.ToPlaceId,
                PickUpAddress = addedBookingHistory.PickUpAddress,
                PickUpCity = addedBookingHistory.FromPlace.PlaceName,
                DestinationCity = addedBookingHistory.ToPlace.PlaceName,
                CarMake = addedBookingHistory.CabType.CabTypeName,
                CompTime = addedBookingHistory.CompTime,
                Charge = addedBookingHistory.Charge,
                Feedback = addedBookingHistory.Feedback
            };
            return res;
        }
    }
}
