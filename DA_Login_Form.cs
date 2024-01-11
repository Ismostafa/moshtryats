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

namespace Moshtarayat
{
    public partial class DA_Login_Form : KryptonForm
    {
        Controller controllerobj;
        public DA_Login_Form()
        {
            InitializeComponent();
            label1.Hide();
            label2.Hide();
            DA_Login_NewPass_textbokx.Hide();
            DA_Login_OldPass_textbox.Hide();
            DA_Login_ConfirmPass_button.Hide();
            controllerobj = new Controller();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void DA_Login_Button_Click(object sender, EventArgs e)
        {
            if (DA_Login_Username_TextBox.Text == "" || DA_Login_Password_TextBox.Text == "")
            {
                MessageBox.Show("Empty boxes");
            }
            else
            {

                string password = "";
                DataTable dt = controllerobj.LoadPassDA(DA_Login_Username_TextBox.Text, password);
                //   dataGridView1.DataSource = dt;
                password = dt.Rows[0][0].ToString();
                password = password.Trim();
                //   Console.WriteLine(Admin_Login_Password_TextBox.Text.ToString());
                if (DA_Login_Password_TextBox.Text.ToString() == password)
                {
                    DA_ProvidedFns f = new DA_ProvidedFns(DA_Login_Username_TextBox.Text, DA_Login_Password_TextBox.Text);
                    f.Show();
                }
                else
                {
                    MessageBox.Show("Wrong password");
                }
            }
        }

    
        private void kryptonButton1_Click_1(object sender, EventArgs e)
        {
            label1.Show();
            label2.Show();
            DA_Login_NewPass_textbokx.Show();
            DA_Login_OldPass_textbox.Show();
            DA_Login_ConfirmPass_button.Show();
        }

        private void DA_Login_Form_Load(object sender, EventArgs e)
        {

        }

        private void DA_Login_ConfirmPass_button_Click(object sender, EventArgs e)
        {
            if (DA_Login_Username_TextBox.Text == "" || DA_Login_OldPass_textbox.Text == "" || DA_Login_NewPass_textbokx.Text == "")
            {
                MessageBox.Show("Empty boxes");
            }
            else
            {
                int checkchange = controllerobj.ChangePassDA(DA_Login_Username_TextBox.Text, DA_Login_OldPass_textbox.Text, DA_Login_NewPass_textbokx.Text);
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

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
