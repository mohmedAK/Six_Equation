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
    public partial class SaiftyAndSocialSide_Form4 : MetroForm
    {
       
        double[] Sf = new double[] { 0.383, 1.600 , 0.102 , 1.266 , (5.344 * Math.Pow(10, 12)), -10.450 , 0.173 , 0.501 , 1.438 };
        double[] A = new double[] { 0.302 , 0.191 , 1.000 , 0.455 , 1.180 };

        double[] SaiftyI = new double[5];
        double[] SocialI = new double[3];
        double TotalSafity;
        double TotalSocial;
        int lastId;

        double[] projectdata = new double[6];
        double[] costandtime = new double[2]; 
        double[] qualityandrisk = new double[2];
        double[] safetyandsocialside = new double[2];

        double EV; //EV =BAC * percentOfCompleate
        double BAC;   
        double percentOfCompleate;

        double AC;
        double CPI;  //  CPI=EV/AC

        double PV; //PV = BAC / contarctDuration
        double contarctDuration;

        double SPI; // SPI = EV / PV

        double ETC;
        double EAC;
        double VAC;

        public SaiftyAndSocialSide_Form4()
        {
            InitializeComponent();
            lastId = getMaxId();
        }
        void getData()
        {
            using (SQLiteConnection conn = new SQLiteConnection(config.DataSource))
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();

                    SQLiteHelper sh = new SQLiteHelper(cmd);

                    DataTable dt = sh.Select("SELECT * FROM projectdata where id ="+lastId);

                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 1; i < dt.Columns.Count; i++)
                        {
                            projectdata[i-1] = double.Parse(dt.Rows[0][i].ToString());

                        }
                    }
                    dt.Clear();

                    dt = sh.Select("SELECT * FROM costandtime where id =" + lastId);

                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 1; i < dt.Columns.Count; i++)
                        {
                            costandtime[i-1] = double.Parse(dt.Rows[0][i].ToString());

                        }
                    }
                    dt.Clear();

                    dt = sh.Select("SELECT * FROM qualityandrisk where id =" + lastId);

                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 1; i < dt.Columns.Count; i++)
                        {
                            qualityandrisk[i-1] = double.Parse(dt.Rows[0][i].ToString());

                        }
                    }
                    dt.Clear(); 

                    dt = sh.Select("SELECT * FROM safetyandsocialside where id =" + lastId);

                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 1; i < dt.Columns.Count; i++)
                        {
                            safetyandsocialside[i-1] = double.Parse(dt.Rows[0][i].ToString());

                        }
                    }
                    dt.Clear();
                    conn.Close();

                }
            }
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
        #region
        private void sfButtonClearSaftyValuse_Click(object sender, EventArgs e)
        {
            clearTableSaifty();
        }

        private void sfButtonClearSocialSideValuse_Click(object sender, EventArgs e)
        {
            clearTableSocialSide();
        }

        void clearTableSaifty()
        {
            doubleTextBoxSa1.Text = string.Empty;
            doubleTextBoxSa2.Text = string.Empty;
            doubleTextBoxSa3.Text = string.Empty;
            doubleTextBoxSa4.Text = string.Empty;
            doubleTextBoxSa5.Text = string.Empty;
           

            doubleTextBoxSa1.Focus();

            labelTotalValueSa.Text = "0";
            labelTotalSa.Text = "0";

            Array.Clear(SaiftyI, 0, SaiftyI.Length);
            TotalSafity = 0;
        }

        void clearTableSocialSide()
        {
            doubleTextBoxSo1.Text = string.Empty;
            doubleTextBoxSo2.Text = string.Empty;
            doubleTextBoxSo3.Text = string.Empty;
           

            doubleTextBoxSo1.Focus();

            labelTotalValueSo.Text = "0";
            labelTotalSo.Text = "0";

            Array.Clear(SocialI, 0, SocialI.Length);
            TotalSocial = 0;
        }

        void calculateSa()
        {
            TotalSafity = (Sf[0] * Math.Pow(SaiftyI[0], Sf[1])) + (Sf[2] * Math.Pow(SaiftyI[1], Sf[3])) + ((5.344 * Math.Pow(10, -12)) * Math.Pow(SaiftyI[2], Sf[5])) + (Sf[6] * SaiftyI[3]) +
                      (Sf[7] * Math.Pow(SaiftyI[4], Sf[8])); 
            labelTotalSa.Text = String.Format("{0:N3} ", TotalSafity);
        }

        void calculateSo()
        {
            TotalSocial =  (A[0] * SocialI[0]) + (A[1] * Math.Pow(SocialI[1], A[2])) +
                           (A[3] * Math.Pow(SocialI[2], A[4]));
            labelTotalSo.Text = String.Format("{0:N3} ", TotalSocial);
        }

     
        #region Sa
        private void doubleTextBoxSa1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SaiftyI[0] = double.Parse(doubleTextBoxSa1.Text);
                    labelTotalValueSa.Text = SaiftyI.Sum().ToString();
                    calculateSa();
                    doubleTextBoxSa2.Focus();

                }
            }
            catch (Exception)
            {


            }
        }

        private void doubleTextBoxSa2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SaiftyI[1] = double.Parse(doubleTextBoxSa2.Text);
                   labelTotalValueSa.Text = SaiftyI.Sum().ToString();
                    calculateSa();
                    doubleTextBoxSa3.Focus();
                }
            }
            catch (Exception)
            {


            }
        }

        private void doubleTextBoxSa3_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SaiftyI[2] = double.Parse(doubleTextBoxSa3.Text);
                   labelTotalValueSa.Text = SaiftyI.Sum().ToString();
                    calculateSa();
                    doubleTextBoxSa4.Focus();
                }
            }
            catch (Exception)
            {


            }
        }

        private void doubleTextBoxSa4_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SaiftyI[3] = double.Parse(doubleTextBoxSa4.Text);
                   labelTotalValueSa.Text = SaiftyI.Sum().ToString();
                    calculateSa();
                    doubleTextBoxSa5.Focus();
                }
            }
            catch (Exception)
            {


            }
        }

        private void doubleTextBoxSa5_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SaiftyI[4] = double.Parse(doubleTextBoxSa5.Text);
                   labelTotalValueSa.Text = SaiftyI.Sum().ToString();
                    calculateSa();
                    doubleTextBoxSo1.Focus();
                }
            }
            catch (Exception)
            {


            }
        }


        #endregion

        #region Qu 
        private void doubleTextBoxSo1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SocialI[0] = double.Parse(doubleTextBoxSo1.Text);
                    labelTotalValueSo.Text = SocialI.Sum().ToString();
                    calculateSo();
                    doubleTextBoxSo2.Focus();

                }
            }
            catch (Exception)
            {


            }
        }

        private void doubleTextBoxSo2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SocialI[1] = double.Parse(doubleTextBoxSo2.Text);
                    labelTotalValueSo.Text = SocialI.Sum().ToString();
                    calculateSo();
                    doubleTextBoxSo3.Focus();
                }
            }
            catch (Exception)
            {


            }
        }

        private void doubleTextBoxSo3_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SocialI[2] = double.Parse(doubleTextBoxSo3.Text);
                    labelTotalValueSo.Text = SocialI.Sum().ToString();
                    calculateSo();
                    sfButtonNextPage.Focus();
                }
            }
            catch (Exception)
            {


            }
        }





        #endregion
        #endregion

        private void sfButtonNextPage_Click(object sender, EventArgs e)
        {
            calculateSa();
            calculateSo();

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
                    dic["sa"] = TotalSafity;
                    dic["so"] = TotalSocial;

                    sh.Insert("safetyandsocialside", dic);

                    conn.Close();
                }

                getData();
               
                BAC = projectdata[0];
                Console.WriteLine("BAC=" + BAC);

                percentOfCompleate = projectdata[4];
                Console.WriteLine("percentOfCompleate=" + (percentOfCompleate));
                EV = BAC * (percentOfCompleate);
                Console.WriteLine("EV=" + EV);
                AC = projectdata[1];
                Console.WriteLine("AC=" + AC);
                CPI = EV / AC;
                Console.WriteLine("CPI=" + CPI);

                contarctDuration = projectdata[2];
                Console.WriteLine("contarctDuration=" + contarctDuration);
                PV = projectdata[5];
                Console.WriteLine("PV=" + PV);
                SPI = (EV / PV);
                Console.WriteLine("SPI=" + (EV / PV));

                #region Befor

                ETC = (BAC - EV) / CPI ;

                EAC = ETC + AC;

                VAC = BAC - EAC;

                using (SQLiteConnection conn = new SQLiteConnection(config.DataSource))

                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();

                    SQLiteHelper sh = new SQLiteHelper(cmd);

                    // sh.Execute("DELETE FROM Site_and_Location");
                    var dic = new Dictionary<string, object>();

                    dic["id"] = lastId;
                    dic["contractvalue"] = BAC;
                    dic["actualcost"] = AC;
                    dic["contractduration"] = contarctDuration;
                    dic["actualduration"] = projectdata[3];
                    dic["percentageofcompleate"] = projectdata[4];
                    dic["PV"] = PV;
                    dic["EV"] = EV;
                    dic["CPI"] = CPI;
                    dic["SPI"] = SPI;
                    dic["ETC"] = ETC;
                    dic["EAC"] = EAC;
                    dic["VAC"] = VAC;

                    sh.Insert("report1", dic);
                }
            
        
                    #endregion

               #region After
               


                ETC = (BAC - EV) / (CPI + SPI + costandtime[0] + costandtime[1] + qualityandrisk[0] + qualityandrisk[1] + safetyandsocialside[0] + safetyandsocialside[1]);

                EAC = ETC + AC;

                VAC = BAC - EAC;

                using (SQLiteConnection conn = new SQLiteConnection(config.DataSource))

                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();

                    SQLiteHelper sh = new SQLiteHelper(cmd);

                    // sh.Execute("DELETE FROM Site_and_Location");
                    var dic2 = new Dictionary<string, object>();

                    dic2["id"] = lastId;
                    dic2["CPI"] = CPI;
                    dic2["SPI"] = SPI;
                    dic2["CO"] = costandtime[0];
                    dic2["TI"] = costandtime[1];
                    dic2["QU"] = qualityandrisk[0];
                    dic2["RI"] = qualityandrisk[1];
                    dic2["SA"] = safetyandsocialside[0];
                    dic2["SO"] = safetyandsocialside[1];
                    dic2["ETC"] = ETC;
                    dic2["EAC"] = EAC;
                    dic2["VAC"] = VAC;

                    sh.Insert("report2", dic2);
                    #endregion
                    conn.Close();
                }
                Category.ReportProjectInformation_Form5 frm = new ReportProjectInformation_Form5();
                frm.Show();
                this.Hide();
            }
        }

        private void SaiftyAndSocialSide_Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
