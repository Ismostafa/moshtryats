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
    public partial class AssDAtoOr : KryptonForm
    {
        Controller controllerobj;
        public AssDAtoOr()
        {
            InitializeComponent();
            controllerobj = new Controller();
            DataTable dt = controllerobj.OngoingOrders();
            kryptonDataGridView2.DataSource = dt;
            kryptonDataGridView2.Refresh();
            DataTable dt2 = controllerobj.SelectAllDA();
            comboBox1_DA.DataSource = dt2;
            comboBox1_DA.DisplayMember = "Fname";
            comboBox1_DA.ValueMember = "DA_ID";
        }

        private void AssDAtoOr_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_DA_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Assign_Click(object sender, EventArgs e)
        {
            int chechDA=controllerobj.DAisbusy(Convert.ToInt32(comboBox1_DA.SelectedValue));
            if(chechDA == 0)
            {
                MessageBox.Show(" This Delievery Agent is busy");
            }
            else
            {
                int id = 0,id2=0;
                DataTable dt = controllerobj.getAdmin("link delievery with order", id);
                id = int.Parse(dt.Rows[0][0].ToString());
                DataTable dt2 = controllerobj.getorderongoing(id2);
                id2 = int.Parse(dt2.Rows[0][0].ToString());

                int assignornot = controllerobj.Assignordertoda(Convert.ToInt32(comboBox1_DA.SelectedValue), id, id2);

                if (assignornot >0)
                {
                    MessageBox.Show(" The Assignment is done");
                }
                else
                {
                    MessageBox.Show(" The Assignment can not be done");
                }
            }
        }

        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void kryptonDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void kryptonButton1_Show_Click(object sender, EventArgs e)
        {
            DataTable dt = controllerobj.Assignments();
            kryptonDataGridView1.DataSource = dt;
            kryptonDataGridView1.Refresh();
        }

        private void kryptonButton1_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
