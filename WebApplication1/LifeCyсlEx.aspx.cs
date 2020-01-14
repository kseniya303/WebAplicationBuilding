using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class LifeCyklEx : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
           // Theme = "Red"; // ставим тему 
            var cont = Context;
            var req = Request;
            var resp = Response;
            if (IsPostBack)//загружается ли вся страница или обработка какого-то события
            {

            }
            var page = this;

        }
        protected void Page_Init(object sender, EventArgs e)
        { 
            TextBox1.Text = "Default"; //чтобы пропадал текст по нажатию курсора placeholder for textbox in c#
           // Theme = "Red"; // поменять в Init-е тему уже нельзя, только в preInit-е
            var pageStructure =this.Controls; 
            

        }
        protected void Page_InitComplete(object sender, EventArgs e)
        {
            TextBox2.Text = TextBox1.Text;
            var prosmotr = this.ViewState;
            if(ViewState["txtValue"]!=null)
            {
                Button1.Text = "New Text";
            }
        }
        protected void Page_PreLoad(object sender, EventArgs e)
        {

        }

        protected void Page_Load(object sender, EventArgs e)//сюда приходит данные с сервера, то что мы напишем на странице
        {
            if (ViewState["txtValue"] != null)
            {
                Button1.Text = "New Text";
            }

        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            Response.Write("ololo");//отображается в начале страницы
        }
        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);//ничего не меняем 
            Response.Write("ololo");//отображается в конце страницы
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
           if(IsValid)
           {
               TextBox2.Text = "Не пусто";
           }
            ViewState.Add("txtValue", TextBox2.Text);
        }
        protected void Page_UnLoad(object sender, EventArgs e)
        {
           
        }
    }

}