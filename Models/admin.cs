using MyAppDb.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAppDb.Models
{
    public class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int admin_id { get; set; }

        [ForeignKey("User")]
        public int user_id { get; set; }

        [MaxLength(255)]
        public string adminrights { get; set; }

        public virtual User User { get; set; }
    }
}
