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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Moshtarayat
{
    public partial class ClientPurchaseHistory : KryptonForm
    {
        Controller controller;

        public ClientPurchaseHistory(string username)
        {
            InitializeComponent();
            Username_TextBox.Text = username;
            controller = new Controller();
            DataTable dt = controller.SelectClientIDFromUsername(username);
            int client_id = int.Parse(dt.Rows[0][0].ToString());
            DataTable dt1 = controller.ordersdelievertoclient(client_id);
            Orders_ComboBox.DataSource = dt1;
            Orders_ComboBox.DisplayMember = "Or_ID";
            Orders_ComboBox.ValueMember = "Or_ID";
            // Orders_ComboBox.DisplayMember = ""
            Orders_ComboBox.DataSource = dt1;
        }

        private void ClientPurchaseHistory_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Orders_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Submit_Button_Click(object sender, EventArgs e)
        {
            int x = Int32.Parse(Rating_TextBox.Text);
            int y = Convert.ToInt32(Orders_ComboBox.SelectedValue);
            DataTable dt = controller.SelectClientIDFromUsername(Username_TextBox.Text);
            int client_id = int.Parse(dt.Rows[0][0].ToString());
            int r = controller.Give_NRx(x, y, client_id);
        }

        private void Rating_TextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}