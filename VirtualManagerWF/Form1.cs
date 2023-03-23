using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.CodeDom;
using System.Net;

namespace VirtualManagerWF
{
    enum RowState
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }
    public partial class Form1 : VirtualManagerWF.AdminLoginForm
    {
        int i = 0;
        Database database = new Database();
        int selectedRow;
        public Form1()
        {
            InitializeComponent();

        }
         
        public void CreateColumns()
        {
            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("Surname","Surname");
            dataGridView1.Columns.Add("Login","Login");
            dataGridView1.Columns.Add("Admin","Admin");
            dataGridView1.Columns.Add("Password","Password");
            dataGridView1.Columns.Add("Ip", "Ip");
            dataGridView1.Columns.Add("StationaryIp", "StationaryIp");
            dataGridView1.Columns.Add("ConnectedToIp", "ConnectedToIp");
            dataGridView1.Columns.Add("ConnectedToPort", "ConnectedToPort");
            dataGridView1.Columns.Add("IsNew", String.Empty);
            dataGridView1.Columns[10].Visible= false;
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetBoolean(4), record.GetString(5), record.GetString(8), record.GetBoolean(9), record.GetString(14), record.GetString(15), RowState.ModifiedNew);
        }
       
        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            String queryString = $"Select * from Users";

            SqlCommand command = new SqlCommand(queryString, database.getConnection());

            database.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAdmin.Checked == true)
            {
                labeipstch.Enabled = false;
                checkBoxip.Enabled = false;
                labelip.Enabled = false;
                textBoxip.Enabled = false;
                labelConIp.Enabled = false;
                textBoxConip.Enabled = false;   
                labelConPort.Enabled = false;
                textBoxConPort.Enabled = false;

            }
            else
            {
                labeipstch.Enabled = true;
                checkBoxip.Enabled = true;
                labelip.Enabled = true;
                textBoxip.Enabled = true;
                labelConPort.Enabled = true;
                textBoxConPort.Enabled = true;
                labelConIp.Enabled = true;
                textBoxConip.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxSearch.Text = $"Вместо True либо False пишите 1 или 0";
            
            CreateColumns();
            RefreshDataGrid(dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow= e.RowIndex;   
            
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                textBoxName.Text = row.Cells[1].Value.ToString();
                textBoxSurname.Text = row.Cells[2].Value.ToString();
                textBoxLogin.Text = row.Cells[3].Value.ToString();
                checkBoxAdmin.Checked = (Boolean)row.Cells[4].Value;
                textBoxPassword.Text = row.Cells[5].Value.ToString();
                checkBoxip.Checked = (Boolean)row.Cells[7].Value;
                textBoxip.Text = row.Cells[6].Value.ToString();
                textBoxConip.Text = row.Cells[8].Value.ToString();
                textBoxConPort.Text = row.Cells[9].Value.ToString();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
            ClearFields();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            database.openConnection();

            var Name = textBoxName.Text;
            var Surname = textBoxSurname.Text;
            var Login = textBoxLogin.Text;
            var Password = textBoxPassword.Text;
            bool Admin = checkBoxAdmin.Checked;
            bool statIp = checkBoxip.Checked;
            var ip = textBoxip.Text;
            var Conip = textBoxConip.Text;
            var ConPort = textBoxConPort.Text;


            Name.Trim();
            Surname.Trim();
            Login.Trim();   
            Password.Trim(); 
            ip.Trim();
            Conip.Trim();   
            ConPort.Trim(); 


            if (Name != string.Empty && Surname != string.Empty && Login != string.Empty && Password != string.Empty)
            {
                var addQuery = $"insert into Users (Name, Surname, Login, Admin, Password, Ip, Stachip, Ipsing, Portsing) values ('{Name}', '{Surname}', '{Login}', '{Admin}', '{Password}', '{ip}', '{statIp}', '{Conip}', '{ConPort}')";

                var command = new SqlCommand(addQuery, database.getConnection());
                command.ExecuteNonQuery();

                MessageBox.Show("Запись успешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "Ошмбка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            database.closeConnection();
        }

        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from Users where concat (id, Name, Surname, Login, Password, Admin, Ip, Stachip, Ipsing, Portsing) like '%" + textBoxSearch.Text + "%'";

            SqlCommand com = new SqlCommand(searchString, database.getConnection());

            database.openConnection();

            SqlDataReader read = com.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRow(dgw,read);
            }
            read.Close();
        }

        private void deleteRow()
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            dataGridView1.Rows[index].Visible= false;

            if (dataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView1.Rows[index].Cells[10].Value = RowState.Deleted;
                return;
            }
            dataGridView1.Rows[index].Cells[10].Value = RowState.Deleted;

        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }

        private void ClearFields()
        {
            textBoxName.Text = string.Empty;
            textBoxSurname.Text = string.Empty;
            textBoxLogin.Text = string.Empty;
            textBoxPassword.Text = string.Empty;
            checkBoxAdmin.Checked = false;
            checkBoxip.Checked = false;
            textBoxip.Text = string.Empty;
            textBoxConip.Text = string.Empty;
            textBoxConPort.Text = string.Empty;
        }
        private new void Update()
        {
            database.openConnection();

            for(int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[10].Value;  

                if(rowState == RowState.Existed)
                {
                    continue;
                }

                if(rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from Users where Id = '{id}'";

                    var command = new SqlCommand(deleteQuery, database.getConnection());
                    command.ExecuteNonQuery();

                }

                if(rowState == RowState.Modified)
                {
                    var Id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    string Name = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    string Surname = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    string Login = dataGridView1.Rows[index].Cells[3].Value.ToString();
                    string Admin = dataGridView1.Rows[index].Cells[4].Value.ToString();
                    string Password = dataGridView1.Rows[index].Cells[5].Value.ToString();
                    string ip = dataGridView1.Rows[index].Cells[6].Value.ToString();
                    string statIp = dataGridView1.Rows[index].Cells[7].Value.ToString(); 
                    string Conip = dataGridView1.Rows[index].Cells[8].Value.ToString();
                    string ConPort = dataGridView1.Rows[index].Cells[9].Value.ToString();

                    var changeQuery = $"update Users set Name = '{Name}', Surname = '{Surname}', Login = '{Login}',Admin = '{Admin}', Password = '{Password}', Stachip = '{statIp}', Ip = '{ip}', Ipsing = '{Conip}', Portsing = '{ConPort}' where Id ='{Id}'";

                    var command = new SqlCommand(changeQuery, database.getConnection());
                    command.ExecuteNonQuery();
                    

                }
            }
            database.closeConnection();

            ClearFields();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            deleteRow();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void Change()
        {
            DataGridViewRow row = dataGridView1.Rows[selectedRow];
            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;
            var id = row.Cells[0].Value.ToString();
            var Name = textBoxName.Text;
            var Surname = textBoxSurname.Text;
            var Login = textBoxLogin.Text;  
            var Password = textBoxPassword.Text;
            bool Admin = checkBoxAdmin.Checked;
            bool staticIP = checkBoxip.Checked;
            string ip = textBoxip.Text;
            string Conip = textBoxConip.Text;
            string ConPort = textBoxConPort.Text;


            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() !=string.Empty) { 
            if (Name != string.Empty && Surname != string.Empty && Login != string.Empty && Password != string.Empty && ip != string.Empty && Conip != string.Empty && ConPort != string.Empty)
            {
                dataGridView1.Rows[selectedRowIndex].SetValues(id, Name,Surname, Login, Admin, Password,ip , staticIP, Conip, ConPort);
                dataGridView1.Rows[selectedRowIndex].Cells[10].Value = RowState.Modified; 
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Change();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxip_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxip.Checked == true)
            {
                labelip.Enabled = true;
                textBoxip.Enabled = true;
            }
            else
            {
                labelip.Enabled = false;
                textBoxip.Enabled = false;  
            }
        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void textBoxSearch_Click(object sender, EventArgs e)
        {
            
            if (i < 1)
            {
                textBoxSearch.Text = string.Empty;
                i++;
            }
        }

        private void textBoxSearch_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
