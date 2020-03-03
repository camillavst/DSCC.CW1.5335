using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using DSCC_CW1_5335.Model;
using DSCC_CW1_5335.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSCC_CW1_5335.Controllers
{
    [Produces("application/json")]
    //[Route("api/Rooms")]
    [Route("api/[controller]")]
    public class RoomsController : Controller
    {
        private readonly IRoomRepository<Room> _roomRepository;
        public RoomsController(IRoomRepository<Room> roomRepository)
        {
            _roomRepository = roomRepository;
        }
        // GET: api/Rooms
        [HttpGet]
        public IActionResult Get()
        //public IEnumerable<string> Get()
        {
            var rooms = _roomRepository.GetAll();
            return new OkObjectResult(rooms);
            //return new string[] { "value1", "value2" };
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var room = _roomRepository.GetById(id);
            return new OkObjectResult(room);
            // return "value";
        }
        
        // POST: api/Rooms
        [HttpPost]
        public IActionResult Post([FromBody]Room room)
        {
            _roomRepository.Create(room);
            return CreatedAtAction(nameof(Get), new { id = room.Id }, room);
            /*using (var scope = new TransactionScope())
            {
                _roomRepository.Create(room); scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = room.Id }, room);
            }*/
        }
        
        // PUT: api/Rooms/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Room room)
        {
            if (room != null) { 
            {
               _roomRepository.Update(room);
               return new OkObjectResult(room);
            }
        }
            return new NoContentResult();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var room = _roomRepository.Delete(id);
            return new  OkObjectResult(room);
        }
    }
}
