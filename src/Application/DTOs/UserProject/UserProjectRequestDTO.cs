using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagerApi.src.Application.DTOs.UserProject
{
    public class UserProjectRequestDTO
    {
        public int UserId { get; set; }
        public int ProjectId { get; set; }
    }
}