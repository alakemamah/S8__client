﻿using System.ComponentModel.DataAnnotations;

namespace S8__API.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Function { get; set; }

    }
}
