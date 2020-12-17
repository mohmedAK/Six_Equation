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
    public partial class ReportProjectDataBefore_Form6 : MetroForm
    {
        double[] Data = new double[13];
    //    List<double> Data = new List<double>();
    //    List<List<double>> AllData = new List<List<double>>();
        int id;

        public ReportProjectDataBefore_Form6()
        {
            InitializeComponent();
            defineGridView();
            FullData();
        }

        private void ReportProjectDataBefore_Form6_Load(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 13)
            {
                id = int.Parse(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
                Delete(id);

            }
        }


        void defineGridView()
        {
          
            #region table 2
            dataGridView2.ColumnCount = 13;
            dataGridView2.Columns[0].Name = "No.";
            dataGridView2.Columns[1].Name = "Contract Value";
            dataGridView2.Columns[2].Name = "Actual Cost";
            dataGridView2.Columns[3].Name = "Contract Duration";
            dataGridView2.Columns[4].Name = "Actual Duration";
            dataGridView2.Columns[5].Name = "Percentage of Completed";
            dataGridView2.Columns[6].Name = "PV";
            dataGridView2.Columns[7].Name = "EV";
            dataGridView2.Columns[8].Name = "CPI";
            dataGridView2.Columns[9].Name = "SPI";
            dataGridView2.Columns[10].Name = "ETC";
            dataGridView2.Columns[11].Name = "EAC";
            dataGridView2.Columns[12].Name = "VAC";

            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 192, 192);
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridView2.EnableHeadersVisualStyles = false;

            DataGridViewButtonColumn delColumn2 = new DataGridViewButtonColumn();

            delColumn2.FlatStyle = FlatStyle.Standard;
            delColumn2.HeaderText = "Delete";
            delColumn2.Name = "Delete";
            delColumn2.Text = "Delete";
            delColumn2.UseColumnTextForButtonValue = true;
           // delColumn2.Width = 60;
            if (dataGridView2.Columns.Contains(delColumn2.Name = "Delete"))
            {

            }
            else
            {
                dataGridView2.Columns.Add(delColumn2);
            }
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            #endregion

           

        }



        void FullData()
        {

            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            //allData = GetProjectInformation("report1");
            //for (int i = 0; i < allData.Length; i++)
            //{

            //    dataGridView2.Rows.Add(allData[i]);
            //    Console.WriteLine(allData[i][1]);
            //}


            using (SQLiteConnection conn = new SQLiteConnection(config.DataSource))
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();

                    SQLiteHelper sh = new SQLiteHelper(cmd);

                    DataTable dt = sh.Select("SELECT * FROM report1");

                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            for (int j = 0; j < dt.Columns.Count; j++)
                            {
                                Data[j] = double.Parse(dt.Rows[i][j].ToString()) ;
                            }
                            dataGridView2.Rows.Add(Data[0], Data[1], Data[2], Data[3], Data[4], Data[5], Data[6], Data[7], Data[8], Data[9], Data[10], Data[11], Data[12]);

                           
                           
                        }
                       
                       
                    }
                    conn.Close();
                }
            }
        
        }
    

        public object[][] GetProjectInformation(string table)
        {
            string query = "SELECT * FROM " + table;
            using (SQLiteConnection conn = new SQLiteConnection(config.DataSource))
            {
                try
                {
                    //Open connection
                    conn.Open();
                    //Create Command
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    //Create a data reader and Execute the command
                    SQLiteDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    int ColCount = dataReader.FieldCount;
                    List<object[]> rows = new List<object[]>();


                    while (dataReader.Read())
                    {
                        List<object> row = new List<object>();
                        for (int i = 0; i < ColCount; i++)
                        {
                            row.Add(dataReader[i]);
                        }
                        rows.Add(row.ToArray());
                    }

                    //close Data Reader
                    dataReader.Close();

                    //close Connection
                    conn.Close();

                    //return list to be displayed
                    return rows.ToArray();
                }
                catch (Exception)
                {

                    return null;
                }
            }
        }

        void Delete(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(config.DataSource))
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();

                    SQLiteHelper sh = new SQLiteHelper(cmd);

                    sh.Execute("DELETE FROM projectinformation where id = " + id);
                    sh.Execute("DELETE FROM projectdata where id = " + id);
                    sh.Execute("DELETE FROM costandtime where id = " + id);
                    sh.Execute("DELETE FROM qualityandrisk where id = " + id);
                    sh.Execute("DELETE FROM safetyandsocialside where id = " + id);
                    sh.Execute("DELETE FROM report1 where id = " + id);
                    sh.Execute("DELETE FROM report2 where id = " + id);
                    conn.Close();
                }
            }



            FullData();
        }

        private void sfButtonAddProject_Click(object sender, EventArgs e)
        {
            Category.ProjectInformation_Form1 FRM = new ProjectInformation_Form1();
            FRM.Show();
            this.Hide();
        }

        private void sfButtonShowProjectInformation_Click(object sender, EventArgs e)
        {
            Category.ReportProjectInformation_Form5 FRM = new ReportProjectInformation_Form5();
            FRM.Show();
            this.Hide();
        }

        private void sfButtonShowPDAF_Click(object sender, EventArgs e)
        {
            Category.ReportProjectDataAfter_Form7 FRM = new ReportProjectDataAfter_Form7();
            FRM.Show();
            this.Hide();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void sfButtonShowCoord_Click(object sender, EventArgs e)
        {
            Category.ReportCoord_Form8 FRM = new ReportCoord_Form8();
            FRM.Show();
            this.Hide();
        }

        private void ReportProjectDataBefore_Form6_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void sfButton1_Click(object sender, EventArgs e)
        {
            Category.coords_Form9 FRM = new coords_Form9();
            FRM.Show();
            this.Hide();
        }
    }
}
