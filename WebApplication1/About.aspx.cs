using Autofac.Integration.Web.Forms;
using BLL.Interfaces;
using Common.Enums;
using Db.Model;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Extensions;

namespace WebApplication1
{
    [InjectProperties]
    public partial class About : Page
    {
        public IUserService usServ { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//чтобы не загружать на Postback
            {

                Title = "Fifi";
                NewPnl.Height = 100;
                NewPnl.Width = 100;
                NewPnl.ToolTip = "Stroka";

                var ListUsers = usServ.ReadAll()
                    .Select(c => new { c.Id, c.Name, c.RoleId, c.IsDeleted })
                    .ToList();
                UserList.DataSource = ListUsers;//чтобы закинуть в таблицу  
                UserList.DataBind(); // обновляем что закинули

                //ListUsers.RemoveAll(c=> true);
                //UserList.DataBind(); // 

                //Repeater1.DataSource = ListUsers;
                //Repeater1.DataBind();
                //GridView1.DataSource = ListUsers;
                //GridView1.DataBind();
                RoleIdDbUpdate();
            }

        }

        protected void NameBtn_Click(object sender, EventArgs e)
        {
            //UserList.EditItemTemplate = UserList.ItemTemplate;
            //UserList.DataBind();
             

            //UserList.SelectionMode = ListViewSelectionMode.Multiple;

            //myGridView.SelectionMode = ListViewSelectionMode.None;
            //myGridView.IsItemClickEnabled = true;
        }
        
        protected void UserList_ItemDeleting(object sender, ListViewDeleteEventArgs e)//CommandName имя команды для уволнения
        {
            var id = (int)e.Keys["Id"];
            usServ.Delete(id);

            UserList.DataSource = usServ.ReadAll()
                    .Select(c => new { c.Id, c.Name, c.RoleId, c.IsDeleted })
                    .ToList();
            UserList.DataBind(); //чтобы закинуть в таблицу            
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            var NameTxt = UserList.FindControlRecursive<TextBox>("NameTxt"); // имя которое введем
            var NewUser = new User();
            NewUser.Name = NameTxt.Text;
            var RoleIdDdl = UserList.FindControlRecursive<DropDownList>("RoleIdDdl");
            Enum.TryParse<RoleEnum>(RoleIdDdl.SelectedValue, out var role);
            NewUser.RoleId = role;
            usServ.Create(NewUser);
            UserList.DataSource = usServ.ReadAll()
                    .Select(c => new { c.Id, c.Name, c.RoleId, c.IsDeleted })
                    .ToList();
            UserList.DataBind();
        }

        protected void UserList_ItemEditing(object sender, ListViewEditEventArgs e) //переход в режи редактирования
        {
            UserList.EditIndex = e.NewEditIndex;//индекс редактируемой 

            RoleIdDbUpdate(); 

            UserList.DataSource = usServ.ReadAll()
                    .Select(c => new { c.Id, c.Name, c.RoleId, c.IsDeleted })
                    .ToList();
            UserList.DataBind();
        }
        
        protected void UserList_ItemCanceling(object sender, ListViewCancelEventArgs e)//отмена редактирования
        {
            UserList.EditIndex = -1;

            UserList.DataSource = usServ.ReadAll()
                    .Select(c => new { c.Id, c.Name, c.RoleId, c.IsDeleted })
                    .ToList();
            UserList.DataBind();
        } 

        protected void UserList_ItemDataBound(object sender, ListViewItemEventArgs e) //заполняю данные в каждую строчку
        {
            if (e.Item.ItemType == ListViewItemType.DataItem) //
            {
                RoleIdDbUpdate();
            }
        }

        protected void RoleIdDbUpdate()
        {
            var RoleIdDdl = UserList.FindControlRecursive<DropDownList>("RoleIdDdl");
            if (RoleIdDdl != null) //наполняем элемент только если он найден
            {
                RoleIdDdl.DataSource = Enum.GetValues(typeof(RoleEnum));
                RoleIdDdl.DataBind();
            }
        }

        protected void UserList_DataBound(object sender, EventArgs e) //остальные данные которые относяться к списку(к строчке с добавлением)
        {
            if (!IsPostBack)
            {
                RoleIdDbUpdate();
            } 
        }
        
        protected void UserList_ItemUpdating(object sender, ListViewUpdateEventArgs e) //сохранение после редактирования
        {
            
            var id = int.Parse(((Label)UserList.Items[e.ItemIndex].FindControl("IDLbl")).Text); 
            var name = ((TextBox)UserList.Items[e.ItemIndex].FindControl("EditNameTxt")).Text; 
            var roleList = ((DropDownList)UserList.Items[e.ItemIndex].FindControl("RoleIdDdl")); 
            var user = usServ.Read(id);
             
            user.Name = name;
            Enum.TryParse<RoleEnum>(roleList.SelectedValue, out var role);
            user.RoleId = role; 
             

            usServ.Update(user);
            UserList.EditIndex = -1;
            UserList.DataSource = usServ.ReadAll()
                               .Select(c => new { c.Id, c.Name, c.RoleId, c.IsDeleted })
                               .ToList();
            UserList.DataBind();

        }

        protected void RoleIdDdl_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}