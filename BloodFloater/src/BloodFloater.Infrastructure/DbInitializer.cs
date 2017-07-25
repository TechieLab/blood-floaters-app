using System;
using System.Collections.Generic;
using System.Linq;
using BloodFloater.DAL;
using BloodFloater.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace BloodFloater.Infrastructure
{
    public static class DbInitializer
    {
        private static BloodFloaterContext _context;

        public static void Initialize(IServiceProvider serviceProvider, string imagesPath)
        {
            _context = (BloodFloaterContext)serviceProvider.GetService(typeof(BloodFloaterContext));

            _context.Database.EnsureCreated();

            InitializeLookups();
            InitializeUserRoles();

        }

        private static void InitializeLookups()
        {
            if (!_context.Lookups.Any())
            {
                List<Lookup> lookups = new List<Lookup>();

                var lookup1 = _context.Lookups.Add(
                    new Lookup
                    {
                        Key  = "country",
                        Value = "IND",
                        Name = "India",
                        Description = ""
                    }).Entity;
                var lookup2 = _context.Lookups.Add(
                    new Lookup
                    {
                        Key = "country",
                        Value = "IND",
                        Name = "India",
                        Description = ""
                    }).Entity;
                var lookup3 = _context.Lookups.Add(
                     new Lookup
                     {
                         Key = "country",
                         Value = "IND",
                         Name = "India",
                         Description = ""
                     }).Entity;
                var lookup4 = _context.Lookups.Add(
                     new Lookup
                     {
                         Key = "country",
                         Value = "IND",
                         Name = "India",
                         Description = ""
                     }).Entity;

                lookups.Add(lookup1); lookups.Add(lookup2); lookups.Add(lookup3); lookups.Add(lookup4);
              
                _context.SaveChanges();
            }
        }

        private static void InitializeUserRoles()
        {
            if (!_context.Roles.Any())
            {
                // create roles
                _context.Roles.AddRange(new Role[]
                {
                    new Role()
                    {
                        Name="Admin"
                    }
                });

                _context.SaveChanges();
            }

            if (!_context.Users.Any())
            {
                _context.Users.Add(new User()
                {
                    EmailId = "chsakells.blog@gmail.com",
                    UserName = "chsakell",
                    PhoneNumber = "65443434334",
                    HashedPassword = "9wsmLgYM5Gu4zA/BSpxK2GIBEWzqMPKs8wl2WDBzH/4=",
                    Salt = "GTtKxJA6xJuj3ifJtTXn9Q==",
                    IsLocked = false
                });

                // create user-admin for chsakell
                _context.UserRoles.AddRange(new UserRole[] {
                    new UserRole() {
                        RoleId = 1, // admin
                        UserId = 1  // chsakell
                    }
                });
                _context.SaveChanges();
            }
        }
    }
}
