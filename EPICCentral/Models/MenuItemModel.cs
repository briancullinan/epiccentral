using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace EPICCentral.Models
{
    public class MenuItemModel
    {
        public MenuItemModel()
        {
            SubMenu = new List<MenuItemModel>();
            Visible = true;
            Selected = false;
        }

        public string Text { get; set; }
        public string Path { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public RouteDictionary Route { get; set; }
        public bool Visible { get; set; }
        public bool Selected { get; set; }

        public IEnumerable<MenuItemModel> this[string controller, string action]
        {
            get { return SubMenu.Where(x => x.Controller == controller && x.Action == action); }
        }

        public IEnumerable<MenuItemModel> SubMenu { get; set; }
    }

    public class RouteDictionary : Dictionary<string, object>
    {
        public new object this[string key]
        {
            get { return base.ContainsKey(key.ToLower()) ? base[key.ToLower()] : base[key]; }
            set { base[key] = value; }
        }

        public new bool ContainsKey(string key)
        {
            return base.ContainsKey(key) || base.ContainsKey(key.ToLower());
        }

        public new void Add(string key, object value)
        {
            base.Add(key.ToLower(), value);
        }
    }
}

