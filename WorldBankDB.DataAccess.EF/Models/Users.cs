using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WorldBankDB.DataAccess.EF.Models
{
    public partial class Users
    {
        public Guid UserId { get; set; }
        public string? Username { get; set; }
        public string? EmailAddr { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public bool Status { get; set; }

        public Users(Guid userID, string user, string email,string pass, string first, string middle, string last, bool status) 
        {
            UserId = userID;
            Username = user;
            EmailAddr = email;
            Password = pass;
            FirstName = first;
            MiddleName = middle;
            LastName = last;
            Status = status;
        }
        public Users() { }
    }
}
