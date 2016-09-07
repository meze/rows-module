using App.Core.Cqrs;
using App.Domain.Concrete;
using App.Domain.Entities.Navigation;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace App.Domain.Menus.Queries
{
    public class SingleMenuQueryHandler : IQueryHandler<SingleMenuQuery, Menu>
    {
        private EFDbContext _context;

        public SingleMenuQueryHandler(EFDbContext context)
        {
            _context = context;
        }

        public Menu Retrieve(SingleMenuQuery query)
        {
            return _context.Menus.AsNoTracking().SingleOrDefault(o => o.Id == query.Id);
        }
    }
}