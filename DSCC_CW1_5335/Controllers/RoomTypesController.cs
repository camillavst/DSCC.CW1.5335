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
    //[Route("api/RoomTypes")]
    [Route("api/[controller]")]
    public class RoomTypesController : Controller
    {
        private readonly IRoomRepository<RoomType> _roomTypeRepository;
        public RoomTypesController(IRoomRepository<RoomType> roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }


        // GET: api/RoomTypes
        [HttpGet]
        public IActionResult Get()
        {
            var roomTypes = _roomTypeRepository.GetAll();
            return new OkObjectResult(roomTypes);
        }
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

            // GET: api/RoomTypes/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var roomType = _roomTypeRepository.GetById(id);
            return new OkObjectResult(roomType);
            // return "value";
        }
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/RoomTypes
        [HttpPost]
        
            public IActionResult Post([FromBody]RoomType roomType)
            {
                using (var scope = new TransactionScope())
                {
                    _roomTypeRepository.Create(roomType); scope.Complete();
                    return CreatedAtAction(nameof(Get), new { id = roomType.Id }, roomType);
                }
            }
        
        
        // PUT: api/RoomTypes/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]RoomType roomType)
        {
            if (roomType != null)
            {
                using (var scope = new TransactionScope())
                {
                    _roomTypeRepository.Update(roomType); scope.Complete(); return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
     
          public IActionResult Delete(int id)
          {
              _roomTypeRepository.Delete(id);
              return new OkResult();
          }
        
    }
}
