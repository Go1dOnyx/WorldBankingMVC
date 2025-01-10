using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WorldBankDB.DataAccess.EF.Models
{
    public partial class Addresses
    {
        public int AddressId { get; set; }
        public Guid UserId { get; set; } //Foreign Key
        public string? Street { get; set; }
        public string? Apt { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public int ZipCode { get; set; }

        //User
        public Users? User { get; set; } 

        public Addresses(int addrID, Guid userID, string street, string apt, string city, string country, int zip, Users user) 
        {
            AddressId = addrID;
            UserId = userID;
            Street = street;
            Apt = apt;
            City = city;
            Country = country;
            ZipCode = zip;
            User = user;
        }
        public Addresses() { }
    }
}
