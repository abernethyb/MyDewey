using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDewey.Models;
using MyDewey.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyDewey.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {

        private readonly IItemRepository _itemRepository;
        private readonly IUserProfileRepository _userProfileRepository;
        public ItemController(IItemRepository itemRepository, IUserProfileRepository userProfileRepository)
        {
            _itemRepository = itemRepository;
            _userProfileRepository = userProfileRepository;
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
        
        [HttpGet("UserItems")]
        public IActionResult GetUserItems()
        {
            var currentUserProfile = GetCurrentUserProfile();
            int userProfileId = currentUserProfile.Id;
            List<Item> items = _itemRepository.GetUserItems(userProfileId);
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

        private UserProfile GetCurrentUserProfile()
        {
            var firebaseId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _userProfileRepository.GetByFirebaseId(firebaseId);
        }

    }
}
