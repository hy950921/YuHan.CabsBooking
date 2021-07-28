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
    public class CabTypeRepository : EfRepository<CabType>, ICabTypeRepository
    {
        public CabTypeRepository(CabsBookingDbContext dbContext) : base(dbContext)
        {
        }
        //public override async Task<IEnumerable<CabType>> ListAllAsync()
        //{
        //    return await _dbContext.Set<CabType>().ToListAsync();
        //}

        //public override async Task<CabType> GetByIdAsync(int id)
        //{
        //    return await _dbContext.Set<CabType>().FindAsync(id);
        //}

        public async Task<CabType> HasCabTypeByNameAsync(string name)
        {
            var cab = await _dbContext.CabTypes.FirstOrDefaultAsync(c => c.CabTypeName == name);
            return cab;
        }

        public async Task<bool> HasCabTypeByIdAsync(int id)
        {
            var res = await _dbContext.CabTypes.FirstOrDefaultAsync(c => c.CabTypeId == id);

            return res == null ? false : true;
        }

        public async Task<CabType> GetCabByIdAsync(int? id)
        {
            var cab = await _dbContext.CabTypes.FirstOrDefaultAsync(c => c.CabTypeId == id);
            return cab;
        }

        public async Task<CabType> GetCabWithBookingsByIdAsync(int id)
        {
            var cab = await _dbContext.CabTypes.Include(b => b.Bookings).ThenInclude(b => b.ToPlace).FirstOrDefaultAsync(c => c.CabTypeId == id);
            return cab;
        }

    }
}
