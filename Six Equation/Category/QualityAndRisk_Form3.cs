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
using System.Data.SQLite;
namespace Project_Sabreen.Category
{
    public partial class QualityAndRisk_Form3 : Syncfusion.Windows.Forms.MetroForm
    {
        double[] Q = new double[] { 0.275, 0.179, 0.906, 0.067, 0.870, 0.295, 0.972, 0.153, 0.116 };
        double[] R = new double[] { 0.231, 1.007, 0.194, 0.075, 1.243, 0.187, 0.257, 1.033 , 0.138 };

        double[] QuI = new double[6];
        double[] RiI = new double[6];
        double TotalQu;
        double TotalRi;
        int lastId;


        public QualityAndRisk_Form3()
        {
            InitializeComponent();
            lastId = getMaxId();
        }

        void calculateQu()
        {
            TotalQu = (Q[0] * QuI[0]) + (Q[1] * Math.Pow(QuI[1], Q[2])) + (Q[3] * Math.Pow(QuI[2], Q[4])) + (Q[5] * Math.Pow(QuI[3], Q[6])) + (Q[7] * QuI[4]) +
                        (Q[8] * QuI[5]);
            labelTotalQu.Text = String.Format("{0:N3} ", TotalQu);
        }

        void calculateRi()
        {
            TotalRi = (R[0] * Math.Pow(RiI[0], R[1])) + (R[2] * RiI[1]) + (R[3] * Math.Pow(RiI[2], R[4])) + (R[5] * RiI[3]) +
                        (R[6] * Math.Pow(RiI[4], R[7])) + (R[8] * RiI[5]);
            labelTotalRi.Text = String.Format("{0:N3} ", TotalRi);
        }

        void clearTableQuality()
        {
            doubleTextBoxQu1.Text = string.Empty;
            doubleTextBoxQu2.Text = string.Empty;
            doubleTextBoxQu3.Text = string.Empty;
            doubleTextBoxQu4.Text = string.Empty;
            doubleTextBoxQu5.Text = string.Empty;
            doubleTextBoxQu6.Text = string.Empty;
           
            doubleTextBoxQu1.Focus();

            labelTotalValueQu.Text = "0";
            labelTotalQu.Text = "0";

            Array.Clear(QuI, 0, QuI.Length);
            TotalQu = 0;
        }

        void clearTableRisk()
        {
            doubleTextBoxRi1.Text = string.Empty;
            doubleTextBoxRi2.Text = string.Empty;
            doubleTextBoxRi3.Text = string.Empty;
            doubleTextBoxRi4.Text = string.Empty;
            doubleTextBoxRi5.Text = string.Empty;
            doubleTextBoxRi6.Text = string.Empty;
           
            doubleTextBoxRi1.Focus();

            labelTotalValueRi.Text = "0";
            labelTotalRi.Text = "0";

            Array.Clear(RiI, 0, RiI.Length);
            TotalRi = 0;
        }

        int getMaxId()
        {
            int maxID = -1; ;
            using (SQLiteConnection conn = new SQLiteConnection(config.DataSource))
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();

                    SQLiteHelper sh = new SQLiteHelper(cmd);

                    DataTable dt = sh.Select("SELECT MAX(id) FROM projectinformation");

                    if (dt.Rows.Count > 0)
                    {
                        try
                        {
                            maxID = int.Parse(dt.Rows[0][0].ToString());

                        }
                        catch (Exception)
                        {

                            // maxID = -1;
                        }
                    }
                    dt.Clear();
                    conn.Close();

                }
            }
            return maxID;
        }

        private void sfButtonClearQualityValuse_Click(object sender, EventArgs e)
        {
            clearTableQuality();
        }

        private void sfButtonClearRiskValuse_Click(object sender, EventArgs e)
        {
            clearTableRisk();
        }
        #region Qu 
        private void doubleTextBoxQu1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    QuI[0] = double.Parse(doubleTextBoxQu1.Text);
                    labelTotalValueQu.Text = QuI.Sum().ToString();
                    calculateQu();
                    doubleTextBoxQu2.Focus();
                   
                }
            }
            catch (Exception)
            {

               
            }
        }

        private void doubleTextBoxQu2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    QuI[1] = double.Parse(doubleTextBoxQu2.Text);
                    labelTotalValueQu.Text = QuI.Sum().ToString();
                    calculateQu();
                    doubleTextBoxQu3.Focus();
                }
            }
            catch (Exception)
            {


            }
        }

        private void doubleTextBoxQu3_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    QuI[2] = double.Parse(doubleTextBoxQu3.Text);
                    labelTotalValueQu.Text = QuI.Sum().ToString();
                    calculateQu();
                    doubleTextBoxQu4.Focus();
                }
            }
            catch (Exception)
            {


            }
        }

        private void doubleTextBoxQu4_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    QuI[3] = double.Parse(doubleTextBoxQu4.Text);
                    labelTotalValueQu.Text = QuI.Sum().ToString();
                    calculateQu();
                    doubleTextBoxQu5.Focus();
                }
            }
            catch (Exception)
            {


            }
        }

        private void doubleTextBoxQu5_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    QuI[4] = double.Parse(doubleTextBoxQu5.Text);
                    labelTotalValueQu.Text = QuI.Sum().ToString();
                    calculateQu();
                    doubleTextBoxQu6.Focus();
                }
            }
            catch (Exception)
            {


            }
        }

        private void doubleTextBoxQu6_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    QuI[5] = double.Parse(doubleTextBoxQu6.Text);
                    labelTotalValueQu.Text = QuI.Sum().ToString();
                    calculateQu();
                    doubleTextBoxRi1.Focus();
                }
            }
            catch (Exception)
            {


            }
        }

        #endregion

        #region Ti
        private void doubleTextBoxRi1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    RiI[0] = double.Parse(doubleTextBoxRi1.Text);
                    labelTotalValueRi.Text = RiI.Sum().ToString();
                    calculateRi();
                    doubleTextBoxRi2.Focus();
                   
                }
            }
            catch (Exception)
            {


            }
        }

        private void doubleTextBoxRi2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    RiI[1] = double.Parse(doubleTextBoxRi2.Text);
                    labelTotalValueRi.Text = RiI.Sum().ToString();
                    calculateRi();
                    doubleTextBoxRi3.Focus();
                }
            }
            catch (Exception)
            {


            }
        }

        private void doubleTextBoxRi3_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    RiI[2] = double.Parse(doubleTextBoxRi3.Text);
                    labelTotalValueRi.Text = RiI.Sum().ToString();
                    calculateRi();
                    doubleTextBoxRi4.Focus();
                }
            }
            catch (Exception)
            {


            }
        }

        private void doubleTextBoxRi4_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    RiI[3] = double.Parse(doubleTextBoxRi4.Text);
                    labelTotalValueRi.Text = RiI.Sum().ToString();
                    calculateRi();
                    doubleTextBoxRi5.Focus();
                }
            }
            catch (Exception)
            {


            }
        }

        private void doubleTextBoxRi5_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    RiI[4] = double.Parse(doubleTextBoxRi5.Text);
                    labelTotalValueRi.Text = RiI.Sum().ToString();
                    calculateRi();
                    doubleTextBoxRi6.Focus();
                }
            }
            catch (Exception)
            {


            }
        }

        private void doubleTextBoxRi6_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    RiI[5] = double.Parse(doubleTextBoxRi6.Text);
                    labelTotalValueRi.Text = RiI.Sum().ToString();
                    calculateRi();
                    sfButtonNextPage.Focus();
                }
            }
            catch (Exception)
            {


            }
        }





        #endregion

        private void sfButtonNextPage_Click(object sender, EventArgs e)
        {
            calculateQu();
            calculateRi();

            if (MessageBox.Show("Are you sure From Data You Entered ?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SQLiteConnection conn = new SQLiteConnection(config.DataSource))

                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();

                    SQLiteHelper sh = new SQLiteHelper(cmd);

                    // sh.Execute("DELETE FROM Site_and_Location");
                    var dic = new Dictionary<string, object>();

                    dic["id"] = lastId;
                    dic["qu"] = TotalQu;
                    dic["ri"] = TotalRi;

                    sh.Insert("qualityandrisk", dic);

                    conn.Close();
                }

                Category.SaiftyAndSocialSide_Form4 frm = new SaiftyAndSocialSide_Form4();
                frm.Show();
                this.Hide();
            }

           
        }

        private void QualityAndRisk_Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
