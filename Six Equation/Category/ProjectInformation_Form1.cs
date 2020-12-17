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
    public partial class ProjectInformation_Form1 : MetroForm
    {
        public int lastId;
        public ProjectInformation_Form1()
        {
            InitializeComponent();
            
            lastId = getMaxId() + 1;
            textBoxProjectID.Text= lastId.ToString();
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

                            maxID = 0;
                        }
                    }
                    dt.Clear();
                    conn.Close();
                    
                }
            }
            return maxID;
        }
        bool isClear()
        {
            if (textBoxProjectName.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Project Name");
                return true;
            }
            else if (doubleTextBoxBAC.Text == "0.00" ||
                     doubleTextBoxActualCostAc.Text == "0.00" ||
                     doubleTextBoxContractDuration.Text == "0.00" ||
                     doubleTextBoxActualDuration.Text == "0.00" ||
                     doubleTextBoxPercentageOfCompleted.Text == "0.00" ||
                     doubleTextBoxValueAtDuration.Text == "0.00"
                     )
            {
                MessageBox.Show("Please Enter All Project Data");

                return true;
            }
            else
            {
                return false;
            }
        }


        private void sfButtonClearTimeValuse_Click(object sender, EventArgs e)
        {

            textBoxProjectName.Text = string.Empty;
            textBoxProjectLocation.Text = string.Empty;
            textBoxProjectType.Text = string.Empty;
            textBoxProjectOwner.Text = string.Empty; 
            textBoxProjectConsultant.Text = string.Empty;
            textBoxProjectContractor.Text = string.Empty;
            textBoxProjectDesigner.Text = string.Empty;


           

        }

        private void sfButtonNextPage_Click(object sender, EventArgs e)
        {

            if (!isClear())
            {
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
                        dic["pname"] = textBoxProjectName.Text;
                        dic["plocation"] = textBoxProjectLocation.Text;
                        dic["ptype"] = textBoxProjectType.Text;
                        dic["powner"] = textBoxProjectOwner.Text;
                        dic["pconsultant"] = textBoxProjectConsultant.Text;
                        dic["pcontractor"] = textBoxProjectContractor.Text;
                        dic["pdesigner"] = textBoxProjectDesigner.Text;
                        sh.Insert("projectinformation", dic);

                        var dic2 = new Dictionary<string, object>();



                        dic2["id"] = lastId;
                        dic2["contractcostbac"] = doubleTextBoxBAC.Text;
                        dic2["actualcostac"] = doubleTextBoxActualCostAc.Text;
                        dic2["contractduration"] = doubleTextBoxContractDuration.Text;
                        dic2["actualduration"] = doubleTextBoxActualDuration.Text;

                        dic2["percentage"] = double.Parse(doubleTextBoxPercentageOfCompleted.Text) / 100;
                        dic2["pv"] = doubleTextBoxValueAtDuration.Text;

                        sh.Insert("projectdata", dic2);

                        conn.Close();
                    }

                    
                    Category.CostAndTime_Form2 frm = new CostAndTime_Form2();
                    frm.Show();

                    this.Hide();
                }
            }
        }

        private void sfButtonPreviousPage_Click(object sender, EventArgs e)
        {
           
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();

        }

        private void doubleTextBoxBAC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                doubleTextBoxActualCostAc.Focus();
            }
        }

        private void doubleTextBoxActualCostAc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                doubleTextBoxContractDuration.Focus();
            }
        }

        private void doubleTextBoxContractDuration_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                doubleTextBoxActualDuration.Focus();
            }
        }

        private void doubleTextBoxActualDuration_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                doubleTextBoxPercentageOfCompleted.Focus();
            }
        }

        private void doubleTextBoxPercentageOfCompleted_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                doubleTextBoxValueAtDuration.Focus();
            }
        }

        private void doubleTextBoxValueAtDuration_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                sfButtonNextPage.Focus();
            }
        }

        private void textBoxProjectID_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void textBoxProjectName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                textBoxProjectLocation.Focus();
            }
        }

        private void textBoxProjectLocation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                textBoxProjectType.Focus();
            }
        }

        private void textBoxProjectType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                textBoxProjectOwner.Focus();
            }
        }

        private void textBoxProjectOwner_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                textBoxProjectConsultant.Focus();
            }
        }

        private void textBoxProjectConsultant_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                textBoxProjectContractor.Focus();
            }
        }

        private void textBoxProjectContractor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                textBoxProjectDesigner.Focus();
            }
        }

        private void textBoxProjectDesigner_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                doubleTextBoxBAC.Focus();
            }
        }

        private void sfButton1_Click(object sender, EventArgs e)
        {
            doubleTextBoxBAC.Text = "0.00";
            doubleTextBoxActualCostAc.Text = "0.00";
            doubleTextBoxContractDuration.Text = "0.00";
            doubleTextBoxActualDuration.Text = "0.00";
            doubleTextBoxPercentageOfCompleted.Text = "0.00";
            doubleTextBoxValueAtDuration.Text = "0.00";
        }

        private void ProjectInformation_Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
