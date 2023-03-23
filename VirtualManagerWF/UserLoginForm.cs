using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Drawing.Imaging;
using System.Runtime.Serialization.Formatters.Binary;

namespace VirtualManagerWF
{
    public partial class UserLoginForm : Form
    {

        private readonly TcpClient client = new TcpClient();
        private NetworkStream mainStream;
        private int portNumber;

        int i = 0;
        int a = 1;
        Database database = new Database();

        private static Image GrabDesktop()
        {
            Rectangle bound = Screen.PrimaryScreen.Bounds;
            Bitmap screenshot = new Bitmap(bound.Width, bound.Height, PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(screenshot);
            graphics.CopyFromScreen(bound.X, bound.Y, 0, 0, bound.Size, CopyPixelOperation.SourceCopy);

            return (screenshot);
        }

        private void SendDesktopImage()
        {
            BinaryFormatter binFormatter = new BinaryFormatter();
            mainStream = client.GetStream();
            binFormatter.Serialize(mainStream, GrabDesktop());
        }

        public UserLoginForm()
        {
            InitializeComponent();
        }

        public void UserLoginForm_Load(object sender, EventArgs e)
        {

            string text = LoginForm.TextData;
            database.openConnection();
            string sHostName = Dns.GetHostName();
            string Ip = Dns.GetHostByName(sHostName).AddressList[0].ToString();

            string port = $"select Portsing from Users where Ip = '{Ip}' and Singup = 'False'";

            string ip = $"select Ipsing from Users where Ip = '{Ip}' and Admin = 'False'";

            SqlCommand com = new SqlCommand(port, database.getConnection());

            SqlCommand com1 = new SqlCommand(ip, database.getConnection());

            string ports = com.ExecuteScalar()?.ToString();
            string ips = com1.ExecuteScalar()?.ToString();

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
   
        private void проверкаПодключнияToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = LoginForm.TextData;
            Database database = new Database();
            database.openConnection();
            LoginForm loginForm = new LoginForm();
            var changeQuery = $"update Users set Singup = 'False' where Login = '{text}'";

            var changeQuery1 = $"update Users set Online = 'False' where Login = '{text}'";
            var command1 = new SqlCommand(changeQuery1, database.getConnection());
            command1.ExecuteNonQuery();

            var command = new SqlCommand(changeQuery, database.getConnection());
            command.ExecuteNonQuery();
            this.Hide();
            loginForm.ShowDialog();
            this.Close();
            database.closeConnection();
        }

        private void UserLoginForm_Leave(object sender, EventArgs e)
        {
        }

        private void UserLoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            string text = LoginForm.TextData;
            database.openConnection();
            var changeQuery = $"update Users set Online = 'False' where Login = '{text}'";
            var command = new SqlCommand(changeQuery, database.getConnection());
            command.ExecuteNonQuery();

            database.closeConnection();
        }

        public void con()
        {
            database.openConnection();
            string sHostName = Dns.GetHostName();
            string Ip = Dns.GetHostByName(sHostName).AddressList[0].ToString();
            string ipsing = $"select Ipsing from Users where Ip = '{Ip}' and Admin = 'False'";
            string portsing = $"select Portsing from Users where Ip = '{Ip}' and Admin = 'False'";
            SqlCommand com = new SqlCommand(ipsing, database.getConnection());
            SqlCommand com1 = new SqlCommand(portsing, database.getConnection());

            string Ipsing = com.ExecuteScalar()?.ToString();
            int Portsing = int.Parse(com1.ExecuteScalar()?.ToString());

            portNumber = Portsing;
            try
            {
                client.Connect(Ipsing, Portsing); 

            }
            catch (Exception)
            {
                MessageBox.Show("Failed to connect");

            }
        }

        public void share()
        {
            if (AdminLoginForm.timer == 1)
            {
                timer1.Start();

            }
            else
            {
                timer1.Stop();
            }
        }
        private void btnCon_Click(object sender, EventArgs e)
        {
           
        }

        private void btnShare_Click(object sender, EventArgs e)
        {
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            SendDesktopImage();
        }
    }
}
