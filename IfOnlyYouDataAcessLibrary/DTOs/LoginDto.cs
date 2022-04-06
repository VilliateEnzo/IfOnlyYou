using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfOnlyYouDataAccessLibrary.DTOs
{
    public class LoginDto
    {
        [Required]
        public string username { get; set; } = string.Empty;

        [Required]
        public string password { get; set; } = string.Empty;
    }
}
