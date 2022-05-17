﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAccessLayer.Data.Entities
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string HashPassword { get; set; }
    }
}
