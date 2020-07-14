using System;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Domain.Entity
{
    public class Order
    {
        [Required]
        public int OrderId { get; set; }

        [Required]
        public string Dishes { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
    }
}
