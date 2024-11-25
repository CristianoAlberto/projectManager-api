using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagerApi.src.Application.DTOs.Project
{
    public class ProjectRequestDTO
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
}