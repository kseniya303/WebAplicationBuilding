using System;
using System.ComponentModel;
using System.Drawing; 
using System.Windows.Forms;
using System.IO;
using System.Security;
using System.Data.SqlClient;
using System.Data;

namespace WindowsFormsBuilding.UserControls
{
    public partial class ucFL : UserControl
    {
        public ucFL()
        {
            InitializeComponent();
        }
         
        public Button selectButton;
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            selectButton = new Button
            {
                Size = new Size(100, 20),
                Location = new Point(15, 15),
                Text = "Select file"
            };
            selectButton.Click += new EventHandler(button2_Click);
            textBox1 = new TextBox
            {
                Size = new Size(300, 300),
                Location = new Point(15, 40),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical
            };
            ClientSize = new Size(330, 360);
            Controls.Add(selectButton);
            Controls.Add(textBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var sr = new StreamReader(openFileDialog1.FileName);
                    ResetText(sr.ReadToEnd());
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void ResetText(string v)
        {
            throw new NotImplementedException();
        }

        private void ucFL_Load(object sender, EventArgs e)
        {

        }
        
        private static void SaveFileToDatabase()
        {
            string connectionString = @"Data Source=A505PCPREPOD\A203;Initial Catalog=Kseniya;Integrated Security=SSPI";
             
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = @"INSERT INTO Images VALUES (@FileName, @Title, @ImageData)";
                command.Parameters.Add("@FileName", SqlDbType.NVarChar, 50);
                command.Parameters.Add("@Title", SqlDbType.NVarChar, 50);
                command.Parameters.Add("@ImageData", SqlDbType.Image, 1000000);

                // путь к файлу для загрузки
                string filename = @"C:\Users\Eugene\Pictures\cats.jpg";
                // заголовок файла
                string title = "Коты";
                // получаем короткое имя файла для сохранения в бд
                string shortFileName = filename.Substring(filename.LastIndexOf('\\') + 1); // cats.jpg
                                                                                           // массив для хранения бинарных данных файла
                byte[] imageData;
                using (System.IO.FileStream fs = new System.IO.FileStream(filename, FileMode.Open))
                {
                    imageData = new byte[fs.Length];
                    fs.Read(imageData, 0, imageData.Length);
                }
                // передаем данные в команду через параметры
                command.Parameters["@FileName"].Value = shortFileName;
                command.Parameters["@Title"].Value = title;
                command.Parameters["@ImageData"].Value = imageData;

                command.ExecuteNonQuery();
            }
        }
    }
}
