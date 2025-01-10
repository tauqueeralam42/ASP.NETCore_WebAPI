using System.ComponentModel.DataAnnotations;

namespace CMS.WebApi.Models
{
    public class Student
    {

        public int id { get; set; }

        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

        [Required]
        public string email { get; set; }

        [Range(18, 22)]
        public int age { get; set; }
    }
}
