using App.Core.Cqrs;
using App.Domain.Entities;
using System.Collections.Generic;

namespace App.Domain.Rows.Queries
{
    public class AllRowsQuery : IQuery<IEnumerable<Row>>
    {
    }
}