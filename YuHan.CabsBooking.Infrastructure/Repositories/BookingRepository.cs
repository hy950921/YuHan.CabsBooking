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
    public class BookingRepository : EfRepository<Booking>, IBookingRepository
    {
        public BookingRepository(CabsBookingDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<IEnumerable<Booking>> ListAllAsync()
        {
            return await _dbContext.Bookings.Include(b => b.ToPlace).Include(b => b.FromPlace).Include(b => b.CabType).ToListAsync();
        }


        
    }
    
}
