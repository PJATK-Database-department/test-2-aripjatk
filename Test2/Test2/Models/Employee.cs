using System.ComponentModel.DataAnnotations;

namespace Test2.Models {
    public class Employee {
        [Key]
        public int IdEmployee { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(60)]
        public string LastName { get; set; }
    }
}
