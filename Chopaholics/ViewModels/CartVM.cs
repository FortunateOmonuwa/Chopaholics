using Chopaholics.Application.Repositories;
using Chopaholics.Domain.Interfaces;
using Chopaholics.Domain.Models;

namespace Chopaholics.ViewModels
{
    public class CartVM
    {
        public ICart ShoppingCart { get; set; }
        public decimal ShoppingCartTotal { get; set; }
        public CartVM(ICart shoppingCart, decimal shoppingCartTotal) 
        {
            ShoppingCart = shoppingCart;
            ShoppingCartTotal = shoppingCartTotal;
        }



    }
}
