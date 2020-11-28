using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTraining.Models
{
    public class RoleAssignViewModel
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public bool Exist { get; set; }
    }
}
