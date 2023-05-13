using Chopaholics.Application.DataContext;
using Chopaholics.Domain.Interfaces;
using Chopaholics.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chopaholics.Application.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ChopaholicsDbContext _context;

        public CategoryRepository(ChopaholicsDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> AllCategories => _context.Categories.OrderBy(c => c.Name);

        public Category GetCategory(int id) => _context.Categories.FirstOrDefault(c => c.Id == id);
    }
}
