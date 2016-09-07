using App.Core.Cqrs;
using App.Domain.Entities.Navigation;
using App.Domain.Models.Tree;

namespace App.Domain.Menus.Queries
{
    public class FindMenuTreeByOwnerQuery : IQuery<TreeNode<MenuItem>>
    {
        public ITreeOwner TreeOwner { get; set; }

        public FindMenuTreeByOwnerQuery(ITreeOwner treeOwner)
        {
            TreeOwner = treeOwner;
        }
    }
}