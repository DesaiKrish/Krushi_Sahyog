using BulkyWeb.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace MyAppDb.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [MaxLength(100)]
        public string name { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [MaxLength(255)]
        public string password { get; set; }

        [Required]
        [MaxLength(20)]
        public string phone { get; set; }

        [Required]
        [MaxLength(50)]
        public string role { get; set; }  // e.g., 'Farmer', 'Buyer', or 'Admin'

        [DataType(DataType.DateTime)]
        public DateTime createdAt { get; set; } = DateTime.Now;

        [MaxLength(255)]
        public string photopath { get; set; }
        public ICollection<UserCrop> UserCrop { get; set; }
        public ICollection<Bids> Bids { get; set; }


    }
}
