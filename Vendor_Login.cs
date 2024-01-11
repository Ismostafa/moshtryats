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
    public partial class Vendor_Login : KryptonForm
    {
        Controller controllerobj;
        public Vendor_Login()
        {
            controllerobj = new Controller();
            InitializeComponent();
        }

        private void Vendor_Login_Load(object sender, EventArgs e)
        {

        }

        private void Vendor_Login_LogIn_Click(object sender, EventArgs e)
        {
            if (Vendor_Login_GetStarted_FName_TextBox.Text == "" || Vendor_Login_GetStarted_Password_TextBox.Text == "")
            {
                MessageBox.Show("Empty boxes");
            }
            else
            {

                string password = "";
                DataTable dt = controllerobj.LoadPasswordV(Vendor_Login_GetStarted_FName_TextBox.Text, password);
                //   dataGridView1.DataSource = dt;
                password = dt.Rows[0][0].ToString();
                password = password.Trim();
                //   Console.WriteLine(Admin_Login_Password_TextBox.Text.ToString());
                if (Vendor_Login_GetStarted_Password_TextBox.Text.ToString() == password)
                {
                    v_site f = new v_site(Vendor_Login_GetStarted_FName_TextBox.Text);
                    f.Show();
                }
                else
                {
                    MessageBox.Show("Wrong password");
                }
            }





           /* v_site s= new v_site(Vendor_Login_GetStarted_FName_TextBox.Text);
            s.Show();*/
        }

        private void Vendor_Login_GetStarted_FName_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Vendor_Login_GetStarted_Password_TextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
