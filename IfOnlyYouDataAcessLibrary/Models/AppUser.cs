using System.ComponentModel.DataAnnotations;

namespace IfOnlyYouDataAccessLibrary.Models
{
    public class AppUser
    {
        public int Id { get; set; }

        [MaxLength(40)]
        public string UserName { get; set; } = string.Empty;
    }
}
