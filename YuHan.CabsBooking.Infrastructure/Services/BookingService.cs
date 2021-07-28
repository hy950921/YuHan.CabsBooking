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
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IPlaceRepository _placeRepository;
        private readonly ICabTypeRepository _cabTypeRepository;

        public BookingService(IBookingRepository bookingRepository, IPlaceRepository placeRepository, ICabTypeRepository cabTypeRepository)
        {
            _bookingRepository = bookingRepository;
            _placeRepository = placeRepository;
            _cabTypeRepository = cabTypeRepository;
        }

        public async Task<BookingResponseModel> Add(BookingAddRequestModel model)
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
            var bookingEntity = new Booking
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
                PickUpAddress = model.PickUpAddress
            };

            var addedBooking = await _bookingRepository.AddAsync(bookingEntity);
            var res = new BookingResponseModel
            {
                Id = addedBooking.Id,
                BookingDate=addedBooking.BookingDate,
                BookingTime = addedBooking.BookingTime,
                PickupDate = addedBooking.PickupDate,
                PickupTime = addedBooking.PickupTime,
                CabTypeId = addedBooking.CabTypeId,
                Status = addedBooking.Status,
                FromPlaceId = addedBooking.FromPlaceId,
                ToPlaceId = addedBooking.ToPlaceId,
                PickUpAddress = addedBooking.PickUpAddress,
                PickUpCity = addedBooking.FromPlace.PlaceName,
                DestinationCity = addedBooking.ToPlace.PlaceName,
                CarMake = addedBooking.CabType.CabTypeName
                //FromPlace = new PlaceResponseModel { PlaceId = addedBooking.FromPlace.PlaceId, PlaceName = addedBooking.FromPlace.PlaceName },
                //ToPlace = new PlaceResponseModel { PlaceId = addedBooking.ToPlace.PlaceId, PlaceName = addedBooking.ToPlace.PlaceName },
                //CabType = new CabTypeResponseModel { CabTypeId = addedBooking.CabType.CabTypeId, CabTypeName = addedBooking.CabType.CabTypeName }
            };
            return res;
        }

        public async Task<BookingResponseModel> Delete(int id)
        {
            var booking = await _bookingRepository.GetByIdAsync(id);
            if (booking == null)
            {
                throw new Exception("Booking ID is invalid");
            }

            var deleted = await _bookingRepository.DeleteAsync(booking);
            var res = new BookingResponseModel
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
                //PickUpCity = deleted.FromPlace.PlaceName == null ? " " : deleted.FromPlace.PlaceName,
                //DestinationCity = deleted.ToPlace.PlaceName == null ? " " : deleted.ToPlace.PlaceName,
                //CarMake = deleted.CabType.CabTypeName == null ? " " : deleted.CabType.CabTypeName
                //FromPlace = new PlaceResponseModel { PlaceId = deleted.FromPlace.PlaceId, PlaceName = deleted.FromPlace.PlaceName },
                //ToPlace = new PlaceResponseModel { PlaceId = deleted.ToPlace.PlaceId, PlaceName = deleted.ToPlace.PlaceName },
                //CabType = new CabTypeResponseModel { CabTypeId = deleted.CabType.CabTypeId, CabTypeName = deleted.CabType.CabTypeName }
            };

            return res;
        }

        

        public async Task<IEnumerable<BookingResponseModel>> ListAll()
        {
            var bookings = await _bookingRepository.ListAllAsync();

            var bookingResponses = new List<BookingResponseModel>();

            foreach (var booking in bookings)
            {
                bookingResponses.Add(new BookingResponseModel
                {
                    Id = booking.Id,
                    BookingDate = booking.BookingDate,
                    BookingTime = booking.BookingTime,
                    FromPlaceId = booking.FromPlaceId,
                    ToPlaceId = booking.ToPlaceId,
                    PickUpAddress = booking.PickUpAddress,
                    PickupDate = booking.PickupDate,
                    PickupTime = booking.PickupTime,
                    CabTypeId = booking.CabTypeId,
                    Status = booking.Status,
                    PickUpCity = booking.FromPlace.PlaceName,
                    DestinationCity = booking.ToPlace.PlaceName,
                    CarMake = booking.CabType.CabTypeName
                    //FromPlace = new PlaceResponseModel { PlaceId = booking.FromPlace.PlaceId, PlaceName = booking.FromPlace.PlaceName },
                    //ToPlace = new PlaceResponseModel { PlaceId = booking.ToPlace.PlaceId, PlaceName = booking.ToPlace.PlaceName },
                    //CabType = new CabTypeResponseModel { CabTypeId = booking.CabType.CabTypeId, CabTypeName = booking.CabType.CabTypeName }
                });
            }
            return bookingResponses;
        }

        public async Task<BookingResponseModel> Update(BookingUpdateRequestModel model)
        {
            var bookingEntity = await _bookingRepository.GetByIdAsync(model.Id);
            if (bookingEntity == null)
            {
                throw new Exception("Booking ID does not exist");
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
            bookingEntity.Email = model.Email;
            bookingEntity.BookingDate = DateTime.Now;
            bookingEntity.BookingTime = model.BookingTime;
            bookingEntity.Landmark = model.Landmark;
            bookingEntity.PickupDate = model.PickupDate;
            bookingEntity.PickupTime = model.PickupTime;
            bookingEntity.CabTypeId = cab.CabTypeId;
            bookingEntity.ContactNo = model.ContactNo;
            bookingEntity.Status = model.Status;
            bookingEntity.FromPlaceId = fromPlace.PlaceId;
            bookingEntity.ToPlaceId = toPlace.PlaceId;
            bookingEntity.PickUpAddress = model.PickUpAddress;

            var updatedBooking = await _bookingRepository.UpdateAsync(bookingEntity);
            var res = new BookingResponseModel
            {

                Id = updatedBooking.Id,
                BookingDate = updatedBooking.BookingDate,
                BookingTime = updatedBooking.BookingTime,
                FromPlaceId = updatedBooking.FromPlaceId,
                ToPlaceId = updatedBooking.ToPlaceId,
                PickUpAddress = updatedBooking.PickUpAddress,
                PickupDate = updatedBooking.PickupDate,
                PickupTime = updatedBooking.PickupTime,
                CabTypeId = updatedBooking.CabTypeId,
                Status = updatedBooking.Status,
                PickUpCity = updatedBooking.FromPlace.PlaceName,
                DestinationCity = updatedBooking.ToPlace.PlaceName,
                CarMake = updatedBooking.CabType.CabTypeName
                //FromPlace = new PlaceResponseModel { PlaceId = updatedBooking.FromPlace.PlaceId, PlaceName = updatedBooking.FromPlace.PlaceName },
                //ToPlace = new PlaceResponseModel { PlaceId = updatedBooking.ToPlace.PlaceId, PlaceName = updatedBooking.ToPlace.PlaceName },
                //CabType = new CabTypeResponseModel { CabTypeId = updatedBooking.CabType.CabTypeId, CabTypeName = updatedBooking.CabType.CabTypeName }

            };
            return res;
        }

        public async Task<IEnumerable<BookingResponseModel>> GetBookingsByCabId(int id)
        {
            var cabs = await _cabTypeRepository.GetCabWithBookingsByIdAsync(id);

            var bookingsRes = new List<BookingResponseModel>();

            foreach (var booking in cabs.Bookings)
            {
                if (booking == null) continue;
                var res = new BookingResponseModel
                {
                    Id = booking.Id,
                    BookingDate = booking.BookingDate,
                    BookingTime = booking.BookingTime,
                    PickupDate = booking.PickupDate,
                    PickupTime = booking.PickupTime,
                    CabTypeId = booking.CabTypeId,
                    Status = booking.Status,
                    FromPlaceId = booking.FromPlaceId,
                    ToPlaceId = booking.ToPlaceId,
                    PickUpAddress = booking.PickUpAddress,
                    //FromPlace = new PlaceResponseModel { PlaceId = booking.FromPlace.PlaceId, PlaceName = booking.FromPlace.PlaceName },

                    ToPlace = new PlaceResponseModel { PlaceId = booking.ToPlace.PlaceId, PlaceName = booking.ToPlace.PlaceName },
                };
                var fp = await _placeRepository.GetPlaceByIdAsync(booking.FromPlaceId);
                var cab = await _cabTypeRepository.GetCabByIdAsync(booking.CabTypeId);
                res.FromPlace = new PlaceResponseModel { PlaceId = fp.PlaceId, PlaceName = fp.PlaceName };
                res.CarMake = cab.CabTypeName;
                bookingsRes.Add(res);

            }
            return bookingsRes;
        }
    }
}
