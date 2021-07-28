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
    public class BookingHistoryRepository : EfRepository<BookingHistory>, IBookingHistoryRepository
    {
        public BookingHistoryRepository(CabsBookingDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<IEnumerable<BookingHistory>> ListAllAsync()
        {
            return await _dbContext.bookingHistories.Include(bh => bh.CabType).Include(bh => bh.ToPlace).Include(bh => bh.FromPlace).ToListAsync();
        }


    }
}
