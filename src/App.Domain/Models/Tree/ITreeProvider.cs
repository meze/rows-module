using System.Collections.Generic;
using App.Domain.Entities.Navigation;

namespace App.Domain.Models.Tree
{
    interface ITreeBuilder<T>
    {
        TreeNode<MenuItem> FindByOwner(ITreeOwner owner);
    }
}
