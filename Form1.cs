using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace W5T2DropdownBoxDB
{


    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {

            string conString = "server=server1.logicalview.co.uk;user=c444WS259094;database=c444WS259094Colab;password=Friday@63;CharSet=utf8;";

            MySqlConnection sqlConn = new MySqlConnection(conString);

            string sqlStatement = "SELECT * FROM `tbl_Test`";

            MySqlDataAdapter SqlDataAdapter = new MySqlDataAdapter(sqlStatement, sqlConn);

            DataTable dtUsers = new DataTable();

            sqlConn.Open();

            SqlDataAdapter.Fill(dtUsers);

            sqlConn.Close();



            string sID = cboSelect.SelectedItem.ToString();

            string sName = txtName.Text;
            string sScore = txtScore.Text;
            string sAverage = txtAverage.Text;



            string sNameUpdate = "UPDATE `tbl_Test` SET `Name`=[`"+sName+"`] WHERE `ID` = " + sID;
            string sScoreUpdate = "UPDATE `tbl_Test` SET `Score`=[`"+sScore+"`] WHERE `ID` =" + sID;
            string sAverageUpdate = "UPDATE `tbl_Test` SET `Average`=[`"+sAverage+"`] WHERE `ID` =" + sID;

            bool bScoreErrorCheck = int.TryParse(sScore, out int iResult);
            bool bAverageErrorCheck = int.TryParse(sAverage, out int iResult2);
            bool NamecontainsInt = sName.Any(char.IsDigit);

            

            if (NamecontainsInt == false)
            {
                MySqlCommand sqlComm = new MySqlCommand(sNameUpdate, sqlConn);
            }
            else
            {
                lblError.Text = "Error, name must not use numbers\n";
            }

            if (bScoreErrorCheck == true)
            {
                
                MySqlCommand sqlComm = new MySqlCommand(sScoreUpdate, sqlConn);

            }
            else
            {
                lblError.Text = "Error, Score must only use Numbers\n";
            }

            if (bAverageErrorCheck == true)
            {
                MySqlCommand sqlComm = new MySqlCommand(sAverageUpdate, sqlConn);
            }
            else
            {
                lblError.Text = "Error, Average must only use Numbers\n";
            }

        }

        private void CboSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            string conString = "server=server1.logicalview.co.uk;user=c444WS259094;database=c444WS259094Colab;password=Friday@63;CharSet=utf8;";

            MySqlConnection sqlConn = new MySqlConnection(conString);

            string sID =  cboSelect.SelectedItem.ToString();

            sqlConn.Open();
            string sName = "SELECT `Name` FROM `tbl_Test` WHERE `ID` = " + sID;
            string sScore = "SELECT `Score` FROM `tbl_Test` WHERE `ID` = "+ sID;
            string sAverage = "SELECT `Average` FROM `tbl_Test` WHERE `ID` = " + sID;


                MySqlCommand sqlComm1 = new MySqlCommand(sName, sqlConn);
                sqlComm1.ExecuteNonQuery();


                MySqlCommand sqlComm2 = new MySqlCommand(sScore, sqlConn);
                sqlComm2.ExecuteNonQuery();
            
                MySqlCommand sqlComm3 = new MySqlCommand(sAverage, sqlConn);
                sqlComm3.ExecuteNonQuery();

            DataTable dt = new DataTable();
           // SqlDataAdapter.Fill(dt);


            sqlConn.Close();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //on form load, grab database values and add id's to the dropdown box
            string conString = "server=server1.logicalview.co.uk;user=c444WS259094;database=c444WS259094Colab;password=Friday@63;CharSet=utf8;";

            MySqlConnection sqlConn = new MySqlConnection(conString);

            string sqlStatement = "SELECT * FROM `tbl_Test`";

            MySqlDataAdapter SqlDataAdapter = new MySqlDataAdapter(sqlStatement, sqlConn);

            DataTable dtUsers = new DataTable();

            sqlConn.Open();

            SqlDataAdapter.Fill(dtUsers);

            sqlConn.Close();

            foreach (DataRow dr in dtUsers.Rows)
            {
                cboSelect.Items.Add(dr[0].ToString());
      
            }
        }
    }
}
