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
    public partial class CostAndTime_Form2 : MetroForm
    {
        double[] C = new double[] { -0.185, 0.414, 1.508, 0.326, 0.229, 0.338, 0.336, -0.072, -0.035, 0.164, 0.023, 1.233, 0.048 };
        double[] T = new double[] { -0.059, -20.177, 0.006, 1.753, 0.061, 0.468, 0.474, 0.120, 5.264, -0.030, 18.472, 0.00022 };

        double[] CoI = new double[9];
        double[] TiI = new double[8];
        double TotalCo;
        double TotalTi;
        int lastId;

        public CostAndTime_Form2()
        {
            InitializeComponent();

            lastId = getMaxId();


        }

        int getMaxId()
        {
            int maxID = 0; ;
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
        void calculateCO()
        {
            TotalCo = (C[0] * CoI[0]) + (C[1] * Math.Pow(CoI[1], C[2])) + (C[3] * CoI[2]) + (C[4] * CoI[3]) + (C[5] * Math.Pow(CoI[4], C[6])) +
                        (C[7] * CoI[5]) + (C[8] * Math.Pow(CoI[6], C[9])) + (C[10] * Math.Pow(CoI[7], C[11])) + (C[12] * CoI[8]);
            labelTotalCo.Text = String.Format("{0:N3} ", TotalCo); 
        }

        void calculateTi()
        {
            TotalTi = (T[0] * TiI[0]) + (T[1] * Math.Pow(TiI[1], T[2])) + (T[3] * Math.Pow(TiI[2], T[4])) + (T[5] * TiI[3]) + (T[6] * TiI[4]) +
                        (T[7] * Math.Pow(TiI[5], T[8])) + (T[9] * TiI[6]) + (T[10] * Math.Pow(TiI[7], T[11]));
           
            labelTotalTi.Text = String.Format("{0:N3} ", TotalTi);
        }

        void clearTableCost()
        {
            doubleTextBoxCo1.Text = string.Empty;
            doubleTextBoxCo2.Text = string.Empty;
            doubleTextBoxCo3.Text = string.Empty;
            doubleTextBoxCo4.Text = string.Empty;
            doubleTextBoxCo5.Text = string.Empty;
            doubleTextBoxCo6.Text = string.Empty;
            doubleTextBoxCo7.Text = string.Empty;
            doubleTextBoxCo8.Text = string.Empty;
            doubleTextBoxCo9.Text = string.Empty;
            doubleTextBoxCo1.Focus();
            
            labelTotalValueCo.Text = "0";
            labelTotalCo.Text = "0";

            Array.Clear(CoI, 0, CoI.Length);
            TotalCo = 0;
        }

        void clearTableTime()
        {
            doubleTextBoxTi1.Text = string.Empty;
            doubleTextBoxTi2.Text = string.Empty;
            doubleTextBoxTi3.Text = string.Empty;
            doubleTextBoxTi4.Text = string.Empty;
            doubleTextBoxTi5.Text = string.Empty;
            doubleTextBoxTi6.Text = string.Empty;
            doubleTextBoxTi7.Text = string.Empty;
            doubleTextBoxTi8.Text = string.Empty;           
            doubleTextBoxTi1.Focus();

            labelTotalValueTi.Text = "0";
            labelTotalTi.Text = "0";

            Array.Clear(TiI, 0, TiI.Length);
            TotalTi = 0;
        }

        private void sfButtonNextPage_Click(object sender, EventArgs e)
        {
            calculateCO();
            calculateTi();

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
                    dic["co"] = TotalCo;
                    dic["ti"] = TotalTi;
                   
                    sh.Insert("costandtime", dic);

                    conn.Close();
                }

               
                Category.QualityAndRisk_Form3 frm = new QualityAndRisk_Form3();
                frm.Show();
                this.Hide();
            }


           
        }


        private void sfButtonClearTimeValuse_Click(object sender, EventArgs e)
        {
            clearTableTime();
        }

        private void sfButtonClearCostValuse_Click(object sender, EventArgs e)
        {
            clearTableCost();
        }
        #region Co 
        private void doubleTextBoxCo1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    CoI[0] = double.Parse(doubleTextBoxCo1.Text);
                    labelTotalValueCo.Text = CoI.Sum().ToString();
                    calculateCO();
                    doubleTextBoxCo2.Focus();
                }
            }
            catch (Exception)
            {


            }
        }

        private void doubleTextBoxCo2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    CoI[1] = double.Parse(doubleTextBoxCo2.Text);
                    labelTotalValueCo.Text = CoI.Sum().ToString();
                    calculateCO();
                    doubleTextBoxCo3.Focus();
                }
            }
            catch (Exception)
            {


            }
        }

        private void doubleTextBoxCo3_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    CoI[2] = double.Parse(doubleTextBoxCo3.Text);
                    labelTotalValueCo.Text = CoI.Sum().ToString();
                    calculateCO();
                    doubleTextBoxCo4.Focus();
                }
            }
            catch (Exception)
            {


            }
        }

        private void doubleTextBoxCo4_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    CoI[3] = double.Parse(doubleTextBoxCo4.Text);
                    labelTotalValueCo.Text = CoI.Sum().ToString();
                    calculateCO();
                    doubleTextBoxCo5.Focus();
                }
            }
            catch (Exception)
            {


            }
        }

        private void doubleTextBoxCo5_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    CoI[4] = double.Parse(doubleTextBoxCo5.Text);
                    labelTotalValueCo.Text = CoI.Sum().ToString();
                    calculateCO();
                    doubleTextBoxCo6.Focus();
                }
            }
            catch (Exception)
            {


            }
        }

        private void doubleTextBoxCo6_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    CoI[5] = double.Parse(doubleTextBoxCo6.Text);
                    labelTotalValueCo.Text = CoI.Sum().ToString();
                    calculateCO();
                    doubleTextBoxCo7.Focus();
                }
            }
            catch (Exception)
            {


            }
        }

        private void doubleTextBoxCo7_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    CoI[6] = double.Parse(doubleTextBoxCo7.Text);
                    labelTotalValueCo.Text = CoI.Sum().ToString();
                    calculateCO();
                    doubleTextBoxCo8.Focus();
                }
            }
            catch (Exception)
            {


            }
        }

        private void doubleTextBoxCo8_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    CoI[7] = double.Parse(doubleTextBoxCo8.Text);
                    labelTotalValueCo.Text = CoI.Sum().ToString();
                    calculateCO();
                    doubleTextBoxCo9.Focus();
                }
            }
            catch (Exception)
            {


            }
        }

        private void doubleTextBoxCo9_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    CoI[8] = double.Parse(doubleTextBoxCo9.Text);
                    labelTotalValueCo.Text = CoI.Sum().ToString();
                    calculateCO();
                    doubleTextBoxTi1.Focus();
                }
            }
            catch (Exception)
            {


            }
        }

        #endregion
        #region Ti
        private void doubleTextBoxTi1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    TiI[0] = double.Parse(doubleTextBoxTi1.Text);
                    labelTotalValueTi.Text = TiI.Sum().ToString();
                    calculateTi();
                    doubleTextBoxTi2.Focus();
                }
            }
            catch (Exception)
            {


            }
        }

        private void doubleTextBoxTi2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    TiI[1] = double.Parse(doubleTextBoxTi2.Text);
                    labelTotalValueTi.Text = TiI.Sum().ToString();
                    calculateTi();
                    doubleTextBoxTi3.Focus();
                }
            }
            catch (Exception)
            {


            }
        }

        private void doubleTextBoxTi3_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    TiI[2] = double.Parse(doubleTextBoxTi3.Text);
                    labelTotalValueTi.Text = TiI.Sum().ToString();
                    calculateTi();
                    doubleTextBoxTi4.Focus();
                }
            }
            catch (Exception)
            {


            }
        }

        private void doubleTextBoxTi4_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    TiI[3] = double.Parse(doubleTextBoxTi4.Text);
                    labelTotalValueTi.Text = TiI.Sum().ToString();
                    calculateTi();
                    doubleTextBoxTi5.Focus();
                }
            }
            catch (Exception)
            {


            }
        }

        private void doubleTextBoxTi5_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    TiI[4] = double.Parse(doubleTextBoxTi5.Text);
                    labelTotalValueTi.Text = TiI.Sum().ToString();
                    calculateTi();
                    doubleTextBoxTi6.Focus();
                }
            }
            catch (Exception)
            {


            }
        }

        private void doubleTextBoxTi6_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    TiI[5] = double.Parse(doubleTextBoxTi6.Text);
                    labelTotalValueTi.Text = TiI.Sum().ToString();
                    calculateTi();
                    doubleTextBoxTi7.Focus();
                }
            }
            catch (Exception)
            {


            }
        }

        private void doubleTextBoxTi7_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    TiI[6] = double.Parse(doubleTextBoxTi7.Text);
                    labelTotalValueTi.Text = TiI.Sum().ToString();
                    calculateTi();
                    doubleTextBoxTi8.Focus();
                }
            }
            catch (Exception)
            {


            }
        }

        private void doubleTextBoxTi8_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    TiI[7] = double.Parse(doubleTextBoxTi8.Text);
                    labelTotalValueTi.Text = TiI.Sum().ToString();
                    calculateTi();
                    sfButtonNextPage.Focus();
                }
            }
            catch (Exception)
            {


            }
        }





        #endregion

        private void CostAndTime_Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
