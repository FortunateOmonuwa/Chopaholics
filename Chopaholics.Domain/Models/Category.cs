using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chopaholics.Domain.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "The name field is required.")]
        [Display(Name = "Chow Name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The name must be between 3 and 50 characters long.")]
        public string Name { get; set; } = string.Empty;

        //[Required(ErrorMessage = "Description is required")]
        [Display(Name = "Short Description")]
        public string? Description { get; set; }
        public List<Chow>? Chows { get; set; }
    }
}
