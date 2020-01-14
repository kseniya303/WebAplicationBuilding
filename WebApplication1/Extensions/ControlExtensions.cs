using System.Web.UI;

namespace WebApplication1.Extensions
{
    public static class ControlExtensions
    {
        public static T FindControlRecursive<T>(this Control root, string id) 
            where T : Control
        {
            if (root.ID == id && root is T output)
                return output;

            foreach (Control controlToSearch in root.Controls)
            {
                var controlToReturn =
                    FindControlRecursive<T>(controlToSearch, id);
                if (controlToReturn != null)
                    return controlToReturn;
            }
            return null;
        }
    }

}