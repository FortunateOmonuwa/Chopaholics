using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chopaholics.Domain.Models
{
    public class Cart
    {
        public string CartId { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; } = default!;
    }
}
