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
    public partial class Menu : KryptonForm
    {
        Controller controllerobj;

        string v_name;
        public Menu(string v_name)
        {
            InitializeComponent();
            controllerobj = new Controller();
            this.v_name = v_name;
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            int v_id = 0;

            //public DataTable getvendor_id(string name4, int id4)

            DataTable dt = controllerobj.getvendor_id(v_name, v_id);
            //   dataGridView1.DataSource = dt;
            v_id = int.Parse(dt.Rows[0][0].ToString());
           /* v_id = v_id.Trim();*/




             DataTable dt1 = controllerobj.SelectAllitems(v_id);
            dataGridView1.DataSource = dt1;
            dataGridView1.Refresh();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
