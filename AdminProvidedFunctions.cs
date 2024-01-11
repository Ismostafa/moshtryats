using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton;
using ComponentFactory.Krypton.Toolkit;

namespace Moshtarayat
{
    public partial class AdminProvidedFunctions : KryptonForm
    {
        Controller controllerobj;
        public AdminProvidedFunctions(string username)
        {
            InitializeComponent();
            controllerobj = new Controller();
            this.Text = "Welcome " + username;
            DataTable dt = controllerobj.IDfromfname(username);
            int id = int.Parse(dt.Rows[0][0].ToString());
            if(id==1)
            {
                kryptonButton6.Enabled = false;
                kryptonButton9.Enabled = false;
            }
            else if(id==2)
            {
                kryptonButton6.Enabled = false;
                kryptonButton2.Enabled = false;
            }
            else
            {
                kryptonButton2.Enabled = false;
                kryptonButton9.Enabled = false;
            }

        }

        private void AdminProvidedFunctions_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton4_LogOUT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kryptonButton3_PH_Click(object sender, EventArgs e)
        {
            View_PH f = new View_PH();
            f.Show();
        }

        private void kryptonButton7_Orders_Click(object sender, EventArgs e)
        {
            View_Orders f = new View_Orders();
            f.Show();
        }

        private void kryptonButton5_Clients_Click(object sender, EventArgs e)
        {
            View_Clients f = new View_Clients();
            f.Show();
        }

        private void kryptonButton1_Vendors_Click(object sender, EventArgs e)
        {
            VIew_Vendors f = new VIew_Vendors();
            f.Show();
        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            SolveProblem f = new SolveProblem();
            f.Show();
        }

        private void kryptonButton9_Click(object sender, EventArgs e)
        {
            SavePurchaseHistory f = new SavePurchaseHistory();
            f.Show();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            AssDAtoOr f = new AssDAtoOr();
            f.Show();
        }
    }
}
