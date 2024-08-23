using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBankDB.DataAccess.EF.Repositories.Contract;
using WorldBankDB.DataAccess.EF.Context;
using WorldBankDB.DataAccess.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace WorldBankDB.DataAccess.EF.Repositories
{
    internal class AdminRepository: IAdminRepository
    {
        private WorldBankDBContext _context;
        public AdminRepository(WorldBankDBContext context) 
        {
            _context = context;
        }
        public async Task<Admins> CreateAdminAsync(Admins admin) 
        {
            if (admin != null) 
            {
                try
                {
                    await _context.AddAsync(admin);
                    await _context.SaveChangesAsync();
                    await _context.DisposeAsync();

                    return admin;
                }
                catch (Exception ex) 
                {
                    throw new InvalidOperationException($"Admin could not be created. Error: {ex.Message}");
                }
            }

            throw new InvalidOperationException("Invalid model data or empty.");
        }
        public async Task<Admins> UpdateAdminAsync(Admins admin) 
        {
            Admins updateAdmin = await _context.Admins.FindAsync(admin.AdminId);

            if (updateAdmin != null)
            {
                try {
                    updateAdmin.AdminUser = updateAdmin.AdminUser;
                    updateAdmin.AdminPassword = updateAdmin.AdminPassword;
                    updateAdmin.AdminEmail = updateAdmin.AdminEmail;
                    updateAdmin.FirstName = updateAdmin.FirstName;
                    updateAdmin.LastName = updateAdmin.LastName;
                    updateAdmin.MiddleName = updateAdmin.MiddleName;
                    updateAdmin.IsManager = updateAdmin.IsManager;

                    await _context.SaveChangesAsync();
                    await _context.DisposeAsync();

                    return updateAdmin;
                }
                catch (Exception ex) 
                {
                    throw new InvalidOperationException($"User could not be updated: Error: {ex.Message}");
                }
            }

            throw new InvalidOperationException($"Could not find admin of id: {admin.AdminId}");
        }
        public async Task<Admins> GetAdminByIdAsync(Guid adminID) 
        {
            Admins getAdmin = await _context.Admins.FindAsync(adminID);

            await _context.DisposeAsync();

            if (getAdmin != null)
                return getAdmin;
            else
                throw new InvalidOperationException("Could not retrieve admin.");
        }
        public async Task<List<Admins>> GetAllAdminsAsync() 
        {
            List<Admins> adminList = await _context.Admins.ToListAsync();

            await _context.DisposeAsync();

            if (adminList != null)
                return adminList;
            else 
                throw new InvalidOperationException("");
        }
        public async Task<bool> DeleteAdminAsync(Admins admin)
        {
            Admins delAdmin = await _context.Admins.FindAsync(admin.AdminId);

            if (delAdmin != null) 
            {
                try
                {
                    _context.Remove(delAdmin);

                    await _context.SaveChangesAsync();
                    await _context.DisposeAsync();

                    return true;
                }
                catch (Exception ex) 
                {
                    throw new InvalidOperationException($"Could not delete account successfully. Error: {ex.Message}");
                }
            }

            throw new InvalidOperationException("Could not find user to delete");
        }
    }
}
