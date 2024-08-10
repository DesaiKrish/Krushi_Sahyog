using MyAppDb.Models;

namespace BulkyWeb.Models
{
    public class UserCrop
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int CropId { get; set; }
        public Crop Crop { get; set; }
    }   
}
