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
    public partial class DA_PickUP_Form : KryptonForm
    {
        Controller controllerobj;
        int DA_id;
        public DA_PickUP_Form(int id)
        {
            InitializeComponent();
            controllerobj = new Controller();
            DA_id = id;
            DataTable dt = controllerobj.GetAssignedOrdersDA(DA_id);
            DA_Pickup_Order_combobox.DataSource = dt;
            DA_Pickup_Order_combobox.DisplayMember = "Or_ID";
            DA_Pickup_Order_combobox.ValueMember = "Or_ID";
        }

        private void DA_PickUP_Form_Load(object sender, EventArgs e)
        {

        }

        private void DA_PFs_LogOut_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DA_PickupForm_Back_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DA_PickupForm_Pickup_Button_Click(object sender, EventArgs e)
        {
            int o = controllerobj.OrderCollected(Convert.ToInt32(DA_Pickup_Order_combobox.SelectedValue));
            int ph = controllerobj.PHistoryCollected(Convert.ToInt32(DA_Pickup_Order_combobox.SelectedValue));
            int busy = controllerobj.SetBusyDA(DA_id);

            if (o < 0) MessageBox.Show("Cant set order status in order table");
            else if (ph < 0) MessageBox.Show("Cant set order status in PH table");
            else if (busy < 0) MessageBox.Show("Cant set DA busy");
            else MessageBox.Show("Order Picked UP!");
        }
    }
}
