using DSCC_CW1_5335.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSCC_CW1_5335.Repositories
{
    public class RoomTypeRepository : IRoomRepository<RoomType>
    {
        private readonly MyContextDb _context;

        public RoomTypeRepository(MyContextDb myContextDb)
        {
            _context = myContextDb;
        }


        public void Create(RoomType entity)
        {
            throw new NotImplementedException();
        }

        public RoomType Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<RoomType> GetAll()
        {
            return _context.RoomTypes;
        }

        public RoomType GetById(int id)
        {
            return _context.RoomTypes.SingleOrDefault(e => e.Id == id);
        }

        public RoomType Update(RoomType entity)
        {
            throw new NotImplementedException();
        }
    }
}
