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
    public partial class Edit_Menu : KryptonForm
    {
        Controller controllerobj;
        string v_name;
        public Edit_Menu(string v_name1)
        {
            v_name = v_name1;
            InitializeComponent();
            NewPrice_tex.Hide();
            NewName_tex.Hide();
            Name_New_item.Hide();
            Enter_New_price.Hide();
            kryptonButton1.Hide();
            comboBox1_Update.Hide();
            kryptonLabel1.Hide();
            kryptonLabel2.Hide();
            comboBox1.Hide();
            Log_out.Hide();
            kryptonButton2.Hide();
            updated_q.Hide();
            kryptonTextBox1.Hide();
            kryptonLabel3.Hide();
            kryptonLabel4.Hide();   
            kryptonLabel5.Hide();
            kryptonLabel6.Hide();
            kryptonLabel7.Hide();
            kryptonLabel8.Hide();

            controllerobj = new Controller();

            int v_id = 0;

            //public int Additem(int v_ID, string It_Name11, int qua, float price)

            DataTable dt = controllerobj.getvendor_id(v_name, v_id);

            v_id = int.Parse(dt.Rows[0][0].ToString());

            DataTable dt2 = controllerobj.SelectAllitems1(v_id);
            comboBox1_Update.DataSource = dt2;
            comboBox1_Update.DisplayMember = "It_Name";
            comboBox1_Update.ValueMember = "Item_ID";

            comboBox1.DataSource = dt2;
            comboBox1.DisplayMember = "It_Name";
            comboBox1.ValueMember = "Item_ID";

        }

        private void Edit_Menu_Load(object sender, EventArgs e)
        {

        }

        private void kryptonLabel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UpdateName_tex_TextChanged(object sender, EventArgs e)
        {

        }

        private void UpdatePrice_tex_TextChanged(object sender, EventArgs e)
        {

        }

        private void Name_New_item_TextChanged(object sender, EventArgs e)
        {

        }

        private void Enter_New_price_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            int v_id = 0;

            //public int Additem(int v_ID, string It_Name11, int qua, float price)

            DataTable dt = controllerobj.getvendor_id(v_name, v_id);
            
            v_id = int.Parse(dt.Rows[0][0].ToString());
            
            int r=controllerobj.Additem(v_id, NewName_tex.Text,int.Parse (kryptonTextBox1.Text),float.Parse( NewPrice_tex.Text));

            if(r==0)
            { MessageBox.Show("error"); }
            else
                MessageBox.Show("Done");

        }

        private void comboBox1_Update_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void kryptonLabel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Log_out_Click(object sender, EventArgs e)
        {
            /* Log_out.Hide();
             kryptonLabel2.Hide();
             comboBox1.Hide();*/
            //public int deleteitem(int itemid)
            int r = controllerobj.deleteitem(Convert.ToInt32(comboBox1.SelectedValue));
            if (r == 0)
            { MessageBox.Show("error"); }
            else
                MessageBox.Show("Done");

        }

        private void Insert_item_Click(object sender, EventArgs e)
        {
            //////
            /*UpdateName_tex.Show();
            UpdatePrice_tex.Show();*/
            NewPrice_tex.Show();
            NewName_tex.Show();
            kryptonButton1.Show();
            kryptonTextBox1.Show();
            kryptonLabel3.Show();
            kryptonLabel4.Show();
            kryptonLabel5.Show();


            Log_out.Hide();
            kryptonLabel2.Hide();
            comboBox1.Hide();
            comboBox1_Update.Hide();
            Name_New_item.Hide();
            Enter_New_price.Hide();
            kryptonButton2.Hide();
            updated_q.Hide();
            kryptonLabel6.Hide();
            kryptonLabel7.Hide();
            kryptonLabel8.Hide();



        }

        private void Update_item_Click(object sender, EventArgs e)
        {
            
            Name_New_item.Show();
            Enter_New_price.Show();
            kryptonButton2.Show();
            updated_q.Show();

            comboBox1_Update.Show();

            kryptonLabel6.Show();
            kryptonLabel7.Show();
            kryptonLabel8.Show();

            Log_out.Hide();
            kryptonLabel2.Hide();
            comboBox1.Hide();
            NewName_tex.Hide();
            NewPrice_tex.Hide();
            kryptonButton1.Hide();
            kryptonTextBox1.Hide();
            kryptonLabel3.Hide();
            kryptonLabel4.Hide();
            kryptonLabel5.Hide();





        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            /* Name_New_item.Hide();
             Enter_New_price.Hide();
             kryptonButton2.Hide();*/
            //Enter_New_price
            //public int Updateitem(float cost, int itemid, string nameitem1, int q)
            int r = controllerobj.Updateitem(float.Parse(Enter_New_price.Text), Convert.ToInt32(comboBox1_Update.SelectedValue), Name_New_item.Text, int.Parse(updated_q.Text));

            if (r == 0)
            { MessageBox.Show("error"); }
            else
                MessageBox.Show("Done");
        }

        private void Delete_item_Click(object sender, EventArgs e)
        {
            kryptonLabel2.Show();
            comboBox1.Show();
            Log_out.Show();


            NewName_tex.Hide();
            NewPrice_tex.Hide();
            kryptonButton1.Hide();
            comboBox1_Update.Hide();
            Name_New_item.Hide();
            Enter_New_price.Hide();
            kryptonButton2.Hide();
            updated_q.Hide();
            kryptonTextBox1.Hide();
            kryptonLabel3.Hide();
            kryptonLabel4.Hide();
            kryptonLabel5.Hide();
            kryptonLabel6.Hide();
            kryptonLabel7.Hide();
            kryptonLabel8.Hide();



        }

        private void updated_q_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
