using App.Core.Cqrs;
using App.Domain.Concrete;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace App.Domain.Rows.Queries
{
    public class AllRowsQueryHandler : IQueryHandler<AllRowsQuery, IEnumerable<Row>>
    {
        private EFDbContext _context;

        public AllRowsQueryHandler(EFDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Row> Retrieve(AllRowsQuery query)
        {
            return _context.Rows.Include(r => r.Values).Include(r => r.Values.Select(v => v.Field)).ToList();
        }
    }
}