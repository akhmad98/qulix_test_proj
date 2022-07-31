using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace qulix_data.Data
{
    [Table("Photo")]
    public class Photo : BaseEntity
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required, Display(Name = "Link")]
        public string Link { get; set; }

        [Required, Display(Name = "Original size")]
        public int Size { get; set; }

        [Required, Display(Name = "Date of creation")]
        public DateTime CreatedAt { get; set; }

        [Column("AuthorId")]
        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; }

        [Required, Display(Name = "Cost")]
        public double Cost { get; set; }

        [Required, Display(Name = "Number of sales")]
        public int NumberOfSales { get; set; }

        [Required, Display(Name = "Rating")]
        public int Rating { get; set; }

        public byte[] Image { get; set; }
    }
}
