﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDewey.Models;
using MyDewey.Repositories;

namespace MyDewey.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {

        private readonly IUserProfileRepository _userProfileRepository;
        public UserProfileController(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        [HttpGet("{FirebaseUserId}")]
        public IActionResult GetByFirebaseId(string FirebaseUserId)
        {
            var userProfile = _userProfileRepository.GetByFirebaseId(FirebaseUserId);
            if (userProfile == null)
            {
                return NotFound();
            }
            return Ok(userProfile);
        }

        [HttpPost]
        public IActionResult Register(UserProfile userProfile)
        {
            _userProfileRepository.Add(userProfile);
            return CreatedAtAction(
                nameof(GetByFirebaseId), new { firebaseId = userProfile.FirebaseUserId }, userProfile);
        }

    }
}
