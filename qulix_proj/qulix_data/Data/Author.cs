using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace qulix_data.Data
{
    [Table("Author")]
    public class Author : BaseEntity
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Nick Name")]
        public string Nickname { get; set; }

        [Required]
        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }

        [Required, Display(Name = "Date of Registration")]
        public DateTime DateOfRegistr { get; set; }

        public ICollection<Photo> Photo { get; set; }
        public ICollection<Text> Text { get; set; }
    }
}
