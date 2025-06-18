﻿using System.ComponentModel.DataAnnotations;

namespace graduationProject.DTOs
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Password is required")]
        public string Password { get; set; } = string.Empty;
    }
}
