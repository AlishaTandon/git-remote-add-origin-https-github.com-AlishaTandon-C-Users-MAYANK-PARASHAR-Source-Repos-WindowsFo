using System;
using System.Data;
using System.Windows.Forms;
using OracleCommand = Oracle.ManagedDataAccess.Client.OracleCommand;
using OracleConnection = Oracle.ManagedDataAccess.Client.OracleConnection;
using OracleDataAdapter = Oracle.ManagedDataAccess.Client.OracleDataAdapter;


namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            String connectionstring = OracleConnString("mayank", "1521", "XE", "SYSTEM", "1234");
            if (textRollNo.Text.Length != 10)
            {
                MessageBox.Show("Invalid Roll No");

            }
            else
            {



                OracleConnection con = new OracleConnection(connectionstring);
                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = "Select * from CASBNEW.CASB_CANDIDATES where ROLL_NO=" + textRollNo.Text; ;
                cmd.Connection = con;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    label9.Text = "Candidate Found Successfully";
                    textFirstName.Text = (ds.Tables[0].Rows[0]["First_Name"].ToString()).Trim();
                    textLastName.Text = (ds.Tables[0].Rows[0]["Last_Name"].ToString()).Trim();
                    textAadharNo.Text = (ds.Tables[0].Rows[0]["Aadhar_No"].ToString()).Trim();
                }
                else
                {
                    label9.Text = "Candidate Not Found - Search Again";
                    textRollNo.Text = "";
                    textFirstName.Text = "";
                    textLastName.Text = "";

                }
                con.Close();
            }
        }
        public string OracleConnString(string host, string port, string servicename, string user, string pass)
        {
            return String.Format(
              "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})" +
              "(PORT={1}))(CONNECT_DATA=(SERVICE_NAME={2})));User Id={3};Password={4};",
              host,
              port,
              servicename,
              user,
              pass);
        }

    }
}


 