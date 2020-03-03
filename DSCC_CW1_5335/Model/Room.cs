using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DSCC_CW1_5335.Model
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        public byte[] RoomPhoto { get; set; }

        [Required]
        public string RoomSize { get; set; }


        public int RoomCategoryId { get; set; }

        public int RoomTypeId { get; set; }
       


        public virtual RoomCategory RoomCategory { get; set; }
        public virtual RoomType RoomType { get; set; }

    }
}
