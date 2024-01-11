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
    public partial class CostumerLogin_Form : KryptonForm
    {
        Controller controller;
        public CostumerLogin_Form()
        {
            InitializeComponent();
            controller = new Controller();
            Costumer_Login_SignUp.Hide();
            Costumer_Login_LogIn.Hide();
            Costumer_Login_ChangePassword.Hide();
            Costumer_Login_GetStarted_FName_TextBox.Hide();
            Costumer_Login_GetStarted_LName_TextBox.Hide();
            Costumer_Login_GetStarted_Password_TextBox.Hide();
            Costumer_Login_AlreadyAMember_FName_TextBox.Hide();
            Costumer_Login_AlreadyAMember_Password_TextBox.Hide();
            GetStarted_Fname_Label.Hide();
            GetStarted_Lname_Label.Hide();
            GetStarted_Password_Label.Hide();
            AlreadyAMember_Fname_Label.Hide();
            AlreadyAMember_Password_Label.Hide();
        }

        private void CostumerLogin_Form_Load(object sender, EventArgs e)
        {

        }

        private void Costumer_Login_GetStarted_Button_Click(object sender, EventArgs e)
        {
            Costumer_Login_SignUp.Show();
            Costumer_Login_GetStarted_FName_TextBox.Show();
            Costumer_Login_GetStarted_Password_TextBox.Show();
            Costumer_Login_GetStarted_LName_TextBox.Show();
            GetStarted_Fname_Label.Show();
            GetStarted_Password_Label.Show();
            GetStarted_Lname_Label.Show();

            Costumer_Login_LogIn.Hide();
            Costumer_Login_AlreadyAMember_FName_TextBox.Hide();
            Costumer_Login_AlreadyAMember_Password_TextBox.Hide();
            AlreadyAMember_Fname_Label.Hide();
            AlreadyAMember_Password_Label.Hide();
            Costumer_Login_ChangePassword.Hide();
        }

        private void Costumer_Login_AlreadyAMember_Button_Click(object sender, EventArgs e)
        {
            Costumer_Login_LogIn.Show();
            Costumer_Login_AlreadyAMember_FName_TextBox.Show();
            Costumer_Login_AlreadyAMember_Password_TextBox.Show();
            AlreadyAMember_Fname_Label.Show();
            AlreadyAMember_Password_Label.Show();
            Costumer_Login_ChangePassword.Show();

            Costumer_Login_SignUp.Hide();
            Costumer_Login_GetStarted_FName_TextBox.Hide();
            Costumer_Login_GetStarted_LName_TextBox.Hide();
            Costumer_Login_GetStarted_Password_TextBox.Hide();
            GetStarted_Fname_Label.Hide();
            GetStarted_Password_Label.Hide();
            GetStarted_Lname_Label.Hide();

        }

        private void Costumer_Login_SignUp_Click(object sender, EventArgs e)
        {

            int res = controller.AddClient(Costumer_Login_GetStarted_FName_TextBox.Text, 
                Costumer_Login_GetStarted_LName_TextBox.Text, 
                Costumer_Login_GetStarted_Password_TextBox.Text);

            if(res > 0)
            {
                MessageBox.Show("Welcome to MOSHTARAYAT!, " + Costumer_Login_GetStarted_FName_TextBox.Text);
                DataTable dt3 = controller.LoadClientUsername(Costumer_Login_GetStarted_FName_TextBox.Text,
                    Costumer_Login_GetStarted_LName_TextBox.Text, Costumer_Login_GetStarted_Password_TextBox.Text);
                string username = dt3.Rows[0][0].ToString();
                username = username.Trim();

                this.Hide();
                CostumerMain_Form CMF = new CostumerMain_Form(username);
                CMF.Show();
                Costumer_Login_GetStarted_FName_TextBox.Text = "";
                Costumer_Login_GetStarted_LName_TextBox.Text = "";
                Costumer_Login_GetStarted_Password_TextBox.Text = "";
            }
            else
            {
                MessageBox.Show("Failed to insert a new user");
            }
        }

        private void Costumer_Login_LogIn_Click(object sender, EventArgs e)
        {

            DataTable dt = controller.CheckUsernameClient(Costumer_Login_AlreadyAMember_FName_TextBox.Text);
            int check = int.Parse(dt.Rows[0][0].ToString());
            if(check == 0)
            {
                MessageBox.Show("Username not found.");
                Costumer_Login_AlreadyAMember_FName_TextBox.Text = "";
                Costumer_Login_AlreadyAMember_Password_TextBox.Text = "";
            }
            else
            {
                string dummy = "";
                DataTable dt1 = controller.LoadPasswordClient(Costumer_Login_AlreadyAMember_FName_TextBox.Text, dummy);
                string stroredpassword = dt1.Rows[0][0].ToString();
                stroredpassword = stroredpassword.Trim();

                DataTable dt2 = controller.CheckPasswordClient(Costumer_Login_AlreadyAMember_FName_TextBox.Text, Costumer_Login_AlreadyAMember_Password_TextBox.Text);
                int check1 = int.Parse(dt2.Rows[0][0].ToString());
                if(check1 == 0)
                {
                    MessageBox.Show("Wrong password entered for " + Costumer_Login_AlreadyAMember_FName_TextBox.Text);
                    Costumer_Login_AlreadyAMember_Password_TextBox.Text = "";
                }
                else
                {
                    MessageBox.Show("Welcome back to MOSHTARAYAT!, " + Costumer_Login_AlreadyAMember_FName_TextBox.Text);
                    this.Hide();
                    CostumerMain_Form CMF = new CostumerMain_Form(Costumer_Login_AlreadyAMember_FName_TextBox.Text);
                    CMF.Show();
                }
            }

        }

        private void Costumer_Login_GetStarted_FName_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Costumer_Login_GetStarted_Password_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Costumer_Login_AlreadyAMember_FName_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Costumer_Login_AlreadyAMember_Password_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void GetStarted_Fname_Label_Click(object sender, EventArgs e)
        {

        }

        private void GetStarted_Password_Label_Click(object sender, EventArgs e)
        {

        }

        private void AlreadyAMember_Fname_Label_Click(object sender, EventArgs e)
        {

        }

        private void AlreadyAMember_Password_Label_Click(object sender, EventArgs e)
        {

        }

        private void SignUpGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void LoginGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void Costumer_Login_ChangePassword_Click(object sender, EventArgs e)
        {

        }

        private void GetStarted_Lname_Label_Click(object sender, EventArgs e)
        {

        }

        private void Costumer_Login_GetStarted_LName_TextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
