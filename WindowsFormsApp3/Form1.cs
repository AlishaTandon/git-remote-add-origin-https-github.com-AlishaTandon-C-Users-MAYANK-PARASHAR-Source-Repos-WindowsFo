using MANTRA;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using OracleCommand = Oracle.ManagedDataAccess.Client.OracleCommand;
using OracleConnection = Oracle.ManagedDataAccess.Client.OracleConnection;
using OracleDataAdapter = Oracle.ManagedDataAccess.Client.OracleDataAdapter;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.IO;
using System.Linq;



namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        static byte[] ToMatch = null;
        public Form1()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            String connectionstring = OracleConnString("mayank", "1521", "XE", "SYSTEM", "1234");
            
            {



                OracleConnection con = new OracleConnection(connectionstring);
                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = "Select * from CASBNEW.CASB_CANDIDATES";
                cmd.Connection = con;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        byte[] fileBytes = (byte[])ds.Tables[0].Rows[i]["FINGER_PRINT"];

                        int score = 0;
                        MFS100 mfs100 = new MFS100();
                        int ret = mfs100.MatchANSI(fileBytes, ToMatch, ref score);
                        mfs100 = null;
                        if (ret == 0)

                        {
                            if (score >= 5000)
                            { MessageBox.Show("Finger matched with score: " + score.ToString());
                                label9.Text = "Candidate Found Successfully";
                                textRollNo.Text = (ds.Tables[0].Rows[i]["Roll_No"].ToString()).Trim();
                                textFirstName.Text = (ds.Tables[0].Rows[i]["First_Name"].ToString()).Trim();
                                textLastName.Text = (ds.Tables[0].Rows[i]["Last_Name"].ToString()).Trim();
                                textAadharNo.Text = (ds.Tables[0].Rows[i]["Aadhar_No"].ToString()).Trim();
                                break;
                            }
                           // else {
                             //   MessageBox.Show("Finger not matched, score: " + score.ToString() + " is too low"); }
                        }
                        
                        //else MessageBox.Show(mfs100.GetErrorMsg(ret));


                    }
                    if (textFirstName.Text == "")
                    {
                        MessageBox.Show("fingerprint not Matched");
                    }


                   
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
            button1.Enabled = true;
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

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            textAadharNo.Text = "";
            textFirstName.Text = "";
            textLastName.Text = "";
            textRollNo.Text = "";
            MFS100 mfs100 = null;
            FingerData fingerprintData = new FingerData();
            mfs100 = new MFS100();
            // mfs100.OnMFS100Attached += OnMFS100Attached;
            // mfs100.OnMFS100Detached += OnMFS100Detached;
            mfs100.OnPreview += OnPreview;
            mfs100.OnCaptureCompleted += OnCaptureCompleted;



            if (mfs100.IsConnected())
            {
                MessageBox.Show("Device Connected");
            }
            else
            {
                MessageBox.Show("Device not connected");
            }

            int ret2 = mfs100.Init();
            if (ret2 != 0) { MessageBox.Show("Error initializing"); }
            int ret = mfs100.StartCapture(80,0, true);
            if (ret != 0) { MessageBox.Show("Error capturing"); }


        }
        void OnPreview(FingerData fingerprintData)
        {
            try
            {
                if (fingerprintData != null)
                {
                    picFinger.Image = fingerprintData.FingerImage;
                    // picFinger.Refresh();

                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }



        }

        void OnCaptureCompleted(bool status, int errorCode, string errorMsg, FingerData fingerprintData)
        {
            string datapath = "D://FINGERPRINTMATCH";
            Console.WriteLine(status);
            try
            {
                if (status)
                {

                    File.WriteAllBytes(datapath + "//RollNoTemplate.ansi", fingerprintData.ANSITemplate);

                    //fingerprintData.FingerImage.Save(datapath + "//RollNoFingerImage.bmp", System.Drawing.Imaging.ImageFormat.Bmp); 
                    //File.WriteAllBytes(datapath + "//RollNoWSQImage.wsq", fingerprintData.WSQImage);
                    MessageBox.Show("Capture Success");
                    

                    FileStream stream = File.OpenRead(datapath + "//RollNoTemplate.ansi");
                    ToMatch = new byte[stream.Length];
                    stream.Read(ToMatch, 0, ToMatch.Length);
                    stream.Close();
                    File.Delete(datapath + "//RollNoTemplate.ansi");

                    if (button2.InvokeRequired)
                    {
                        button2.Invoke((MethodInvoker)delegate { button2.Enabled = true; });
                    }
                    
                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }


}




