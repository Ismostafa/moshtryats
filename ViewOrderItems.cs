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

    public partial class ViewOrderItems : KryptonForm
    {
        int flag = -1;

        int clientid;
        int ORDERID;
        float COST;
        Controller controller;
        public ViewOrderItems()
        {
            InitializeComponent();
        }

        public ViewOrderItems(string username, DataTable dt, int orderid)
        {
            InitializeComponent();
            ORDERID = orderid;
            controller = new Controller();
            Username_TextBox.Text = username;
            SelectedItems_DataGrid.DataSource = dt;

            DataTable dt1 = controller.GetOrderTotalCost(orderid);
            string cost = dt1.Rows[0][0].ToString();
            COST = float.Parse(dt1.Rows[0][0].ToString());
            OrderTotalPrice_TextBox.Text = cost + " EGP";

            DataTable dt2 = controller.SelectClientIDFromUsername(Username_TextBox.Text);
            int clientid = int.Parse(dt2.Rows[0][0].ToString());

            DataTable dt3 = controller.SelectClientStreets(clientid);
            Street_ComboBox.DisplayMember = "Street";
            Street_ComboBox.ValueMember = "Street";
            Street_ComboBox.DataSource = dt3;

        }

        private void ViewOrderItems_Load(object sender, EventArgs e)
        {

        }

        private void Username_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SelectedItems_DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void OrderTotalPrice_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Street_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt4 = controller.SelectCityBasedOnStreet(Street_ComboBox.SelectedValue.ToString());
            string city = dt4.Rows[0][0].ToString();
            city = city.Trim();
            City_TextBox.Text = city;
        }

        private void SelectPaymentInformation_Button_Click(object sender, EventArgs e)
        {

            if (Cash_RadioButton.Checked)
            {
                int res = controller.UpdatePaymentInfo("Cash", clientid);
            }
            else if (Visa_RadioButton.Checked)
            {
                int res = controller.UpdatePaymentInfo("Visa", clientid);
            }
            else if (!Cash_RadioButton.Checked && !Visa_RadioButton.Checked)
            {
                MessageBox.Show("You have to choose your payment information.");
            }
        }

        private void Visa_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            flag = 1;
        }

        private void Cash_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            flag = 1;
        }

        private void ShowItems_Button_Click(object sender, EventArgs e)
        {

        }

        private void ConfirmOrder_Button_Click(object sender, EventArgs e)
        {

            DataTable dt2 = controller.SelectClientIDFromUsername(Username_TextBox.Text);
            int ClientID = int.Parse(dt2.Rows[0][0].ToString());

            if (City_TextBox.Text == "")
            {
                MessageBox.Show("You have to insert a billing address from the main menu");
            }
            else if (flag == -1)
            {
                MessageBox.Show("You have to choose your payment information.");
            }
            else
            {
                int res1 = controller.ConfirmOrderIntoCO(ClientID, ORDERID);
                if (res1 > 0)
                {
                    MessageBox.Show("ConfirmOrder inserted");
                }
                else
                {
                    MessageBox.Show("Failed");
                }
                int res2 = controller.ConfirmOrderIntoPH(ORDERID, 2, COST);
                if (res2 > 0)
                {
                    MessageBox.Show("PH inserted");
                }
                else
                {
                    MessageBox.Show("Failed");
                }
                int res3 = controller.UpdateOrderTime(ORDERID);
                if (res3 > 0)
                {
                    MessageBox.Show("Update Completed");
                }
                else
                {
                    MessageBox.Show("Failed");
                }
            }
        }

        private void Back_Button_Click(object sender, EventArgs e)
        {
            DataTable dt2 = controller.SelectClientIDFromUsername(Username_TextBox.Text);
            int ClientID = int.Parse(dt2.Rows[0][0].ToString());

            int res = controller.UpdateOrderStatus(ClientID);
            CostumerMain_Form costumerMain_Form = new CostumerMain_Form(Username_TextBox.Text);
            costumerMain_Form.Show();
            this.Close();
        }
    }
}
