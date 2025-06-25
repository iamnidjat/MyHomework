﻿using System.ComponentModel.DataAnnotations;

namespace backend.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; } = "";

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = "";

        [Required(ErrorMessage = "Password confirmation is required")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = "";

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Birthday is required")]
        public DateTime Birthday { get; set; }
    }
}
