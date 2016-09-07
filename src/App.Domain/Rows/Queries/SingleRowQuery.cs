using App.Core.Cqrs;
using App.Domain.Entities;

namespace App.Domain.Rows.Queries
{
    public class SingleRowQuery : IQuery<Row>
    {
        public int Id { get; set; }
    }
}