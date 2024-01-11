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
    public partial class SavePurchaseHistory : KryptonForm
    {
        Controller controllerobj;
        public SavePurchaseHistory()
        {
            controllerobj = new Controller();
            InitializeComponent();
            DataTable dt = controllerobj.GetallSPH();
            kryptonDataGridView1.DataSource = dt;
            kryptonDataGridView1.Refresh();
        }

        private void SavePurchaseHistory_Load(object sender, EventArgs e)
        {

        }

        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void kryptonButton1_SaveOs_Click(object sender, EventArgs e)
        {
            int ida=0;
            int ido = 0;
            int idph = 0;
            int idc = 0;
            DataTable dt = controllerobj.getAdmin("Save Purchase Order History", ida);
            ida = int.Parse(dt.Rows[0][0].ToString());
            DataTable dt2 = controllerobj.getassignOrderandPH(ido,idph);
            ido = int.Parse(dt2.Rows[0][0].ToString());
            idph= int.Parse(dt2.Rows[0][1].ToString());
            DataTable dt3= controllerobj.getclientwhoorder(ido, idc);
            idc = int.Parse(dt3.Rows[0][0].ToString());
            int result = controllerobj.SavePH(ida,ido,idph,idc);
            if (result==1)
            {
                MessageBox.Show("The  Order is saved");
                kryptonDataGridView1.Refresh();
            }
                else
            {
                MessageBox.Show("All Orders are saved");
                kryptonDataGridView1.Refresh();
            }
        }

        private void kryptonButton1_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
