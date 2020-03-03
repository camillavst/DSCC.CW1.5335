using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSCC_CW1_5335.Model
{
    public class MyContextDb:DbContext
    {
        public MyContextDb(DbContextOptions<MyContextDb> options): base(options)
        {
        }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<RoomCategory> RoomCategories { get; set; }

        public DbSet<RoomType> RoomTypes { get; set; }      
    }
}

