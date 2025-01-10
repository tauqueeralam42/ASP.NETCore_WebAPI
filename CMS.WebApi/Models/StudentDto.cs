using System.ComponentModel.DataAnnotations;

namespace CMS.WebApi.Models
{
    public class StudentDto
    {
        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

        [Range(18, 100)]
        public int age { get; set; }
    }
}
