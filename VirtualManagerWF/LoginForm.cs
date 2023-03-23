using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;

namespace VirtualManagerWF
{
    public partial class LoginForm : Form
    {

        public static string TextData { get; set; }
        Database database = new Database();
        public LoginForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            database.openConnection(); 

            string sHostName = Dns.GetHostName();
            string Ip = Dns.GetHostByName(sHostName).AddressList[0].ToString();

            string searchString = $"select Singup from Users where Ip = '{Ip}' and Singup = 'True'";

            string Login = $"select Login from Users where Ip = '{Ip}' and Singup = 'True'";

            string Pas = $"select Password from Users where Ip = '{Ip}' and Singup = 'True'";

            string Admin = $"select Admin from Users where Ip = '{Ip}' and Singup = 'True'";

            string Online = $"select Online from Users where Ip = '{Ip}' and Singup = 'True'";

            SqlCommand com = new SqlCommand(searchString, database.getConnection());

            SqlCommand com1 = new SqlCommand(Login, database.getConnection());

            SqlCommand com2 = new SqlCommand(Pas, database.getConnection());

            SqlCommand com3 = new SqlCommand(Admin, database.getConnection());

            SqlCommand com4 = new SqlCommand(Online, database.getConnection());

            string singup = com.ExecuteScalar()?.ToString();
            string log = com1.ExecuteScalar()?.ToString();
            string pas = com2.ExecuteScalar()?.ToString();
            string adm = com3.ExecuteScalar()?.ToString();
            string online = com4.ExecuteScalar()?.ToString();

            if (singup == "True" && online == "False")
            {
                if (adm == "False")
                {
                    UserLoginForm loginForm = new UserLoginForm();
                    LoginForm.TextData = log;
                    loginForm.ShowDialog();
                    this.Close();
                    this.Hide();
                }

                if (adm == "True")
                {
                    AdminLoginForm loginForm = new AdminLoginForm();

                    LoginForm.TextData = log;
                    loginForm.ShowDialog();
                    this.Close();
                    this.Hide();

                }

            }
            database.closeConnection();
        }
        
        private void Update()
        {
            textBoxPassword.PasswordChar = '*';
            textBoxLogin.MaxLength = 50;
            textBoxPassword.MaxLength = 50;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        
        }

        private void buttonLog_in_Click(object sender, EventArgs e)
        {
            var loginUser = textBoxLogin.Text;
            var passUser = textBoxPassword.Text;

            loginUser.Trim(); ;
            passUser.Trim(); ;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            DataTable table2 = new DataTable();

            string querystring = $"select ID, Login, Password from Users where Login = '{loginUser}' and Password = '{passUser}' and Admin = 'True' and Singup = 'False'";
            string querystring2 = $"select ID, Login, Password from Users where Login = '{loginUser}' and Password = '{passUser}' and Admin = 'False' and Singup = 'False'";

            SqlCommand command = new SqlCommand(querystring, database.getConnection());
            SqlCommand command2 = new SqlCommand(querystring2, database.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            adapter.SelectCommand = command2;
            adapter.Fill(table2);

            database.openConnection();

            if (table.Rows.Count > 0)
            {
                AdminLoginForm loginForm = new AdminLoginForm();
               
                LoginForm.TextData = textBoxLogin.Text;
                this.Hide();
                loginForm.ShowDialog();
                this.Close();
            }
            else if (table2.Rows.Count > 0)
            {
                MessageBox.Show("Вы успешно вошли", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UserLoginForm loginForm = new UserLoginForm();
                var changeQuery = $"update Users set Singup = 'True' where Login = '{loginUser}' and Password = '{passUser}'";

                var command4 = new SqlCommand(changeQuery, database.getConnection());

                command4.ExecuteNonQuery();
                LoginForm.TextData = textBoxLogin.Text;
                this.Hide();
                loginForm.ShowDialog();
                this.Close();
            } else
            {
                MessageBox.Show("Такого аккаунта нет", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            database.closeConnection();


        }
    }
}
