using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace StoreApi.Entities
{
    public class Product
    {
        [Key]
        [Required]
        public int IdProduct { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; } = string.Empty;
        [StringLength(250)]
        public string Description { get; set; } = string.Empty;

        public bool Active { get; set; } = true;
    }

}
