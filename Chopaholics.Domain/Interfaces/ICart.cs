using Chopaholics.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chopaholics.Domain.Interfaces
{
    public interface ICart
    {
        void AddToCart(Chow chow);
        int RemoveFromCart (Chow chow);
        List<CartItem> GetAllCartItems();
        void ClearCart();
        decimal GetCartTotalPrice();
        List<CartItem> CartItems { get; set; }
    }
}
