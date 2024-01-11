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
    public partial class View_Clients : KryptonForm
    {
        Controller controllerobj;
        public View_Clients()
        {
            InitializeComponent();
            controllerobj = new Controller();

            DataTable dt = controllerobj.SelectAllClients();
            kryptonDataGridView1_Client.DataSource = dt;
            kryptonDataGridView1_Client.Refresh();
        }

        private void View_Clients_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kryptonDataGridView1_Client_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
