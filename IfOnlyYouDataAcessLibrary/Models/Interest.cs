using System.ComponentModel.DataAnnotations;

namespace IfOnlyYouDataAccessLibrary.Models
{
    public class Interest
    {
        public int Id { get; set; }

        [MaxLength(120)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(400)]
        public string Description { get; set; } = string.Empty;

        public virtual ICollection<AppUser> Users { get; set; }
    }
}