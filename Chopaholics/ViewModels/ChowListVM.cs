using Chopaholics.Domain.Models;

namespace Chopaholics.ViewModels
{
    public class ChowListVM
    {
        public IEnumerable<Chow> Chows { get; set; }
        public string? CurrentCategory { get; set; }

        //public ChowListVM(IEnumerable<Chow> chows, string? currentCategory)
        //{
        //    Chows = chows;
        //    CurrentCategory = currentCategory;
        //}
    }
}
