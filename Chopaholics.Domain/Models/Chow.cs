using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chopaholics.Domain.Models
{
    public class Chow
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The name field is required.")]
        [Display(Name = "Chow Name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The name must be between 3 and 50 characters long.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage ="Must include short desciption")]
        [Display(Name = "Short Description")]
        public string? ShortDescription { get; set; }

        [Display(Name = "Long Description")]
        public string? LongDescription { get; set; }

        [Display(Name = "Allergy Information")]
        public string? AllergyInformation { get; set; }

        [Required(ErrorMessage = "The price field is required.")]
        [Range(0.01, 10000, ErrorMessage = "The price must be between 0.01 and 10000.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Image is required")]
        [Display(Name = "Image URL")]
        public string? ImageUrl { get; set; }

        [Display(Name = "Thumbnail URL")]
        public string? ImageThumbnailUrl { get; set; }

        [Display(Name = "Chow of the Week")]
        public bool IsChowOfTheWeek { get; set; }

        [Display(Name = "In Stock")]
        public bool InStock { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public Category Category { get; set; } = default!;
    }

}
