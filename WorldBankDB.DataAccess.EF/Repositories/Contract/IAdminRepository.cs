using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBankDB.DataAccess.EF.Models;

namespace WorldBankDB.DataAccess.EF.Repositories.Contract
{
    internal interface IAdminRepository
    {
        Task<Admins> CreateAdminAsync(Admins admin); //=> throw new NotImplementedException();
        Task<Admins> UpdateAdminAsync(Admins admin);
        Task<Admins> GetAdminByIdAsync(Guid adminID);
        Task<List<Admins>> GetAllAdminsAsync();
        Task<bool> DeleteAdminAsync(Admins admin);
    }
}
