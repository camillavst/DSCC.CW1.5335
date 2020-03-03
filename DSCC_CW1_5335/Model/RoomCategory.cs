using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSCC_CW1_5335.Model
{
    public class RoomCategory
    {    
            public int Id { get; set; }
            public string CategoryName { get; set; }

            public virtual ICollection<Room> Rooms { get; set; }
        
    }
}
