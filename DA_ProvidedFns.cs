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
    public partial class DA_ProvidedFns : KryptonForm
    {
        Controller controllerobj;
        int ID;
        public DA_ProvidedFns(string username , string password)
        {
            InitializeComponent();
            controllerobj = new Controller();
            DataTable dt = controllerobj.RetrieveDA_ID(username, password, ID);
            ID = int.Parse(dt.Rows[0][0].ToString());
        }

        private void DA_ProvidedFns_Load(object sender, EventArgs e)
        {

        }

        private void DA_PFs_LogOut_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DA_ProvidedFns_Pickup_Button_Click(object sender, EventArgs e)
        {
            DA_PickUP_Form f = new DA_PickUP_Form(ID);
            f.Show();
        }

        private void DA_ProvidedFns_Deliver_Button_Click(object sender, EventArgs e)
        {
            DA_Deliver_Form f = new DA_Deliver_Form(ID);
            f.Show();
        }
    }
}
