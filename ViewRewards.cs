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
    public partial class ViewRewards : KryptonForm
    {
        int SelectedRewardID;
        Controller controller;
        public ViewRewards()
        {
            InitializeComponent();
        }

        public ViewRewards(string username)
        {
            InitializeComponent();
            controller = new Controller();
            Username_TextBox.Text = username;

            DataTable dt = controller.GetallRewards();
            ListOfRewards_DataGrid.DataSource = dt;

            Rewards_ComboBox.DisplayMember = "R_Type";
            Rewards_ComboBox.ValueMember = "R_ID";
            Rewards_ComboBox.DataSource = dt;

            DataTable dt1 = controller.SelectClientIDFromUsername(Username_TextBox.Text);
            int clientid = int.Parse(dt1.Rows[0][0].ToString());

            SelectedRewardID = Convert.ToInt32(Rewards_ComboBox.SelectedValue);
            DataTable dt2 = controller.GetClientTotalBonusPoints(clientid);
            int ClientPoints;
            string TBP;
            if (dt2.Rows.Count == 1)
            {
                ClientPoints = 0;
                TBP = "0";
            }
            else
            {
                ClientPoints = int.Parse(dt2.Rows[0][0].ToString());
                TBP = dt2.Rows[0][0].ToString();
            }

            BonusPointsBalance_TextBox.Text = TBP + " Points";
        }

        private void ViewRewards_Load(object sender, EventArgs e)
        {

        }

        private void RedeemRewards_Button_Click(object sender, EventArgs e)
        {
            DataTable dt = controller.SelectClientIDFromUsername(Username_TextBox.Text);
            int clientid = int.Parse(dt.Rows[0][0].ToString());

            DataTable dt1 = controller.GetRewardEquivalentPoints(Convert.ToInt32(Rewards_ComboBox.SelectedValue));
            int RewardPoints = int.Parse(dt1.Rows[0][0].ToString());

            DataTable dt2 = controller.GetClientTotalBonusPoints(clientid);
            int ClientPoints;
            if(dt2.Rows.Count == 1)
            {
                ClientPoints = 0;
            }
            else
            {
                ClientPoints = int.Parse(dt2.Rows[0][0].ToString());
            }

            if (ClientPoints < RewardPoints)
            {
                MessageBox.Show("Insufficient Points.");
            }
            else
            {
                MessageBox.Show("Congratulations on reddeming your gift.");
                int res = controller.AddBonusPoints(clientid, -1 * RewardPoints);
                int res2 = controller.Redeemed(clientid, Convert.ToInt32(Rewards_ComboBox.SelectedValue));
                DataTable dt3 = controller.GetClientTotalBonusPoints(clientid);
                string TBP = dt3.Rows[0][0].ToString();
                BonusPointsBalance_TextBox.Text = TBP + " Points";
            }
        }

        private void Rewards_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedRewardID = Convert.ToInt32(Rewards_ComboBox.SelectedValue);
        }

        private void Back_Button_Click(object sender, EventArgs e)
        {
            CostumerMain_Form costumerMain_Form = new CostumerMain_Form(Username_TextBox.Text);
            costumerMain_Form.Show();
            this.Close();
        }
    }
}
