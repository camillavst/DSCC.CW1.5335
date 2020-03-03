using DSCC_CW1_5335.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSCC_CW1_5335.Repositories
{
    public class RoomCategoryRepository : IRoomRepository<RoomCategory>
    {
        private readonly MyContextDb _context;

        public RoomCategoryRepository(MyContextDb myContextDb)
        {
            _context = myContextDb;
        }


        public void Create(RoomCategory entity)
        {
            throw new NotImplementedException();
        }

        public RoomCategory Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<RoomCategory> GetAll()
        {
            return _context.RoomCategories;
        }

        public RoomCategory GetById(int id)
        {
            return _context.RoomCategories.SingleOrDefault(e => e.Id == id);
        }

        public RoomCategory Update(RoomCategory entity)
        {
            throw new NotImplementedException();
        }
    }
}
