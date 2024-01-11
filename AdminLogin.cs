using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Moshtarayat
{
    public partial class AdminLogin :KryptonForm
    {
        Controller controllerobj;
        public AdminLogin()
        {
            InitializeComponent();
            controllerobj = new Controller();
            groupBox1_change_password.Hide();
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {

        }

        private void kryptonPalette1_PalettePaint(object sender, PaletteLayoutEventArgs e)
        {

        }

        private void GetStarted_Fname_Label_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_change_password_Enter(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Changepass_Click(object sender, EventArgs e)
        {
            groupBox1_change_password.Show();
        }

        private void Admin_Login_Click(object sender, EventArgs e)
        {
            if (Admin_Login_FName_TextBox.Text == "" || Admin_Login_Password_TextBox.Text == "")
            {
                MessageBox.Show("Empty boxes");
            }
            else {
                DataTable dtx = controllerobj.CheckUsernameAdmin(Admin_Login_FName_TextBox.Text);
                int check = int.Parse(dtx.Rows[0][0].ToString());
                if (check == 1)
                {
                    string password = "";
                    DataTable dt = controllerobj.LoadPasswordA(Admin_Login_FName_TextBox.Text, password);
                    //   dataGridView1.DataSource = dt;
                    password = dt.Rows[0][0].ToString();
                    password = password.Trim();
                    //   Console.WriteLine(Admin_Login_Password_TextBox.Text.ToString());
                    if (Admin_Login_Password_TextBox.Text.ToString() == password)
                    {
                        AdminProvidedFunctions f = new AdminProvidedFunctions(Admin_Login_FName_TextBox.Text);
                        f.Show();
                    }
                    else
                    {
                        MessageBox.Show("Wrong password");
                    }
                }
                else
                {
                    MessageBox.Show("Wrong Username");
                }
            }
        }

        private void Admin_Login_FName_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Admin_Login_Password_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void kryptonButton1_COnfirm_Click(object sender, EventArgs e)
        {
            if (Admin_Login_FName_TextBox.Text == "" || kryptonTextBox1_Origpass.Text == "" || kryptonTextBox2_Newpass.Text == "")
            {
                MessageBox.Show("Empty boxes");
            }
            else
            {
                int checkchange = controllerobj.ChangePasswordA(Admin_Login_FName_TextBox.Text, kryptonTextBox1_Origpass.Text, kryptonTextBox2_Newpass.Text);
              //  dataGridView1.DataSource = dt;
             //   string checkchange = dt.Rows[0][0].ToString();

                if (checkchange == 1)
                {
                    MessageBox.Show("The Password is Changed");
                }
                else
                {
                    MessageBox.Show("The Password is not Changed");
                }
            }

        }

        private void kryptonTextBox1_Origpass_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox2_Newpass_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
