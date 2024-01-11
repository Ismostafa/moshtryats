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
    public partial class View_PH : KryptonForm
    {
        Controller controllerobj;
        public View_PH()
        {
            InitializeComponent();
            controllerobj = new Controller();
            DataTable dt = controllerobj.SelectAllPOH();
            kryptonDataGridView1_PH.DataSource = dt;
            kryptonDataGridView1_PH.Refresh();
        }

        private void View_PH_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton4_LogOUT_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kryptonDataGridView1_PH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
