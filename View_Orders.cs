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
    public partial class View_Orders : KryptonForm
    {
        Controller controllerobj;
        public View_Orders()
        {
            InitializeComponent();
            controllerobj = new Controller();

            DataTable dt = controllerobj.SelectAllOrders();
            kryptonDataGridView1_orders.DataSource = dt;
            kryptonDataGridView1_orders.Refresh();
        }

        private void View_Orders_Load(object sender, EventArgs e)
        { 
            
        }

        private void kryptonButton1_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kryptonDataGridView1_orders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
