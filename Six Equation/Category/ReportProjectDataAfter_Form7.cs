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
    public partial class ReportProjectDataAfter_Form7 : MetroForm
    {
        double[] Data = new double[13];
        int id;

        public ReportProjectDataAfter_Form7()
        {
            InitializeComponent();
            defineGridView();
            FullData();
        }


        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 12)
            {
                id = int.Parse(dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString());
                Delete(id);
            }
        }


        void defineGridView()
        {
         
            #region table 3
            dataGridView3.ColumnCount = 12;
            dataGridView3.Columns[0].Name = "No.";
            dataGridView3.Columns[1].Name = "CPI";
            dataGridView3.Columns[2].Name = "SPI";
            dataGridView3.Columns[3].Name = "COI";
            dataGridView3.Columns[4].Name = "TII";
            dataGridView3.Columns[5].Name = "QUI";
            dataGridView3.Columns[6].Name = "RII";
            dataGridView3.Columns[7].Name = "SAI";
            dataGridView3.Columns[8].Name = "SOI";
            dataGridView3.Columns[9].Name = "ETC*";
            dataGridView3.Columns[10].Name = "EAC*";
            dataGridView3.Columns[11].Name = "VAC*";

            dataGridView3.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 192, 192);
            dataGridView3.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridView3.EnableHeadersVisualStyles = false;

            DataGridViewButtonColumn delColumn3 = new DataGridViewButtonColumn();

            delColumn3.FlatStyle = FlatStyle.Standard;
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

        }



        void FullData()
        {
            
            dataGridView3.Rows.Clear();
            dataGridView3.Refresh();
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
                                Data[j] = double.Parse(dt.Rows[i][j].ToString());
                            }
                            dataGridView3.Rows.Add(Data[0], Data[1], Data[2], Data[3], Data[4], Data[5], Data[6], Data[7], Data[8], Data[9], Data[10], Data[11], Data[12]);



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

        private void sfButtonShowPDBF_Click(object sender, EventArgs e)
        {
            Category.ReportProjectDataBefore_Form6 FRM = new ReportProjectDataBefore_Form6();
            FRM.Show();
            this.Hide();
        }

        private void sfButtonShowCoord_Click(object sender, EventArgs e)
        {
            Category.ReportCoord_Form8 FRM = new ReportCoord_Form8();
            FRM.Show();
            this.Hide();
        }

        private void ReportProjectDataAfter_Form7_FormClosed(object sender, FormClosedEventArgs e)
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
