using System.Collections.Generic;
using System.Linq;

namespace App.Domain.Models.Tree
{
    public class TreeNode<T> where T : INode
    {
        private static readonly string PATH_SEPARATOR = "/";

        List<TreeNode<T>> _children = new List<TreeNode<T>>();

        public T Item { get; set; }

        public TreeNode(T item)
        {
            Item = item;
        }

        public TreeNode<T> AddChild(TreeNode<T> node)
        {
            node.FixPath(this);

            _children.Add(node);

            return node;
        }

        public int? GetParentId()
        {
            var parent = GetPath().Substring(GetPath().LastIndexOf(PATH_SEPARATOR) + 1);

            if (parent.Length > 0)
            {
                return int.Parse(parent);
            }

            return null;
        }

        public int Count()
        {
            return _children.Sum(n => n.Count()) + 1;
        }

        public IList<TreeNode<T>> GetChildren()
        {
            return _children;
        }

        public TreeNode<T> FindChildById(int id)
        {
            foreach (var child in _children)
            {
                if (child.Item.Id == id)
                {
                    return child;
                }

                var childResult = child.FindChildById(id);

                if (childResult != null)
                {
                    return childResult;
                }
            }

            return null;
        }

        public bool IsRoot()
        {
            return this.Item.Path == PATH_SEPARATOR;
        }

        public string GetPath()
        {
            return Item.Path;
        }

        public void MoveTo(TreeNode<T> newParent)
        {
            FixPath(newParent);

            foreach (var child in _children)
            {
                child.MoveTo(this);
            }
        }

        private void FixPath(TreeNode<T> parentNode)
        {
             Item.Path = (parentNode.IsRoot() ? "" : parentNode.GetPath()) + PATH_SEPARATOR + parentNode.Item.Id;
        }
    }
}
