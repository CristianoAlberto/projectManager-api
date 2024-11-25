using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagerApi.src.Application.DTOs.User
{
    public class UserRequestDTO
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
    }
}