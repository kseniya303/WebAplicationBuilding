using Autofac.Integration.Web.Forms;
using BLL.Interfaces;
using System; 
using System.Linq; 
using System.Web.UI.WebControls; 
using Common.Enums; 
using WebApplication1.Extensions;
using Db.Model;

namespace WebApplication1
{
    [InjectProperties]
    public partial class Materials : System.Web.UI.Page
    {
        public IMaterialService MatServ { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        { 
            if (!IsPostBack)//чтобы не загружать на Postback
            { 
                Title = "MATERIALS";
                NewPnl.Height = 100;
                NewPnl.Width = 100;
                NewPnl.ToolTip = "Stroka"; 

                var ListMaterials = MatServ.ReadAll() 
                    .Select(c => new { c.Id, c.Name, c.Date, c.UnitId, c.Num })
                    .ToList();
                MaterialList.DataSource = ListMaterials;//чтобы закинуть в таблицу  
                MaterialList.DataBind(); // обновляем что закинули

                DDLUnitID();
            } 
        }

        public void DDLUnitID()
        {
            var UnitIdDdl = MaterialList.FindControlRecursive<DropDownList>("UnitIdDdl");
            if (UnitIdDdl != null) //наполняем элемент только если он найден
            {
                UnitIdDdl.DataSource = Enum.GetValues(typeof(UnitEnum));
                UnitIdDdl.DataBind();
            }
        }

        protected void MaterialList_ItemDataBound(object sender, ListViewItemEventArgs e) //заполняю данные в каждую строчку
        {
            if (e.Item.ItemType == ListViewItemType.DataItem) 
            {
                DDLUnitID();
            }
        }

        protected void MaterialList_ItemEditing(object sender, ListViewEditEventArgs e)//режим редактирования
        {
            MaterialList.EditIndex = e.NewEditIndex;//индекс редактируемой 

            DDLUnitID();

            MaterialList.DataSource = MatServ.ReadAll()
                    .Select(c => new { c.Id, c.Name, c.Date, c.UnitId, c.Num })
                    .ToList();
            MaterialList.DataBind();
        }

        protected void MaterialList_ItemCanceling(object sender, ListViewCancelEventArgs e)//отменить редактирование
        {
            MaterialList.EditIndex = -1;

            MaterialList.DataSource = MatServ.ReadAll()
                    .Select(c => new { c.Id, c.Name, c.Date, c.UnitId, c.Num })
                    .ToList();
            MaterialList.DataBind();
        }

        protected void MaterialList_ItemDeleting(object sender, ListViewDeleteEventArgs e)//удалить
        {

        }

        protected void MaterialList_DataBound(object sender, EventArgs e)//остальные данные которые относяться к списку(к строчке с добавлением)
        {
            if (!IsPostBack)
            {
                DDLUnitID();
            }
        }

        protected void MaterialList_ItemUpdating(object sender, ListViewUpdateEventArgs e)//обновить
        {
            var id = int.Parse(((Label)MaterialList.Items[e.ItemIndex].FindControl("IDLbl")).Text);
            var name = ((TextBox)MaterialList.Items[e.ItemIndex].FindControl("EditNameTxt")).Text;
            var date = ((Calendar)MaterialList.Items[e.ItemIndex].FindControl("EditDate")).SelectedDate;
            var num = int.Parse(((TextBox)MaterialList.Items[e.ItemIndex].FindControl("NumMaterial")).Text);
            var materialList = ((DropDownList)MaterialList.Items[e.ItemIndex].FindControl("UnitIdDdl"));
            var material = MatServ.Read(id);

            material.Num = num;
            material.Name = name;
            material.Date = date;
            Enum.TryParse<UnitEnum>(materialList.SelectedValue, out var unit);
            material.UnitId = unit;


            MatServ.Update(material);
            MaterialList.EditIndex = -1;
            MaterialList.DataSource = MatServ.ReadAll()
                               .Select(c => new { c.Id, c.Name, c.Date, c.UnitId, c.Num })
                               .ToList();
            MaterialList.DataBind();
        }

        protected void SaveBtn_Click(object sender, EventArgs e)// строка добавления нового материала
        {
            var num = MaterialList.FindControlRecursive<TextBox>("NumMaterial"); // кол-во 
            var nameTxt = MaterialList.FindControlRecursive<TextBox>("NameTxt"); // имя которое введем
            var unitIdDdl = MaterialList.FindControlRecursive<DropDownList>("UnitIdDdl");
            var date = MaterialList.FindControlRecursive<Calendar>("Date");
            var NewMaterial = new Material
            {
                Name = nameTxt.Text,
                Num = int.Parse(num.Text),
                Date = date.SelectedDate
            };
             
            Enum.TryParse<UnitEnum>(unitIdDdl.SelectedValue, out var material);
            NewMaterial.UnitId = material;
            MatServ.Create(NewMaterial);
            MaterialList.DataSource = MatServ.ReadAll()
                    .Select(c => new { c.Id, c.Name, c.Date, c.UnitId, c.Num })
                    .ToList();
            MaterialList.DataBind();
        }
    }
}