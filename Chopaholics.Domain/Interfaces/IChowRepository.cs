using Chopaholics.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chopaholics.Domain.Interfaces
{
    public interface IChowRepository
    {
        IEnumerable<Chow> GetAllChows { get; }
        IEnumerable<Chow> ChowsOfTheWeek { get; }
        Chow? GetChowById(int chowId);
        IEnumerable<Chow> SearchChows(string searchQueary);
    }
}
