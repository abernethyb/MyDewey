using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDewey.Models;
using MyDewey.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDewey.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {

        private readonly IItemRepository _itemRepository;
        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpGet()]
        public IActionResult GetAllItems()
        {
            List<Item> items = _itemRepository.GetAllItems();
                //auth for later
            //if (userProfile == null)
            //{
            //    return NotFound();
            //}
            return Ok(items);
        }

        [HttpPost]
        public IActionResult Post(Item item)
        {
            _itemRepository.Add(item);
            //For now...
            return Ok();
            //TODO:
            //Replace the above "return OK()" with the following returne statement after making a get by id method...
            //return CreatedAtAction("Get", new { id = item.Id }, item);
        }

    }
}
