using App.Core.Cqrs;
using App.Domain.Entities.Navigation;

namespace App.Domain.Menus.Queries
{
    public class SingleMenuQuery : IQuery<Menu>
    {
        public int Id { get; set; }

        public SingleMenuQuery(int id)
        {
            Id = id;
        }
    }
}