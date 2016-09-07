using System.Collections.Generic;

namespace App.Domain.Navigation
{
    public class MenuItemViewModel
    {
        public string Text { get; set; }

        public bool Leaf { get; set; }

        public string IconCls { get; set; }

        public string Id { get; set; }

        public IList<MenuItemViewModel> Children { get; set; }

        public string Qtip { get; set; }

        public string Url
        {
            get
            {
                return _url;
            }
            set
            {
                _url = value;
                Id = GenerateId(value);
            }
        }

        private string _url;

        private static string GenerateId(string url) => url.Replace('/', '-');
    }
}