using BLL.Interfaces;
using Db.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Registration : System.Web.UI.Page
    {
        public IUserService UsServ { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
          
        protected void Registr_Click(object sender, EventArgs e)
        {
            //var NameUser = TextName.Text;
            //var PassFirst = TextPass1.Text;
            //var PassSecond = TextPass2.Text;
            //var NewUser = new User();
            //if(PassFirst != PassSecond)
            //{
            //compare validator in asp.net c# for password !гуглить!
            //}
            //else
            //{
            //    NewUser.Password = PassFirst;
            //} 
            //NewUser.Name = NameUser;
            //UsServ.Create(NewUser);  
        }
    }
}