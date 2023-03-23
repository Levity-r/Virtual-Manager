using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VirtualManagerWF
{
    public partial class AdminLoginForm : Form
    {
        Database database = new Database();
        private string querystring;

        public static int i { get; set; }
        public static int timer { get; set; }
        public static int x { get; set; }
        public static int y { get; set; }

        
        public AdminLoginForm()
        {

            InitializeComponent(); 
        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void демонстрацияЭкранаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string text = LoginForm.TextData;
            database.openConnection();
            var changeQuery = $"update Users set Singup = 'False' where Login = '{text}'";
            var command = new SqlCommand(changeQuery, database.getConnection());
            command.ExecuteNonQuery();

            var changeQuery1 = $"update Users set Online = 'False' where Login = '{text}'";
            var command1 = new SqlCommand(changeQuery1, database.getConnection());
            command1.ExecuteNonQuery();


            this.Hide();
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();

            database.closeConnection();
        }

        private void настройкиДоступаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 Form1 = new Form1();
            this.Hide();
            Form1.ShowDialog();
            this.Close();

        }

        public void AdminLoginForm_Load(object sender, EventArgs e)
        {
            i = 0;
            x = Location.X; y = Location.Y;
            string text = LoginForm.TextData;
            database.openConnection();
            string sHostName = Dns.GetHostName();
            string Ip = Dns.GetHostByName(sHostName).AddressList[0].ToString();

            string port = $"select Port from Users where Ip = '{Ip}' and Singup = 'True'";

            SqlCommand com = new SqlCommand(port, database.getConnection());

            string ports = com.ExecuteScalar()?.ToString();

            var changeQuery1 = $"update Users set Singup = 'True' where Login = '{text}'";

            var command3 = new SqlCommand(changeQuery1, database.getConnection());
            command3.ExecuteNonQuery();
            
            var IP = $"update Users set Ip = '{Ip}' where Login = '{text}'";
            var command1 = new SqlCommand(IP, database.getConnection());
            command1.ExecuteNonQuery();


            var changeQuery = $"update Users set Online = 'True' where Login = '{text}'";
            var command = new SqlCommand(changeQuery, database.getConnection());
            command.ExecuteNonQuery();

            database.closeConnection();
        }

        private void AdminLoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            string text = LoginForm.TextData;
            database.openConnection();
            var changeQuery = $"update Users set Online = 'False' where Login = '{text}'";
            var command = new SqlCommand(changeQuery, database.getConnection());
            command.ExecuteNonQuery();

            database.closeConnection();
        }

        private void мониторингПользователейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminLoginForm Admform = new AdminLoginForm();
            this.Hide();
            Admform.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            database.openConnection();
            string sHostName = Dns.GetHostName();
            string Ip = Dns.GetHostByName(sHostName).AddressList[0].ToString();
            string port = $"select Port from Users where Ip = '{Ip}' and Singup = 'True'";

            SqlCommand com = new SqlCommand(port, database.getConnection());

            string ports = com.ExecuteScalar()?.ToString(); 
            database.closeConnection();

            new Form2(int.Parse(ports)).Show();


            UserLoginForm userloginform = new UserLoginForm();
            userloginform.con();
            userloginform.share();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void btnPort_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
