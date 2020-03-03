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
    //[Route("api/RoomCategories")]
    [Route("api/[controller]")]
    public class RoomCategoriesController : Controller
    {
        private readonly IRoomRepository<RoomCategory> _roomCategoryRepository;
        public RoomCategoriesController(IRoomRepository<RoomCategory> roomCategoryRepository)
        {
            _roomCategoryRepository = roomCategoryRepository;
        }


        // GET: api/RoomCategories
        [HttpGet]
        public IActionResult Get()
        {
            var roomCategories = _roomCategoryRepository.GetAll();
            return new OkObjectResult(roomCategories);
            //return new string[] { "value1", "value2" };
        }

        // GET: api/RoomCategories/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var roomCategory = _roomCategoryRepository.GetById(id);
            return new OkObjectResult(roomCategory);
            // return "value";
        }

        // POST: api/RoomCategories
        [HttpPost]
        public IActionResult Post([FromBody]RoomCategory roomCategory)
        {
            using (var scope = new TransactionScope())
            {
                _roomCategoryRepository.Create(roomCategory); scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = roomCategory.Id }, roomCategory);
            }
        }

        // PUT: api/RoomCategories/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]RoomCategory roomCategory)
        {
            if (roomCategory != null)
            {
                using (var scope = new TransactionScope())
                {
                    _roomCategoryRepository.Update(roomCategory); scope.Complete(); return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _roomCategoryRepository.Delete(id);
            return new OkResult();
        }
    }
}
