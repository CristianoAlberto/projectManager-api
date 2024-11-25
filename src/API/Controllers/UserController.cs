using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProjectManagerApi.src.Application.DTOs.User;
using ProjectManagerApi.src.Application.Interfaces;
using ProjectManagerApi.src.Application.Services;
using ProjectManagerApi.src.Domain.Entities;

namespace ProjectManagerApi.src.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();
            if (!users.IsSuccess)
            {
                return NotFound(users.ErrorMessage);
            }
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (!user.IsSuccess)
            {
                return NotFound(user.ErrorMessage);
            }
            return Ok(user.Data);
        }
        [HttpGet("email")]
        public async Task<IActionResult> GetByEmail([FromBody] string email)
        {
            var user = await _userService.GetByEmailAsync(email);
            if (!user.IsSuccess)
            {
                return NotFound(user.ErrorMessage);
            }
            return Ok(user.Data);
        }
        [HttpPost("createUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserRequestDTO userDto)
        {
            var createUser = await _userService.AddUserAsync(userDto);
            if (!createUser.IsSuccess)
            {
                return BadRequest(createUser.ErrorMessage);
            }
            return CreatedAtAction(nameof(GetByEmail), createUser.Data);
        }
    }
}