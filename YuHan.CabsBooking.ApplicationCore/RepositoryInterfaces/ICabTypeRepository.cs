using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuHan.CabsBooking.ApplicationCore.Entities;

namespace YuHan.CabsBooking.ApplicationCore.RepositoryInterfaces
{
    public interface ICabTypeRepository : IAsyncRepository<CabType>
    {
        Task<CabType> HasCabTypeByNameAsync(string name);
        Task<CabType> GetCabByIdAsync(int? id);

        Task<CabType> GetCabWithBookingsByIdAsync(int id);
    }
}
