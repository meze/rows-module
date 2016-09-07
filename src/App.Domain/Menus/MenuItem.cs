using App.Domain.Models;
using App.Domain.Models.Tree;

namespace App.Domain.Navigation
{
    public class MenuItem : INode
    {
        public int Id { get; set; }

        public virtual Menu Menu { get; set; }

        public string Path { get; set; }

        public string Link { get; set; }

        public MenuItemType Type { get; set; }

        public bool DisplayOnDesktop { get; set; }

        public bool DisplayOnMobile { get; set; }

        public int Sequence { get; set; }

        public int MenuId { get; set; }

        public MenuItem()
        {
        }
    }
}