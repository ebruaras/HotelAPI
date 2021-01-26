using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Hotel.Entities;

namespace Hotel.DataAccess
{
    //EF CODE FIRST
   public class HotelDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=WISGNDT024; Database=HotelDB; trusted_connection=true;");
        }

        public DbSet<Hotel.Entities.Hotel> Hotels { get; set; }
    }
}
