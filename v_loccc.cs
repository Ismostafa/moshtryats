using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ComponentFactory.Krypton.Toolkit;
namespace Moshtarayat
{
    public partial class v_loccc : KryptonForm
    {
        Controller controllerobj;
        string v_name;
        int v_id = 0;
        public v_loccc(string v_name1)
        {
            v_name = v_name1;
            InitializeComponent();
            Newloc.Hide();
            kryptonLabel2.Hide();
            Add_loc1.Hide();
            kryptonLabel1.Hide();
            comboBox1.Hide();
            kryptonButton2.Hide();
            kryptonLabel3.Hide();
            kryptonTextBox1.Hide();
            kryptonButton1.Hide();
            comboBox2.Hide();
            kryptonLabel3.Hide() ;
            kryptonLabel4.Hide();




            controllerobj = new Controller();

            

            //public int Additem(int v_ID, string It_Name11, int qua, float price)

            DataTable dt = controllerobj.getvendor_id(v_name, v_id);

            v_id = int.Parse(dt.Rows[0][0].ToString());

            DataTable dt2 = controllerobj.GetVendorlocations1(v_id);
            comboBox1.DataSource = dt2;
            comboBox1.DisplayMember = "V_Location";
            comboBox1.ValueMember = "V_Location";

            comboBox2.DataSource = dt2;
            comboBox2.DisplayMember = "V_Location";
            comboBox2.ValueMember = "V_Location";

        }

        private void v_loccc_Load(object sender, EventArgs e)
        {

        }

        private void Newloc_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonLabel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Add_loc1_Click(object sender, EventArgs e)
        {
            //public int insertVendorlocations1(int V_ID, string V_loc)
            int r = controllerobj.insertVendorlocations1(v_id, Newloc.Text);
            if(r== 0)
            {
                MessageBox.Show("Error");

            }
            else
                MessageBox.Show("Done");
        }

        private void kryptonLabel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            //        public int DeleteVendorlocations1(int V_ID, string V_loc)

            int r = controllerobj.DeleteVendorlocations1(v_id, comboBox1.SelectedValue.ToString());

            if (r == 0)
            {
                MessageBox.Show("Error");

            }
            else
                MessageBox.Show("Done");
        }

        private void kryptonLabel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            int r = controllerobj.UpdateVendorlocations1(v_id, comboBox2.Text.ToString(), kryptonTextBox1.Text);
                if (r == 0)
            {
                MessageBox.Show("Error");

            }
            else
                MessageBox.Show("Done");
        }

        private void Update_loc_Click(object sender, EventArgs e)
        {
            Newloc.Hide();
            kryptonLabel2.Hide();
            Add_loc1.Hide();
            kryptonLabel3.Hide();
            kryptonTextBox1.Hide();
            kryptonButton1.Hide();

            kryptonLabel3.Show();
            kryptonTextBox1.Show();
            kryptonButton1.Show();
            comboBox2.Show();
            kryptonLabel3.Show();

            kryptonLabel1.Hide();
            comboBox1.Hide();
            kryptonButton2.Hide();


            
        }

        private void delete_loc_Click(object sender, EventArgs e)
        {
            Newloc.Hide();
            kryptonLabel2.Hide();
            Add_loc1.Hide();
            kryptonLabel3.Hide();
            kryptonTextBox1.Hide();
            kryptonButton1.Hide();

            kryptonLabel1.Show();
            comboBox1.Show();
            kryptonButton2.Show();
            comboBox2.Hide();
            //kryptonLabel3.Hide();
            kryptonLabel4.Hide();



        }

        private void Insert_loc_Click(object sender, EventArgs e)
        {
            Newloc.Show();
            kryptonLabel2.Show();
            Add_loc1.Show();

            kryptonLabel1.Hide();
            comboBox1.Hide();
            kryptonButton2.Hide();
            kryptonLabel3.Hide();
            kryptonTextBox1.Hide();
            kryptonButton1.Hide();
            comboBox2.Hide();
            kryptonLabel4.Hide();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void kryptonLabel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
