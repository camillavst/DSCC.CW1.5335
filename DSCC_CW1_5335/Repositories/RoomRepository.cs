using DSCC_CW1_5335.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSCC_CW1_5335.Repositories
{
    public class RoomRepository : IRoomRepository<Room>
    {
        private readonly MyContextDb _context;

        public RoomRepository(MyContextDb myContextDb)
        {
            _context = myContextDb;
        }


        public IQueryable<Room> GetAll()
        {
            return _context.Rooms;
        }

        public Room GetById(int id)
        {
            return _context.Rooms.SingleOrDefault(e => e.Id == id);
        }
        public void Create(Room entity)
        {
            _context.Rooms.Add(entity);
            _context.SaveChanges();
        }
        public Room Update(Room entity)
        {

            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }
        public Room Delete(int id)
        {
            Room room = GetById(id);
            _context.Rooms.Remove(room);
            _context.SaveChanges();
            return room;
        }

        private bool RoomExists(int id)
        {
            return _context.Rooms.Count(e => e.Id == id) > 0;
        }

    }
}
