using System.Collections.Generic;

namespace App.Domain.Navigation
{
    public enum MenuType
    {
        MOBILE,
        DESKTOP
    }

    public class Menu
    {
        public int Id { get; set; }
        public MenuType Type { get; set; }

        public virtual ICollection<MenuItem> Items { get; private set; }

        public Menu()
        {
            Items = new List<MenuItem>();
        }

        public void AddItem(MenuItem item)
        {
            item.Menu = this;
            Items.Add(item);
        }
    }
}