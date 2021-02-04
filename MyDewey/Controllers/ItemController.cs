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

        [HttpGet("NonUserItems")]
        public IActionResult GetNonUserItems()
        {
            var currentUserProfile = GetCurrentUserProfile();
            int userProfileId = currentUserProfile.Id;
            List<Item> items = _itemRepository.GetNonUserItems(userProfileId);
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
            var currentUserProfile = GetCurrentUserProfile();
            item.UserProfileId = currentUserProfile.Id;
            _itemRepository.Add(item);
            //For now...
            return Ok();
            //TODO:
            //Replace the above "return OK()" with the following returne statement after making a get by id method...
            //return CreatedAtAction("Get", new { id = item.Id }, item);
        }

        //Checkout handling //

        [HttpPost("requestCheckout/{itemId}")]
        public IActionResult RequestCheckout(int itemId)
        {
            var currentUserProfile = GetCurrentUserProfile();

            _itemRepository.RequestCheckout(currentUserProfile.Id, itemId);
            //For now...
            return Ok();
            //TODO:
            //Replace the above "return OK()" with the following returne statement after making a get by id method...
            //return CreatedAtAction("Get", new { id = item.Id }, item);
        }
        [HttpGet("CheckoutRequests")]
        public IActionResult GetCheckoutRequests()
        {
            var currentUserProfile = GetCurrentUserProfile();
            int userProfileId = currentUserProfile.Id;
            List<Request> requests = _itemRepository.GetCheckoutRequests(userProfileId);
            //auth for later
            //if (userProfile == null)
            //{
            //    return NotFound();
            //}
            return Ok(requests);
        }

        [HttpGet("LenderViewCheckout")]
        public IActionResult GetLenderViewCheckout()
        {
            var currentUserProfile = GetCurrentUserProfile();
            int userProfileId = currentUserProfile.Id;
            List<LenderCheckoutView> lenderCheckoutView = _itemRepository.GetLenderViewCheckout(userProfileId);
            //auth for later
            //if (userProfile == null)
            //{
            //    return NotFound();
            //}
            return Ok(lenderCheckoutView);
        }

        [HttpGet("BorrowerViewCheckout")]
        public IActionResult GetBorrowerViewCheckout()
        {
            var currentUserProfile = GetCurrentUserProfile();
            int userProfileId = currentUserProfile.Id;
            List<BorrowerCheckoutView> borrowerCheckoutViews = _itemRepository.GetBorrowerViewCheckout(userProfileId);
            //auth for later
            //if (userProfile == null)
            //{
            //    return NotFound();
            //}
            return Ok(borrowerCheckoutViews);
        }
        [HttpPost("AddToCheckoutQueue/{checkoutId}")]
        public IActionResult AddToCheckoutQueue(int checkoutId)
        {
            //var currentUserProfile = GetCurrentUserProfile();

            _itemRepository.AddToCheckoutQueue(checkoutId);
            //For now...
            return Ok();
            //TODO:
            //Replace the above "return OK()" with the following returne statement after making a get by id method...
            //return CreatedAtAction("Get", new { id = item.Id }, item);
        }
        [HttpPost("RemoveFromCheckoutQueue/{checkoutId}")]
        public IActionResult RemoveFromCheckoutQueue(int checkoutId)
        {
            //var currentUserProfile = GetCurrentUserProfile();

            _itemRepository.RemoveFromCheckoutQueue(checkoutId);
            //For now...
            return Ok();
            //TODO:
            //Replace the above "return OK()" with the following returne statement after making a get by id method...
            //return CreatedAtAction("Get", new { id = item.Id }, item);
        }

        [HttpPost("Checkin/{checkoutId}")]
        public IActionResult Checkin(int checkoutId)
        {
            //var currentUserProfile = GetCurrentUserProfile();

            _itemRepository.Checkin(checkoutId);
            //For now...
            return Ok();
            //TODO:
            //Replace the above "return OK()" with the following returne statement after making a get by id method...
            //return CreatedAtAction("Get", new { id = item.Id }, item);
        }

        [HttpPost("ApproveCheckout/{checkoutId}/{itemId}")]
        public IActionResult ApproveCheckout(int checkoutId, int itemId)
        {
            //var currentUserProfile = GetCurrentUserProfile();

            _itemRepository.ApproveCheckout(checkoutId, itemId);
            //For now...
            return Ok();
            //TODO:
            //Replace the above "return OK()" with the following returne statement after making a get by id method...
            //return CreatedAtAction("Get", new { id = item.Id }, item);
        }

        [HttpPost("VerifyCheckin/{checkoutId}/{itemId}")]
        public IActionResult VerifyCheckin(int checkoutId, int itemId)
        {
            //var currentUserProfile = GetCurrentUserProfile();

            _itemRepository.VerifyCheckin(checkoutId, itemId);
            //For now...
            return Ok();
            //TODO:
            //Replace the above "return OK()" with the following returne statement after making a get by id method...
            //return CreatedAtAction("Get", new { id = item.Id }, item);
        }


        //get current user profile
        private UserProfile GetCurrentUserProfile()
        {
            var firebaseId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _userProfileRepository.GetByFirebaseId(firebaseId);
        }

    }
}
