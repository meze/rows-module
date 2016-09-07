using App.Core.Cqrs;
using App.Domain.Concrete;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace App.Domain.Rows.Queries
{
    public class SingleRowQueryHandler : IQueryHandler<SingleRowQuery, Row>
    {
        private EFDbContext _context;

        public SingleRowQueryHandler(EFDbContext context)
        {
            _context = context;
        }

        public Row Retrieve(SingleRowQuery query)
        {
            return _context.Rows.Include(r => r.Values).Include(r => r.Values.Select(v => v.Field)).SingleOrDefault(o => o.Id == query.Id);
        }
    }
}