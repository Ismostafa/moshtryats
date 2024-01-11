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
    public partial class v_site : KryptonForm
    {
        string Name_vendor;
        public v_site(string Name_v)
        {
            Name_vendor = Name_v;
            InitializeComponent();
            kryptonButton1.Hide();
            kryptonBorderEdge1.Hide();
            button2.Hide();
            Log_out.Hide();
            kryptonButton2.Hide();
            Loc.Hide();



        }

        private void v_site_Load(object sender, EventArgs e)
        {

        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            Menu s = new Menu(Name_vendor);
            s.Show();
        }

        private void kryptonBorderEdge1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Hide();
            button2.Show();
            Loc.Show();

            kryptonButton1.Show();
            kryptonButton2.Show();
            kryptonBorderEdge1.Show();
            Log_out.Show();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Hide();
            button1.Show();
            kryptonButton1.Hide();
            kryptonBorderEdge1.Hide();
            kryptonButton2.Hide() ;
            Log_out.Hide() ;
            Loc.Hide();
        }

        private void Log_out_Click(object sender, EventArgs e)
        {
            Vendor_Login s = new Vendor_Login();
            s.Show();
            this.Close();

        }

        private void kryptonButton2_Click_1(object sender, EventArgs e)
        {
            Edit_Menu menu = new Edit_Menu(Name_vendor);
            menu.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Loc_Click(object sender, EventArgs e)
        {
            v_loccc s = new v_loccc(Name_vendor);
            s.Show();
        }
    }
}
