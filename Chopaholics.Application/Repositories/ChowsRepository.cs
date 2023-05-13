using Chopaholics.Application.DataContext;
using Chopaholics.Domain.Interfaces;
using Chopaholics.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chopaholics.Application.Repositories
{
    public class ChowsRepository : IChowRepository
    {
        private readonly ChopaholicsDbContext _context;

        public ChowsRepository(ChopaholicsDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Chow> GetAllChows
        {
            get
            {
                return _context.Chows.Include(c => c.Category);
            }
        }

        public IEnumerable<Chow> ChowsOfTheWeek
        {
            get
            {
                return _context.Chows.Include(c => c.Category).Where(c => c.IsChowOfTheWeek);
            }
        }

        public Chow? GetChowById(int chowId) => _context.Chows.FirstOrDefault(c => c.Id == chowId);

        public IEnumerable<Chow> SearchChows(string searchQueary)
        {
            throw new NotImplementedException();
        }
    }
}
