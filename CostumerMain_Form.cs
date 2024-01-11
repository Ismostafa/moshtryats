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
    public partial class CostumerMain_Form : KryptonForm
    {
        Controller controller;
        string usforp;
        public CostumerMain_Form()
        {
            InitializeComponent();
        }

        public CostumerMain_Form(string username)
        {
            InitializeComponent();
            Username_TextBox.Text = username;
            usforp = username;
            controller = new Controller();

            DataTable dt2 = controller.SelectAllVendorCuisines();
            Cuisine_comboBox.DisplayMember = "cusine";
            Cuisine_comboBox.ValueMember = "cusine";
            Cuisine_comboBox.DataSource = dt2;

            AddItem_Button.Hide();
            Items_comboBox.Hide();
            ViewOrderItems_Button.Hide();

        }

        private void CostumerMain_Form_Load(object sender, EventArgs e)
        {
            
        }

        private void Costumer_Login_AlreadyAMember_FName_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ViewRewards_Button_Click(object sender, EventArgs e)
        {
            string username = Username_TextBox.Text;
            ViewRewards viewRewards = new ViewRewards(username);
            viewRewards.Show();
            this.Close();
        }

        private void ViewOrderItems_Button_Click(object sender, EventArgs e)
        {
            DataTable dt = controller.SelectClientIDFromUsername(Username_TextBox.Text);
            int id = int.Parse(dt.Rows[0][0].ToString());

            DataTable dt1 = controller.GetonGoingOrderID(id);
            int orderid = int.Parse(dt1.Rows[0][0].ToString());

            DataTable dt2 = controller.ViewOrderItems(orderid);

            ViewOrderItems VOI = new ViewOrderItems(Username_TextBox.Text, dt2, orderid);
            VOI.Show();
            this.Close();
        }

        private void MenuItems_DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //private void ShowRestaurants_Button_Click(object sender, EventArgs e)
        //{
        //}

        private void ShowItems_Button_Click(object sender, EventArgs e)
        {
            DataTable dt = controller.ShowVendorItems(Convert.ToInt32(Restaurant_comboBox.SelectedValue));
            MenuItems_DataGrid.DataSource = dt;
            MenuItems_DataGrid.Refresh();

            Items_comboBox.DisplayMember = "It_Name";
            Items_comboBox.ValueMember = "Item_ID";
            Items_comboBox.DataSource = dt;
        }

        private void AddItem_Button_Click(object sender, EventArgs e)
        {
            DataTable dt = controller.SelectClientIDFromUsername(Username_TextBox.Text);
            int id = int.Parse(dt.Rows[0][0].ToString());

            DataTable dt1 = controller.GetonGoingOrderID(id);
            int orderid = int.Parse(dt1.Rows[0][0].ToString());
            int res = controller.ClientAddItems(orderid, Convert.ToInt32(Items_comboBox.SelectedValue));
            if (res > 0)
            {
                MessageBox.Show("Items inserted");
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

        private void Order_Button_Click(object sender, EventArgs e)
        {
            AddItem_Button.Show();
            Items_comboBox.Show();
            ViewOrderItems_Button.Show();

            DataTable dt = controller.SelectClientIDFromUsername(Username_TextBox.Text);
            int id = int.Parse(dt.Rows[0][0].ToString());

            int res = controller.InitiateOrder(id);
            if (res > 0)
            {
                MessageBox.Show("Order inserted");
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

        private void Cuisine_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt1 = controller.SelectCuisineVendors(Cuisine_comboBox.SelectedValue.ToString());
            Restaurant_comboBox.DisplayMember = "V_Name";
            Restaurant_comboBox.ValueMember = "Vendor_ID";
            Restaurant_comboBox.DataSource = dt1;
        }

        private void UpdateBillingAddress_Button_Click(object sender, EventArgs e)
        {
            string username = Username_TextBox.Text;
            UpdateAddress UA = new UpdateAddress(username);
            UA.Show();
            this.Close();
        }

        private void LogOut_Button_Click(object sender, EventArgs e)
        {
            this.Close();
            CostumerLogin_Form CLF = new CostumerLogin_Form();
            CLF.Show();
        }

        private void ReportAProblem_Button_Click(object sender, EventArgs e)
        {
            ReportPorReturnO f = new ReportPorReturnO(usforp);
            f.Show();
        }

        private void ViewPurchaseHistory_Button_Click(object sender, EventArgs e)
        {
            ClientPurchaseHistory f = new ClientPurchaseHistory(usforp);
            f.Show();
        }
    }
}
