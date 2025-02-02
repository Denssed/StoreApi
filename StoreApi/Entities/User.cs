using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using BCrypt.Net;

namespace StoreApi.Entities
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        private string passwordHash;

        [Required]
        public string PasswordHash
        {
            get => passwordHash;
            set => passwordHash = BCrypt.Net.BCrypt.HashPassword(value);
        } 

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    }
    
}
