using Chopaholics.Domain.Interfaces;
using Chopaholics.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Chopaholics.Controllers
{
    public class CartController : Controller
    {
        private readonly IChowRepository _chowRepository;
        private readonly ICart _cartRepository;
        public CartController(IChowRepository chowRepository, ICart cartRepository)
        {
            _chowRepository = chowRepository;
            _cartRepository = cartRepository;
        }

        public ViewResult Index()
        {
            var items = _cartRepository.GetAllCartItems();
            _cartRepository.CartItems = items;

            var shoppingCartViewModel = new CartVM(_cartRepository, _cartRepository.GetCartTotalPrice());

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int chowId)
        {
            var selectedChow = _chowRepository.GetAllChows.FirstOrDefault(p => p.Id == chowId);

            if (selectedChow != null)
            {
                _cartRepository.AddToCart(selectedChow);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int chowId)
        {
            var selectedChow = _chowRepository.GetChowById(chowId);

            if (selectedChow != null)
            {
                _cartRepository.RemoveFromCart(selectedChow);
            }
            return RedirectToAction("Index");
        }
    }
}
