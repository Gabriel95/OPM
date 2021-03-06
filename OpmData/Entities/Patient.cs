﻿using System.ComponentModel.DataAnnotations;

namespace OpmData
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string Occupation { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [MaxLength(1)]
        public string Gender { get; set; }
    }
}
