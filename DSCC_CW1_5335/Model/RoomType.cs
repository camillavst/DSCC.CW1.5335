using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DSCC_CW1_5335.Model
{
    public class RoomType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TypeName { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
