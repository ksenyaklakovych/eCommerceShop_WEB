namespace eCommerce.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserViewModel
    {
        public int userId { get; set; }

        [StringLength(30, MinimumLength = 4, ErrorMessage = "Ім'я коростувача має містити принаймні 4 символи.")]
        [Required(ErrorMessage = "Обов'язкове поле.")]
        public string username { get; set; }

        [StringLength(30, MinimumLength = 5, ErrorMessage = "Пароль має містити принаймні 4 символи.")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        public bool isAdmin { get; set; }
    }
}
