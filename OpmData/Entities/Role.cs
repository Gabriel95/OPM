﻿using System.ComponentModel.DataAnnotations;

namespace OpmData.Entities
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string Description { get; set; }
    }
}