using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data.Entities
{
    public class Users:IdentityUser
    {
        public string FullName { get; set; }
        public bool Deleted { get; set; }
    }
}
