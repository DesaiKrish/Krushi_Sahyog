using MyAppDb.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAppDb.Models
{
    public class Bids
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int b_id { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal bidamount { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime bidtime { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public User User { get; set; }
        public int CropId { get; set; }
        public virtual Crop Crop { get; set; }
    }
}
