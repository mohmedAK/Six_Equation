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
    public partial class ReportProjectInformation_Form5 : MetroForm
    {
        object[][] projectInformation;
    
        int id;
        public ReportProjectInformation_Form5()
        {
            InitializeComponent();
            defineGridView();
            FullData();
        }

        void defineGridView()
        {
            #region table 1
            dataGridView1.ColumnCount = 8;
            dataGridView1.Columns[0].Name = "No.";
           // this.dataGridView1.Columns["Project Num"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].Name = "Project Name";
            dataGridView1.Columns[2].Name = "Project Location";
            dataGridView1.Columns[3].Name = "Project Type";
            dataGridView1.Columns[4].Name = "Project Owner";
            dataGridView1.Columns[5].Name = "Project Consultant";
            dataGridView1.Columns[6].Name = "Project Contractor";
            dataGridView1.Columns[7].Name = "Project Designer";

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 192, 192);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridView1.EnableHeadersVisualStyles = false;

            DataGridViewButtonColumn delColumn = new DataGridViewButtonColumn();

            delColumn.FlatStyle = FlatStyle.Standard;
            delColumn.HeaderText = "Delete";
            delColumn.Name = "Delete";
            
            delColumn.Text = "Delete";
            delColumn.UseColumnTextForButtonValue = true;
           // delColumn.Width = 130;
            
            if (dataGridView1.Columns.Contains(delColumn.Name = "Delete")) 
            {

            }
            else
            {
                dataGridView1.Columns.Add(delColumn);
            }
            
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            #endregion
           

        }



        void FullData()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            projectInformation = GetProjectInformation("projectinformation");
            for (int i = 0; i < projectInformation.Length; i++)
            {
                dataGridView1.Rows.Add(projectInformation[i]);
            }

           
        }

        public object [][] GetProjectInformation(string table)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                 id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                Delete(id);
               
            }
        }

    

   

        private void sfButtonAddProject_Click(object sender, EventArgs e)
        {
            Category.ProjectInformation_Form1 FRM = new ProjectInformation_Form1();
            FRM.Show();
            this.Hide();
        }

        private void sfButtonShowPDAF_Click(object sender, EventArgs e)
        {
            Category.ReportProjectDataAfter_Form7 FRM = new ReportProjectDataAfter_Form7();
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

        private void ReportProjectInformation_Form5_FormClosed(object sender, FormClosedEventArgs e)
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
