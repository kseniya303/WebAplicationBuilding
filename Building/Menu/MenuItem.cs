using Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Building.Menu
{
    /// <summary>
    /// Menu item class, that stores all menu data and connections
    /// </summary>
    [Serializable]
    public class MenuItem
    {
        /// <summary>
        /// Menu item title
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Menu item response index
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Menu item child items
        /// </summary>
        public List<MenuItem> Items { get; set; }

        public ActionEnum? Action { get; set; }

        public string EntityName { get; set; }

        [XmlIgnore]
        public MenuItem Parent;

        /// <summary>
        /// Ctor needed for xml deserialization 
        /// </summary>
        public MenuItem()
        { }

        /// <summary>
        /// Ctor for manual creation
        /// </summary>
        /// <param name="text">Menu item title</param>
        public MenuItem(string text)
        {
            Text = text;
            Items = new List<MenuItem>();
        }

        public MenuItem(string text, ActionEnum action, string entityName)
            : this(text)
        {
            Action = action;
            EntityName = entityName;
        }

        /// <summary>
        /// Adds several menu items as child elements
        /// </summary>
        /// <param name="items">Child menu items</param>
        public void Add(params MenuItem[] items)
        {
            foreach (var item in items)
            {
                item.Index = Items.Count + 1;
                item.Parent = this;
                Items.Add(item);
            }
        }

        /// <summary>
        /// Finds child menu item by its response index
        /// </summary>
        /// <param name="index">Child menu item response index</param>
        /// <returns>Selected menu item</returns>
        public MenuItem GoForward(int index)
        {
            return Items[index - 1];
        }

        /// <summary>
        /// Finds parent item
        /// </summary>
        /// <returns>Parent menu item</returns>
        public MenuItem GoBack()
        {
            return Parent;
        }

        /// <summary>
        /// Presents menu item as a string
        /// </summary>
        /// <returns>String to view</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(Text + ":");

            foreach (var item in Items)
            {
                sb.AppendLine(item.Index + ". " + item.Text);
            }

            sb.AppendLine(Parent == null ?
                "0.Exit" : "0.Back");
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            var item = obj as MenuItem;
            return item != (object)null &&
                   Text == item.Text &&
                   Index == item.Index;
        }

        public override int GetHashCode()
        {
            var hashCode = -1877720027;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Text);
            hashCode = hashCode * -1521134295 + Index.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<MenuItem>>.Default.GetHashCode(Items);
            hashCode = hashCode * -1521134295 + EqualityComparer<ActionEnum?>.Default.GetHashCode(Action);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(EntityName);
            hashCode = hashCode * -1521134295 + EqualityComparer<MenuItem>.Default.GetHashCode(Parent);
            return hashCode;
        }
        
        public static bool operator ==(MenuItem item1, MenuItem item2)
        {
            if (item1 == (object)null)
                return false;
            return item1.Equals(item2);
        }

        public static bool operator !=(MenuItem item1, MenuItem item2)
        {
            return !(item1 == item2);
        }
    }
}
