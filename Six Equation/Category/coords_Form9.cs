#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Project_Sabreen.Category
{
    public partial class coords_Form9 : Syncfusion.Windows.Forms.MetroForm
    {
        object[][] allData;
     

        public coords_Form9()
        {
            InitializeComponent();
          
                FullData();
            
           
           
        }
        //int change (double doubleNumber)
        //{
        //    #region
        //    //if (doubleNumber > 0.01 && doubleNumber < 0.10)
        //    //{

        //    //}
        //    //else if (doubleNumber >= 0.10 && doubleNumber < 0.20)
        //    //{

        //    //}
        //    //else if (doubleNumber >= 0.20 && doubleNumber < 0.30)
        //    //{

        //    //}
        //    //else if (doubleNumber >= 0.30 && doubleNumber < 0.40)
        //    //{

        //    //}
        //    //else if (doubleNumber >= 0.40 && doubleNumber < 0.50)
        //    //{

        //    //}
        //    //else if (doubleNumber >= 0.50 && doubleNumber < 0.60)
        //    //{

        //    //}
        //    //else if (doubleNumber >= 0.60 && doubleNumber < 0.70)
        //    //{

        //    //}
        //    //else if (doubleNumber >= 0.70 && doubleNumber < 0.80)
        //    //{

        //    //}
        //    //else if (doubleNumber >= 0.80 && doubleNumber < 0.90)
        //    //{

        //    //}
        //    //else if (doubleNumber >= 0.90 && doubleNumber < 1.0)
        //    //{

        //    //}
        //    #endregion

        //    if (doubleNumber)
        //}
        void FullData()
        {
           

            allData = GetProjectInformation("report2");
            Bitmap bmb1 = new Bitmap(20, 20);
            Bitmap bmb2 = new Bitmap(20, 20);
            Bitmap bmb3 = new Bitmap(20, 20);
            Bitmap bmb4 = new Bitmap(20, 20);
            for (int i = 0; i < allData.Length; i++)
            {
               
                if (Convert.ToDouble(allData[i][1]) > 1 && Convert.ToDouble(allData[i][2]) > 1)
                {
                    //Q1
                    try
                    {
                        double x = Convert.ToDouble(allData[i][1]) * 10;
                        double y = Convert.ToDouble(allData[i][2]) * 10;

                        bmb1.SetPixel(Convert.ToInt32(y), Convert.ToInt32(x), Color.Red);

                        bmb1.RotateFlip(RotateFlipType.Rotate90FlipXY);


                        bmb1.SetResolution(100, 100);
                        pictureBox1.Image = bmb1;
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Invalid data Delete the project and enter new project data,Q1");
                    }
                    

                }
                else if (Convert.ToDouble(allData[i][1]) < 1 && Convert.ToDouble(allData[i][2]) > 1)
                {
                    //Q2
                    try
                    {
                        double x = Convert.ToDouble(allData[i][1]) * 10;
                        double y = Convert.ToDouble(allData[i][2]) * 10;

                        //x = x > 0 ? x : x * -1;

                        //y = y > 0 ? y : y * -1;


                        bmb2.SetPixel(Convert.ToInt32(x), Convert.ToInt32(y), Color.Yellow);

                        bmb2.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        bmb2.SetResolution(100, 100);
                        pictureBox2.Image = bmb2;
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Invalid data Delete the project and enter new project data,Q2");
                    }
                   
                }
                else if (Convert.ToDouble(allData[i][1]) < 1 && Convert.ToDouble(allData[i][2]) < 1)
                {
                    //Q3
                    try
                    {
                        double x = Convert.ToDouble(allData[i][1]) * 10;
                        double y = Convert.ToDouble(allData[i][2]) * 10;

                        //int x = Convert.ToInt32(allData[i][1]);
                        //x = x > 0 ? x : x * -1;
                        //int y = Convert.ToInt32(allData[i][2]);
                        //y = y > 0 ? y : y * -1;

                        bmb3.SetPixel(Convert.ToInt32(y), Convert.ToInt32(x), Color.Blue);

                        bmb3.RotateFlip(RotateFlipType.Rotate270FlipXY);
                        bmb3.SetResolution(100, 100);
                        pictureBox3.Image = bmb3;
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Invalid data Delete the project and enter new project data,Q3");
                    }
                   

                }
                else if (Convert.ToDouble(allData[i][1]) > 1 && Convert.ToDouble(allData[i][2]) < 1)
                {
                    //Q4
                    try
                    {
                        double x = Convert.ToDouble(allData[i][1]) * 10;
                        double y = Convert.ToDouble(allData[i][2]) * 10;

                        //int x = Convert.ToInt32(allData[i][1]);
                        //x = x > 0 ? x : x * -1;
                        //int y = Convert.ToInt32(allData[i][2]);
                        //y = y > 0 ? y : y * -1;

                        bmb4.SetPixel(Convert.ToInt32(x), Convert.ToInt32(y), Color.Green);

                        // bmb.RotateFlip(RotateFlipType.Rotate180FlipXY);
                        bmb4.SetResolution(100, 100);
                        pictureBox4.Image = bmb4;
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Invalid data Delete the project and enter new project data,Q4");
                    }
                   
                }
                else
                {
                    //Bitmap bmb = new Bitmap(10, 10);
                    //int x = Convert.ToInt32(allData[i][1]);
                    //x = x > 0 ? x : x * -1;
                    //int y = Convert.ToInt32(allData[i][2]);
                    //y = y > 0 ? y : y * -1;
                    //bmb.SetPixel(y, x, Color.Red);

                    //bmb.RotateFlip(RotateFlipType.Rotate90FlipXY);
                    //bmb.SetResolution(100, 100);
                    //pictureBox1.Image = bmb;

                    //bmb.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    //pictureBox2.Image = bmb;

                    //bmb.RotateFlip(RotateFlipType.Rotate270FlipXY);
                    //pictureBox3.Image = bmb;

                    //pictureBox4.Image = bmb;

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

        private void sfButton1_Click(object sender, EventArgs e)
        {
            Category.ReportProjectDataBefore_Form6 FRM = new ReportProjectDataBefore_Form6();
            FRM.Show();
            this.Hide();
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

        private void sfButtonShowCoord_Click(object sender, EventArgs e)
        {
            Category.ReportCoord_Form8 FRM = new ReportCoord_Form8();
            FRM.Show();
            this.Hide();
        }

        private void sfButtonShowPDAF_Click(object sender, EventArgs e)
        {
            Category.ReportProjectDataAfter_Form7 FRM = new ReportProjectDataAfter_Form7();
            FRM.Show();
            this.Hide();
        }

        private void coords_Form9_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
