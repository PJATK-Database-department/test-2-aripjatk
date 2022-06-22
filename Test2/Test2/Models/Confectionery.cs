using System.ComponentModel.DataAnnotations;

namespace Test2.Models {
    public class Confectionery {
        [Key]
        public int IdConfectionery { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public float PricePerOne { get; set; }
    }
}
