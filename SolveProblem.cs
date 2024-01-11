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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Moshtarayat
{
    public partial class SolveProblem : KryptonForm
    {
        Controller controllerobj;
        public SolveProblem()
        {
            InitializeComponent();
            controllerobj = new Controller();
            DataTable dt = controllerobj.SelectProblems();
            kryptonDataGridView1_Problems.DataSource = dt;
            kryptonDataGridView1_Problems.Refresh();
            DataTable dt2 = controllerobj.SelectProblems();
            comboBox1_PID.DataSource = dt;
            comboBox1_PID.DisplayMember = "P_Num";
            comboBox1_PID.ValueMember = "P_Num";
        }

        private void SolveProblem_Load(object sender, EventArgs e)
        {

        }

        private void kryptonDataGridView1_Problems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void kryptonButton1_Solve_Click(object sender, EventArgs e)
        {
            int result = controllerobj.SolveClientProblem(Convert.ToInt32(comboBox1_PID.SelectedValue));
            if(result==1)
            {
                MessageBox.Show("The Problem is solved");
                kryptonDataGridView1_Problems.Refresh();
            }
            else
            {
                MessageBox.Show("The Problem is already solved");
                kryptonDataGridView1_Problems.Refresh();
            }
        }

        private void comboBox1_PID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
