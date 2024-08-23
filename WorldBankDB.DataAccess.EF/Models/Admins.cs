using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WorldBankDB.DataAccess.EF.Models
{
    public partial class Admins
    {
        public Guid AdminId { get; set; }
        public string? AdminUser { get; set; }
        public string? AdminEmail { get; set; }
        public string? AdminPassword { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public bool IsManager { get; set; }

        public Admins(Guid adminID, string user, string email, string pass, string first, string middle, string last, bool isManager) 
        {
            AdminId = adminID;
            AdminUser = user;
            AdminEmail = email;
            AdminPassword = pass;
            FirstName = first;
            MiddleName = middle;
            LastName = last;
            IsManager = isManager;
        }
        public Admins() { }
    }
}
