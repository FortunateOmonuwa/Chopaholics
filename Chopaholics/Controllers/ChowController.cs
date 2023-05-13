using Chopaholics.Domain.Interfaces;
using Chopaholics.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Chopaholics.Controllers
{
    public class ChowController : Controller
    {
        private readonly IChowRepository _chows;
        private readonly ICategoryRepository _categories;

        public ChowController(IChowRepository chows, ICategoryRepository categories)
        {
            _categories = categories;
            _chows = chows;
        }

        public IActionResult ListOfChows()
        {
            try
            {
                var category = _categories.GetCategory(1);
                var allChows = _chows.GetAllChows;

                var viewModel = new ChowListVM
                {
                    Chows = allChows,
                    CurrentCategory = "All Chows"
                };
                return View(viewModel);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }  
        }

        public IActionResult Details(int id)
        {
            try
            {
                var chow = _chows.GetChowById(id);
                if (chow == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(chow);
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    } 
}
