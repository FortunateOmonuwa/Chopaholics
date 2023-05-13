using Chopaholics.Application.DataContext;
using Chopaholics.Domain.Interfaces;
using Chopaholics.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Chopaholics.Application.Repositories
{
    public class CartRepository : ICart
    {
        public string? ShoppingCartId { get; set; }

        public List<CartItem> CartItems { get; set; } = default!;
        private readonly ChopaholicsDbContext _context;
        public CartRepository(ChopaholicsDbContext context)
        {
            _context = context;
        }

        public static CartRepository GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

            ChopaholicsDbContext context = services.GetService<ChopaholicsDbContext>() ?? throw new Exception("Error initializing");

            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

            session?.SetString("CartId", cartId);

            return new CartRepository(context) { ShoppingCartId = cartId };
        }

        //public static Cart GetCart(IServiceProvider services)
        //{
        //    ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

        //    ChopaholicsDbContext context = services.GetService<ChopaholicsDbContext>() ?? throw new Exception("Error initializing");

        //    string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

        //    var cart = context.Cart
        //        .Include(c => c.CartItems)
        //        .ThenInclude(ci => ci.Chow)
        //        .SingleOrDefault(c => c.CartId == cartId);

        //    if (cart == null)
        //    {
        //        cart = new Cart { CartId = cartId };
        //        context.Cart.Add(cart);
        //        context.SaveChanges();
        //    }

        //    session.SetString("CartId", cart.CartId);

        //    return cart;
        //}

        public void AddToCart(Chow chow)
        {
            var shoppingCartItem =
                    _context.CartItems.SingleOrDefault(
                        s => s.Chow.Id == chow.Id && s.CartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new CartItem
                {
                    CartId = ShoppingCartId,
                    Chow = chow,
                    Amount = 1
                };

                _context.CartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _context.SaveChanges();
        }

        public int RemoveFromCart(Chow chow)
        {
            var shoppingCartItem =
                    _context.CartItems.SingleOrDefault(
                        s => s.Chow.Id == chow.Id && s.CartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _context.CartItems.Remove(shoppingCartItem);
                }
            }

            _context.SaveChanges();

            return localAmount;
        }

        public List<CartItem> GetAllCartItems()
        {
            return CartItems ??=
                       _context.CartItems.Where(c => c.CartId == ShoppingCartId)
                           .Include(s => s.Chow)
                           .ToList();
        }

        public void ClearCart()
        {
            var cartItems = _context
                .CartItems
                .Where(cart => cart.CartId == ShoppingCartId);

            _context.CartItems.RemoveRange(cartItems);

            _context.SaveChanges();
        }

        public decimal GetCartTotalPrice()
        {
            var total = _context.CartItems.Where(c => c.CartId == ShoppingCartId)
                .Select(c => c.Chow.Price * c.Amount).Sum();
            return (decimal)total;
        }

    }
}
