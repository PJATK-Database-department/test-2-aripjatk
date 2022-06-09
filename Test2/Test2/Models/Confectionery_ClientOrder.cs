using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test2.Models {
    public class Confectionery_ClientOrder {
        [Key]
        public int IdClientOrder { get; set; }
        public int IdConfectionery { get; set; }
        [Required]
        public int Amount { get; set; }
        [MaxLength(300)]
        public string Comments { get; set; }
        [ForeignKey("IdClientOrder")]
        public virtual ClientOrder ClientOrder { get; set; }
        [ForeignKey("IdConfectionery")]
        public virtual Confectionery Confectionery { get; set; }
    }
}
