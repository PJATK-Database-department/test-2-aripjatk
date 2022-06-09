using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Test2.Models {
    public class ClientOrder {
        [Key]
        public int IdClientOrder { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        [MaxLength(300)]
        public string Comments { get; set; }
        public int IdClient { get; set; }
        public int IdEmployee { get; set; }
        [ForeignKey("IdClient")]
        public virtual Client Client { get; set; }
        [ForeignKey("IdEmployee")]
        public virtual Employee Employee { get; set; }
    }
}
