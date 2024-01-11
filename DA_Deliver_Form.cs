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
    public partial class DA_Deliver_Form : KryptonForm
    {
        Controller controllerobj;
        int DA_id;
        public DA_Deliver_Form(int id)
        {
            InitializeComponent();
            controllerobj = new Controller();
            DA_id = id;
            DataTable dt = controllerobj.GetAssignedOrdersDA(DA_id);
            DA_Deliver_Order_combobox.DataSource = dt;
            DA_Deliver_Order_combobox.DisplayMember = "Or_ID";
            DA_Deliver_Order_combobox.ValueMember = "Or_ID";
        }

        private void DA_Deliver_Form_Load(object sender, EventArgs e)
        {

        }

        private void DA_PickUp_LogOut_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DA_DeliverForm_Back_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DA_DeliverForm_Deliver_Button_Click(object sender, EventArgs e)
        {
            int o = controllerobj.OrderDelivered(Convert.ToInt32(DA_Deliver_Order_combobox.SelectedValue));
            int ph = controllerobj.PHistoryDelivered(Convert.ToInt32(DA_Deliver_Order_combobox.SelectedValue));
            int notbusy = controllerobj.ClearBusyDA(DA_id);
            int d = controllerobj.InsertOrderDelivered(Convert.ToInt32(DA_Deliver_Order_combobox.SelectedValue), DA_id);
            int ClientID = 0;
            DataTable dt2 = controllerobj.GetClientID(Convert.ToInt32(DA_Deliver_Order_combobox.SelectedValue), ClientID);
            ClientID = int.Parse(dt2.Rows[0][0].ToString());
            int bonus = controllerobj.InsertBonusPointsDA(ClientID);

            if (o < 0) MessageBox.Show("Cant set order status in order table");
            else if (ph < 0) MessageBox.Show("Cant set order status in PH table");
            else if (notbusy < 0) MessageBox.Show("Cant clear DA busy flag");
            else if (d < 0) MessageBox.Show("Cant insert in order delivered table");
            else if (bonus < 0) MessageBox.Show("Cant insert bonus points");
            else MessageBox.Show("Order Delivered!");
        }
    }
}
