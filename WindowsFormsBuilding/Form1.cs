using System; 
using System.Drawing; 
using System.Windows.Forms;
using WindowsFormsBuilding.UserControls;

namespace WindowsFormsBuilding
{
    public partial class Form1 : Form
    {

        public Form1(ucUsers ucU)
        {

            InitializeComponent();
            ucU.Parent = this;
            ucUsers1 = ucU;
            
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
         
        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ucGreetings1.Visible = false;
            ucUsers1.Visible = true;
            ucFL1.Visible = false;

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ucGreetings1.Visible = true;
            ucUsers1.Visible = false;
            ucGreetings1.Size = new Size(900, 600);
            ucGreetings1.Location = new Point(20, 20);
            ucFL1.Visible = false;

        }

        private void materialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ucGreetings1.Visible = false;
            ucUsers1.Visible = false;
            ucFL1.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            ucUsers1.Size = new Size(900, 600);
            ucUsers1.Location =new Point(20, 20);
        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            
        }

        private void fLToolStripMenuItem_Click(object sender, EventArgs e)//что показывать
        {
            ucGreetings1.Visible = false;
            ucUsers1.Visible = false;
            ucFL1.Visible = true;

        }

        private void textBox1_TextChanged(object sender, EventArgs e) // текст бокс, экспорт импорт
        {
            ucGreetings1.Visible = false;
            ucUsers1.Visible = false;
            ucFL1.Visible = false; 
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e) //textBox в загрузке
        {

        }

        private void button1_Click(object sender, EventArgs e)// в загрузке
        {

        }

        private void button2_Click(object sender, EventArgs e)//  в загрузке
        {

        }
    }
}
