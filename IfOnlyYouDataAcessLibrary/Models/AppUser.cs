using IfOnlyYouDataAccessLibrary.ClassExtensions;
using System.ComponentModel.DataAnnotations;

namespace IfOnlyYouDataAccessLibrary.Models
{
    public class AppUser
    {
        public int Id { get; set; }
     
        [MaxLength(40)]
        public string UserName { get; set; } = string.Empty;

        [MaxLength(400)]
        public string Introduction { get; set; } = string.Empty;

        public byte[] PasswordHash { get; set; } = new byte[] { };
        
        public byte[] PasswordSalt { get; set; } = new byte[] { };
        
        public DateTime DateOfBirth { get; set; }

        [MaxLength(12)]
        public string KnownAs { get; set; } = string.Empty;
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        public DateTime LastActiveAt { get; set; } = DateTime.Now;

        [MaxLength(50)]
        public virtual string Gender { get; set; } = string.Empty;

        public virtual string LookingFor { get; set; } = string.Empty;

        public virtual ICollection<Interest> Interests { get; set; }

        [MaxLength(120)]
        public string City { get; set; } = string.Empty;

        [MaxLength(120)]
        public string Country { get; set; } = string.Empty;

        public ICollection<Photo> Photos { get; set; }


        //public int GetAge()
        //{
           // return DateOfBirth.CalculateAge();
        //}
    }
}
