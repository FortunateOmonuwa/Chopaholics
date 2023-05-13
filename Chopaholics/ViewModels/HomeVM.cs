using Chopaholics.Domain.Models;

namespace Chopaholics.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Chow> ChowOfTheWeek { get; set; }

        public HomeVM(IEnumerable<Chow> chowsOfTheWeek)
        {
            ChowOfTheWeek = chowsOfTheWeek;
        }
    }
}
