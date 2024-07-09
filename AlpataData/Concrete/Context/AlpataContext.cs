﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpataData.Concrete.Context
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Core.Entities.Concrete;
    using AlpataEntities.Concrete;
    using AlpataCore.Entities.Concrete;

    namespace DataAccess.Concrete.EntityFramework.Contexts
    {
        public class AlpataContext : DbContext
        {
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");
            }

            public DbSet<Meeting> Meetgies { get; set; }
            public DbSet<OperationClaim> OperationClaims { get; set; }
            public DbSet<User> Users { get; set; }
            public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        }
    }
}
