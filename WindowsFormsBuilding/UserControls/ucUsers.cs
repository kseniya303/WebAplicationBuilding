using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BLL.Interfaces;
using BLL.Services;
using Common.Enums;
using Db.Model;
using Repository.Interfaces;
using Repository.Repositories;

namespace WindowsFormsBuilding.UserControls
{
    public partial class ucUsers : UserControl
    {
        public ucUsers()
        {
            InitializeComponent();
        }

        private IUserService usServ;

        public ucUsers(IUserService _usServ)
        {
            usServ = _usServ;
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e) //кнопка ОК
        {
            var Us = new User();
            Us.Name = textBox1.Text;

            Enum.TryParse<RoleEnum>(comboBox1.SelectedValue.ToString(), out var role);
            Us.RoleId = role;
            usServ.Create(Us);
            UpdateDataSource();
        }

        private void ucUsers_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = Enum.GetValues(typeof(RoleEnum));
            UpdateDataSource();
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.Columns["Id"].Visible = false;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void UpdateDataSource() // вывести список
        {
            var ListUsers = usServ.ReadAll()
                .Select(c => new { c.Id, c.Name, c.RoleId, c.IsDeleted })
                .ToList();


            dataGridView1.DataSource = ListUsers;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) //чтоб уволить
        {
            //e.RowIndex - содержит индекс строки
            var row = dataGridView1.Rows[e.RowIndex];//берем строку по индексу
            var id = (int)row.Cells["Id"].Value; //обращаемся к клетке id
            var isDeleted = (bool)row.Cells["IsDeleted"].Value;

            if (!isDeleted)
            {
                usServ.Delete(id);
            }

            UpdateDataSource();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
