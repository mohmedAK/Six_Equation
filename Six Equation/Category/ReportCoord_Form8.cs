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
    public partial class ReportCoord_Form8 : MetroForm
    {
        double[] allData = new double[13];
        object[][] allinfo;
        int id;

        public ReportCoord_Form8()
        {
            InitializeComponent();
            defineGridView();
            FullData();
        }


        void defineGridView()
        {
            #region table 1
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "No.";
            dataGridView1.Columns[1].Name = "P Name";
            dataGridView1.Columns[2].Name = "CPI";
            dataGridView1.Columns[3].Name = "SPI";
          //  dataGridView1.Columns[4].Name = "Region";


            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 192, 192);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridView1.EnableHeadersVisualStyles = false;

            DataGridViewButtonColumn delColumn1 = new DataGridViewButtonColumn();

            delColumn1.FlatStyle = FlatStyle.Flat;
            delColumn1.HeaderText = "Delete";
            delColumn1.Name = "Delete";
            delColumn1.Text = "Delete";
            delColumn1.UseColumnTextForButtonValue = true;
            // delColumn1.Width = 60;
            if (dataGridView1.Columns.Contains(delColumn1.Name = "Delete"))
            {

            }
            else
            {
                dataGridView1.Columns.Add(delColumn1);
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            #endregion

            #region table 2
            dataGridView2.ColumnCount = 4;
            dataGridView2.Columns[0].Name = "No.";
            dataGridView2.Columns[1].Name = "P Name";
            dataGridView2.Columns[2].Name = "CPI";
            dataGridView2.Columns[3].Name = "SPI";
           // dataGridView2.Columns[4].Name = "Region";


            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 192, 192);
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridView2.EnableHeadersVisualStyles = false;

            DataGridViewButtonColumn delColumn2 = new DataGridViewButtonColumn();

            delColumn2.FlatStyle = FlatStyle.Flat;
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

            #region table 3
            dataGridView3.ColumnCount = 4;
            dataGridView3.Columns[0].Name = "No.";
            dataGridView3.Columns[1].Name = "P Name";
            dataGridView3.Columns[2].Name = "CPI";
            dataGridView3.Columns[3].Name = "SPI";
           // dataGridView3.Columns[4].Name = "Region";
           


            dataGridView3.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 192, 192);
            dataGridView3.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridView3.EnableHeadersVisualStyles = false;

            DataGridViewButtonColumn delColumn3 = new DataGridViewButtonColumn();

            delColumn3.FlatStyle = FlatStyle.Flat;
            delColumn3.HeaderText = "Delete";
            delColumn3.Name = "Delete";
            delColumn3.Text = "Delete";
            delColumn3.UseColumnTextForButtonValue = true;
            // delColumn3.Width = 60;
            if (dataGridView3.Columns.Contains(delColumn3.Name = "Delete"))
            {

            }
            else
            {
                dataGridView3.Columns.Add(delColumn3);
            }
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            #endregion

            #region table 4
            dataGridView4.ColumnCount = 4;
            dataGridView4.Columns[0].Name = "No.";
            dataGridView4.Columns[1].Name = "P Name";
            dataGridView4.Columns[2].Name = "CPI";
            dataGridView4.Columns[3].Name = "SPI";
           // dataGridView4.Columns[4].Name = " Region";


            dataGridView4.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 192, 192);
            dataGridView4.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridView4.EnableHeadersVisualStyles = false;

            DataGridViewButtonColumn delColumn4 = new DataGridViewButtonColumn();

            delColumn4.FlatStyle = FlatStyle.Flat;
            delColumn4.HeaderText = "Delete";
            delColumn4.Name = "Delete";
            delColumn4.Text = "Delete";
            delColumn4.UseColumnTextForButtonValue = true;
            // delColumn4.Width = 60;
            if (dataGridView4.Columns.Contains(delColumn4.Name = "Delete"))
            {

            }
            else
            {
                dataGridView4.Columns.Add(delColumn4);
            }
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            #endregion

        }

        void FullData()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();

            dataGridView3.Rows.Clear();
            dataGridView3.Refresh();

            dataGridView4.Rows.Clear();
            dataGridView4.Refresh();

           // allData = GetProjectInformation("report2"); 
            allinfo = GetProjectInformation("projectinformation");




            using (SQLiteConnection conn = new SQLiteConnection(config.DataSource))
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();

                    SQLiteHelper sh = new SQLiteHelper(cmd);

                    DataTable dt = sh.Select("SELECT * FROM report2");

                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            for (int j = 0; j < dt.Columns.Count; j++)
                            {
                                allData[j] = double.Parse(dt.Rows[i][j].ToString());
                            }
                            #region
                            
                                if (Convert.ToDouble(allData[1]) > 1 && Convert.ToDouble(allData[2]) > 1)
                                {
                                    //Q1
                                    dataGridView1.Rows.Add(allData[0], allinfo[i][1], allData[1], allData[2]);



                                }
                                else if (Convert.ToDouble(allData[1]) < 1 && Convert.ToDouble(allData[2]) > 1)
                                {
                                    //Q2
                                    dataGridView2.Rows.Add(allData[0], allinfo[i][1], allData[1], allData[2]);
                                }
                                else if (Convert.ToDouble(allData[1]) < 1 && Convert.ToDouble(allData[2]) < 1)
                                {
                                    //Q3
                                    dataGridView3.Rows.Add(allData[0], allinfo[i][1], allData[1], allData[2]);
                                }
                                else if (Convert.ToDouble(allData[1]) > 1 && Convert.ToDouble(allData[2]) < 1)
                                {
                                    //Q4
                                    dataGridView4.Rows.Add(allData[0], allinfo[i][1], allData[1], allData[2]);
                                }
                                else
                                {
                                    //All
                                    //dataGridView1.Rows.Add(allData[i][0], allinfo[i][1], allData[i][1], allData[i][2]);
                                    //dataGridView2.Rows.Add(allData[i][0], allinfo[i][1], allData[i][1], allData[i][2]);
                                    //dataGridView3.Rows.Add(allData[i][0], allinfo[i][1], allData[i][1], allData[i][2]);
                                    //dataGridView4.Rows.Add(allData[i][0], allinfo[i][1], allData[i][1], allData[i][2]);

                                }

                            
                            #endregion
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
        private void ReportCoord_Form8_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                Delete(id);

            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                id = int.Parse(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
                Delete(id);

            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                id = int.Parse(dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString());
                Delete(id);

            }
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                id = int.Parse(dataGridView4.Rows[e.RowIndex].Cells[0].Value.ToString());
                Delete(id);

            }
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

        private void sfButtonPDBF_Click(object sender, EventArgs e)
        {
            Category.ReportProjectDataBefore_Form6 FRM = new ReportProjectDataBefore_Form6();
            FRM.Show();
            this.Hide();
        }

        private void ReportCoord_Form8_FormClosed(object sender, FormClosedEventArgs e)
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
