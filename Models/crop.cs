using BulkyWeb.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace MyAppDb.Models
{
    public class Crop
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int c_id { get; set; }

        [ForeignKey("users")]
        public int farmerid { get; set; }

        [Required]
        [MaxLength(100)]
        public string cname { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal baseprice { get; set; }

        [Required]
        public int quantity { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime auctiondeadline { get; set; }

        public string desp { get; set; }

        [MaxLength(255)]
        public string photopath { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime createdAt { get; set; } = DateTime.Now;

        public virtual User Farmer { get; set; }
        public ICollection<UserCrop> UserCrop { get; set; }
        public ICollection<Bids> Bids { get; set; }
    }
}
