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
    public partial class UpdateAddress : KryptonForm
    {
        Controller controller;
        public UpdateAddress()
        {
            InitializeComponent();
        }

        public UpdateAddress(string username)
        {
            InitializeComponent();
            controller = new Controller();
            Username_TextBox.Text = username;

            DataTable dt = controller.SelectClientIDFromUsername(Username_TextBox.Text);
            int clientid = int.Parse(dt.Rows[0][0].ToString());

            DataTable dt1 = controller.GetAllClientAddresses(clientid);
            Addresses_DataGrid.DataSource = dt1;

            DataTable dt2 = controller.SelectClientStreets(clientid);
            DeleteStreet_ComboBox.DisplayMember = "Street";
            DeleteStreet_ComboBox.ValueMember = "Street";
            DeleteStreet_ComboBox.DataSource = dt2;

        }

        private void UpdateAddress_Load(object sender, EventArgs e)
        {

        }

        private void Insert_Button_Click(object sender, EventArgs e)
        {
            DataTable dt = controller.SelectClientIDFromUsername(Username_TextBox.Text);
            int clientid = int.Parse(dt.Rows[0][0].ToString());
            int res = controller.InsertNewAddress(InsertCity_TextBox.Text, InsertStreet_TextBox.Text, clientid);
            if(res == 0)
            {
                MessageBox.Show(InsertCity_TextBox.Text);
                MessageBox.Show("Insertion failed.");
            }
            DataTable dt1 = controller.GetAllClientAddresses(clientid);
            Addresses_DataGrid.DataSource = dt1;
            DeleteStreet_ComboBox.DataSource = dt1;

        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            DataTable dt = controller.SelectClientIDFromUsername(Username_TextBox.Text);
            int clientid = int.Parse(dt.Rows[0][0].ToString());
            int res = controller.DeleteAddress(DeleteStreet_ComboBox.SelectedValue.ToString(), clientid);

            DataTable dt2 = controller.GetAllClientAddresses(clientid);
            Addresses_DataGrid.DataSource = dt2;
            DeleteStreet_ComboBox.DataSource = dt2;
        }

        private void Back_Button_Click(object sender, EventArgs e)
        {
            CostumerMain_Form costumerMain_Form = new CostumerMain_Form(Username_TextBox.Text);
            costumerMain_Form.Show();
            this.Close();
        }
    }
}
