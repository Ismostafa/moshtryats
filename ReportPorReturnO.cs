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
using ComponentFactory.Krypton.Toolkit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Moshtarayat
{
    public partial class ReportPorReturnO : KryptonForm
    {
        Controller controllerobj;
        string usename;
        public ReportPorReturnO(string username)
        {
            InitializeComponent();
            controllerobj = new Controller();
            usename = username;
          DataTable dtx = controllerobj.SelectClientIDFromUsername(username);
            int clid=int.Parse(dtx.Rows[0][0].ToString());
            DataTable dt = controllerobj.ordersdelievertoclient(clid);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Or_ID";
            comboBox1.ValueMember = "Or_ID";
        }

        private void ReportPorReturnO_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_RP_Click(object sender, EventArgs e)
        {
            DataTable dt = controllerobj.SelectClientIDFromUsername(usename);
            int clid = int.Parse(dt.Rows[0][0].ToString());
            int r=controllerobj.ReportProblem(textBox1.Text,Convert.ToInt32(comboBox1.SelectedValue), clid);
            if(r>0)
            {
                MessageBox.Show("Problem inserted");
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_RO_Click(object sender, EventArgs e)
        {
            DataTable dt = controllerobj.SelectClientIDFromUsername(usename);
            int clid = int.Parse(dt.Rows[0][0].ToString());
            int r = controllerobj.ReturnOrder(Convert.ToInt32(comboBox1.SelectedValue), clid);
            if (r > 0)
            {
                MessageBox.Show("Return Order");
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }
    }
}
