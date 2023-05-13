using Chopaholics.Domain.Interfaces;
using Chopaholics.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Chopaholics.Controllers
{
    public class HomeController : Controller
    {
        private readonly IChowRepository  _chowRepository;
        public HomeController(IChowRepository chowRepository)
        {
            _chowRepository = chowRepository;
        }
        public IActionResult Index()
        {
            var chowsOfTheWeek = _chowRepository.ChowsOfTheWeek;
            var homeVM = new HomeVM(chowsOfTheWeek);
            return View(homeVM);
        }
    }
}
