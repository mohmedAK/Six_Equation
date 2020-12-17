using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.Windows.Forms;

namespace Project_Sabreen
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void sfButtonStart_Click(object sender, EventArgs e)
        {
            Category.ProjectInformation_Form1 frm = new Category.ProjectInformation_Form1();
            frm.Show();
            this.Hide();
        }

 

        private void sfButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sfButton2_Click(object sender, EventArgs e)
        {
            Category.ReportProjectInformation_Form5 frm = new Category.ReportProjectInformation_Form5();
            frm.Show();
            this.Hide();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
