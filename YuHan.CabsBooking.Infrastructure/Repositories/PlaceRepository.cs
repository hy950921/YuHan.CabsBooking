using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuHan.CabsBooking.ApplicationCore.Entities;
using YuHan.CabsBooking.ApplicationCore.RepositoryInterfaces;
using YuHan.CabsBooking.Infrastructure.Data;

namespace YuHan.CabsBooking.Infrastructure.Repositories
{
    public class PlaceRepository : EfRepository<Place>, IPlaceRepository
    {
        public PlaceRepository(CabsBookingDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Place> HasPlaceByNameAsync(string placeName)
        {
            var res = await _dbContext.Places.FirstOrDefaultAsync(p => p.PlaceName == placeName);

            return res;
        }

        public async Task<Place> GetPlaceByIdAsync(int? id)
        {
            return await _dbContext.Places.FirstOrDefaultAsync(p => p.PlaceId == id);
        }
    }
}
