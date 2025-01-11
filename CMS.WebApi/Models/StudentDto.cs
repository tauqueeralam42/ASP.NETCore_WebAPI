using System.ComponentModel.DataAnnotations;

namespace CMS.WebApi.Models
{
    public class StudentDto
    {
        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

        [Required]
        public string email { get; set; }

        [Range(18, 100)]
        [Required]
        public int age { get; set; }
    }
}
