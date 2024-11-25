using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagerApi.src.Domain.Entities
{
    public class UserProject
    {
        public int UserId { get; set; }
        public required User User { get; set; }
        public int ProjectId { get; set; }
        public required Project Project { get; set; }
    }
}