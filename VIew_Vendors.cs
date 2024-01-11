using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComponentFactory.Krypton.Toolkit;
namespace Moshtarayat
{
    public partial class VIew_Vendors : KryptonForm
    {
        Controller controllerobj;
        public VIew_Vendors()
        {
            InitializeComponent();
            controllerobj = new Controller();
        }

        private void VIew_Vendors_Load(object sender, EventArgs e)
        {
            DataTable dt = controllerobj.VandI();
            kryptonDataGridView1_Vendor.DataSource = dt;
            kryptonDataGridView1_Vendor.Refresh();
        }

        private void kryptonDataGridView1_Client_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void kryptonButton1_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kryptonDataGridView1_Vendor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          

        }
    }
}
