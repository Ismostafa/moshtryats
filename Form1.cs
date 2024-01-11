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
    public partial class Form1 : KryptonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Update_item_Click(object sender, EventArgs e)
        {
           
        }

        private void kryptonButton2_DA_Click(object sender, EventArgs e)
        {
            DA_Login_Form f = new DA_Login_Form();
            f.Show();
        }

        private void kryptonButton1_V_Click(object sender, EventArgs e)
        {
            Vendor_Login f = new Vendor_Login();
            f.Show();
        }

        private void kryptonButton3_C_Click(object sender, EventArgs e)
        {
            CostumerLogin_Form f = new CostumerLogin_Form();
            f.Show();
        }

        private void kryptonButton1_A_Click(object sender, EventArgs e)
        {
            AdminLogin f = new AdminLogin();
            f.Show();
        }
    }
}
