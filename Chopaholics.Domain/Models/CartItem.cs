using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chopaholics.Domain.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public Chow Chow { get; set; } = default!;
        public int Amount { get; set; }
        public string? CartId { get; set; }
    }
}
