using App.Core.Cqrs;
using App.Domain.Concrete;
using App.Domain.Entities.Navigation;
using App.Domain.Models.Tree;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace App.Domain.Menus.Queries
{
    public class FindMenuTreeByOwnerQueryHandler : IQueryHandler<FindMenuTreeByOwnerQuery, TreeNode<MenuItem>>
    {
        private EFDbContext _context;

        public FindMenuTreeByOwnerQueryHandler(EFDbContext context)
        {
            _context = context;
        }

        public TreeNode<MenuItem> Retrieve(FindMenuTreeByOwnerQuery query)
        {
            var ownerId = query.TreeOwner.GetOwnerId();
            var items = _context.MenuItems.Where(x => x.MenuId == ownerId).OrderBy(x => x.Path);

            return TreeBuilder.Build(items.AsNoTracking().ToList());
        }
    }
}