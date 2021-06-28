using MANTRA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MANTRA.MFS100
{
    public partial class frmMFS100 : Form
    {
        public frmMFS100()
        {
            InitializeComponent();
        }
        MFS100 mfs100 = null;
        int quality = 60;
        int timeout = 10000;
        string datapath = Application.StartupPath + "\\FingerData";
        byte[] ISOTemplate = null;
        byte[] ANSITemplate = null;
        DeviceInfo deviceInfo = null;
        string key = "";
        int MatchThreshold = 1400;
        private void frmMFS100_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            lblSerial.Text = "";
            resetControl();
            mfs100 = new MFS100(key);
            mfs100.OnMFS100Attached += OnMFS100Attached;
            mfs100.OnMFS100Detached += OnMFS100Detached;
            mfs100.OnPreview += OnPreview;
            mfs100.OnCaptureCompleted += OnCaptureCompleted;
            try
            {
                if (!Directory.Exists(datapath))
                {
                    Directory.CreateDirectory(datapath);
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, true);
            }
        }

        private void frmMFS100_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                mfs100.Dispose();
            }
            catch
            {

            }
        }

        private void btnVersion_Click(object sender, EventArgs e)
        {
            try
            {
                string version = mfs100.GetSDKVersion();
                ShowMessage("SDK Version: " + version, false);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.ToString(), false);
            }

        }

        private void btnCheckDevice_Click(object sender, EventArgs e)
        {
            try
            {
                if (mfs100.IsConnected())
                {
                    ShowMessage("Device Connected", false);
                }
                else
                {
                    ShowMessage("Device not connected", false);
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.ToString(), true);
            }

        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            try
            {
                int ret = mfs100.Init();
                if (ret != 0)
                {
                    ShowMessage(mfs100.GetErrorMsg(ret), true);
                }
                else
                {
                    deviceInfo = mfs100.GetDeviceInfo();
                    if (deviceInfo != null)
                    {
                        string scannerInfo = "SERIAL NO.: " + deviceInfo.SerialNo + "     MAKE: " + deviceInfo.Make + "     MODEL: " + deviceInfo.Model + "\nWIDTH: " + deviceInfo.Width.ToString() + "     HEIGHT: " + deviceInfo.Height.ToString() + "     CERT: " + mfs100.GetCertification();
                        lblSerial.Text = scannerInfo;
                    }
                    else
                    {
                        lblSerial.Text = "";
                    }
                    ShowMessage(mfs100.GetErrorMsg(ret), false);
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.ToString(), true);
            }
            finally
            {
                GC.Collect();
            }
        }

        private void btnStartCapture_Click(object sender, EventArgs e)
        {
            try
            {
                resetControl();
                ISOTemplate = null;
                ANSITemplate = null;
                if (setQuality() == false)
                {
                    return;
                }
                if (setTimeout() == false)
                {
                    return;
                }
                int ret = mfs100.StartCapture(quality, timeout, chkShowPreview.Checked);
                if (ret != 0)
                {
                    ShowMessage(mfs100.GetErrorMsg(ret), true);
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.ToString(), true);
            }
            finally
            {
                GC.Collect();
            }
        }

        private void btnStopCapture_Click(object sender, EventArgs e)
        {
            try
            {
                int ret = mfs100.StopCapture();
                ShowMessage(mfs100.GetErrorMsg(ret), false);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.ToString(), true);
            }
            finally
            {
                GC.Collect();
            }
        }

        private void btnAutoCapture_Click(object sender, EventArgs e)
        {
            resetControl();
            Thread trd = new Thread(() =>
            {
                try
                {
                    FingerData fingerprintData = null;
                    ISOTemplate = null;
                    ANSITemplate = null;
                    resetControl();
                    if (setQuality() == false)
                    {
                        return;
                    }
                    int ret = mfs100.AutoCapture(ref fingerprintData, timeout, chkShowPreview.Checked, chkIsDetectFinger.Checked);
                    if (ret != 0)
                    {
                        ShowMessage(mfs100.GetErrorMsg(ret), true);
                    }
                    else
                    {
                        //lblStatus.Text = "Success: Quality: " + fingerprintData.Quality.ToString() + " Nfiq: " + fingerprintData.Nfiq.ToString();
                        File.WriteAllBytes(datapath + "//ISOTemplate.iso", fingerprintData.ISOTemplate);
                        File.WriteAllBytes(datapath + "//ISOImage.iso", fingerprintData.ISOImage);
                        File.WriteAllBytes(datapath + "//AnsiTemplate.ansi", fingerprintData.ANSITemplate);
                        File.WriteAllBytes(datapath + "//RawData.raw", fingerprintData.RawData);
                        fingerprintData.FingerImage.Save(datapath + "//FingerImage.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                        File.WriteAllBytes(datapath + "//WSQImage.wsq", fingerprintData.WSQImage);
                        ISOTemplate = new byte[fingerprintData.ISOTemplate.Length];
                        fingerprintData.ISOTemplate.CopyTo(ISOTemplate, 0);
                        ANSITemplate = new byte[fingerprintData.ANSITemplate.Length];
                        fingerprintData.ANSITemplate.CopyTo(ANSITemplate, 0);
                        string info = "Quality: " + fingerprintData.Quality.ToString() + "     Nfiq: " + fingerprintData.Nfiq.ToString() + "     Bpp: " + fingerprintData.Bpp.ToString() + "     GrayScale:" + fingerprintData.GrayScale.ToString() + "\nW(in):" + fingerprintData.InWidth.ToString() + "     H(in):" + fingerprintData.InHeight.ToString() + "     area(in):" + fingerprintData.InArea.ToString() + "     Dpi/Ppi:" + fingerprintData.Resolution.ToString() + "     Compress Ratio:" + fingerprintData.WSQCompressRatio.ToString() + "     WSQ Info:" + fingerprintData.WSQInfo.ToString(); 
                        lblStatus.Text = info;
                        ShowMessage("Capture Success.\nFinger data is saved at application path", false);
                    }
                }
                catch (Exception ex)
                {
                    ShowMessage(ex.ToString(), true);
                }
                finally
                {
                    GC.Collect();
                }
            });
            trd.Start();

        }

        private void btnMatchISOTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                if (ISOTemplate != null && ISOTemplate.Length > 0)
                {
                    int score = 0;
                    // you can pass here two different ISOTemplates
                    int ret = mfs100.MatchISO(ISOTemplate, ISOTemplate, ref score);
                    if (ret == 0)
                    {
                        if (score >= MatchThreshold)
                        {
                            ShowMessage("Finger matched with score: " + score.ToString(), false);
                        }
                        else
                        {
                            ShowMessage("Finger not matched, score: " + score.ToString() + " is too low", false);
                        }
                    }
                    else
                    {
                        ShowMessage(mfs100.GetErrorMsg(ret), true);
                    }
                }
                else
                {
                    ShowMessage("Please capture finger first", true);
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.ToString(), true);
            }
            finally
            {
                GC.Collect();
            }
        }

        private void btnMatchANSITemplate_Click(object sender, EventArgs e)
        {
            try
            {
                if (ISOTemplate != null && ISOTemplate.Length > 0)
                {
                    int score = 0;
                    // you can pass here two different ANSITemplate
                    int ret = mfs100.MatchANSI(ANSITemplate, ANSITemplate, ref score);
                    if (ret == 0)
                    {
                        if (score >= MatchThreshold)
                        {
                            ShowMessage("Finger matched with score: " + score.ToString(), false);
                        }
                        else
                        {
                            ShowMessage("Finger not matched, score: " + score.ToString() + " is too low", false);
                        }
                    }
                    else
                    {
                        ShowMessage(mfs100.GetErrorMsg(ret), true);
                    }
                }
                else
                {
                    ShowMessage("Please capture finger first", true);
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.ToString(), true);
            }
            finally
            {
                GC.Collect();
            }
        }

        private void btnUninit_Click(object sender, EventArgs e)
        {
            try
            {
                int ret = mfs100.Uninit();
                ShowMessage(mfs100.GetErrorMsg(ret), false);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.ToString(), true);
            }
            finally
            {
                GC.Collect();
            }
        }

        void OnMFS100Attached()
        {
            ShowMessage("MFS100 found, You can initialized now", false);
        }
        void OnMFS100Detached()
        {
            ShowMessage("MFS100 removed", true);
        }

        void OnCaptureCompleted(bool status, int errorCode, string errorMsg, FingerData fingerprintData)
        {
            try
            {
                if (status)
                {
                    picFinger.Image = fingerprintData.FingerImage;
                    picFinger.Refresh();
                    //lblStatus.Text = "Success: Quality: " + fingerprintData.Quality.ToString() + " Nfiq: " + fingerprintData.Nfiq.ToString();

                    File.WriteAllBytes(datapath + "//ISOTemplate.iso", fingerprintData.ISOTemplate);
                    File.WriteAllBytes(datapath + "//ISOImage.iso", fingerprintData.ISOImage);
                    File.WriteAllBytes(datapath + "//AnsiTemplate.ansi", fingerprintData.ANSITemplate);
                    File.WriteAllBytes(datapath + "//RawData.raw", fingerprintData.RawData);
                    fingerprintData.FingerImage.Save(datapath + "//FingerImage.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                    File.WriteAllBytes(datapath + "//WSQImage.wsq", fingerprintData.WSQImage);

                    ISOTemplate = new byte[fingerprintData.ISOTemplate.Length];
                    fingerprintData.ISOTemplate.CopyTo(ISOTemplate, 0);
                    ANSITemplate = new byte[fingerprintData.ANSITemplate.Length];
                    fingerprintData.ANSITemplate.CopyTo(ANSITemplate, 0);

                    string info = "Quality: " + fingerprintData.Quality.ToString() + "     Nfiq: " + fingerprintData.Nfiq.ToString() + "     Bpp: " + fingerprintData.Bpp.ToString() + "     GrayScale:" + fingerprintData.GrayScale.ToString() + "\nW(in):" + fingerprintData.InWidth.ToString() + "     H(in):" + fingerprintData.InHeight.ToString() + "     area(in):" + fingerprintData.InArea.ToString() + "     Dpi/Ppi:" + fingerprintData.Resolution.ToString() + "     Compress Ratio:" + fingerprintData.WSQCompressRatio.ToString() + "     WSQ Info:" + fingerprintData.WSQInfo.ToString(); 
                    lblStatus.Text = info;
                    ShowMessage("Capture Success.\nFinger data is saved at application path", false);
                }
                else
                {
                    lblStatus.Text = "Failed: error: " + errorCode.ToString() + " (" + errorMsg + ")";
                }
                lblStatus.Refresh();
            }
            catch (Exception ex)
            {
                ShowMessage(ex.ToString(), true);
            }
            finally
            {
                GC.Collect();
            }
        }

        void OnPreview(FingerData fingerprintData)
        {
            Thread trd = new Thread(() =>
               {
                   try
                   {
                       if (fingerprintData != null)
                       {
                           picFinger.Image = fingerprintData.FingerImage;
                           picFinger.Refresh();
                           lblStatus.Text = "Quality: " + fingerprintData.Quality.ToString();
                           lblStatus.Refresh();
                       }
                   }
                   catch (Exception ex)
                   {
                   }
               });
            trd.Start();

        }

        bool setQuality()
        {
            try
            {
                quality = Convert.ToInt32(txtQuality.Text.Trim());
                return true;
            }
            catch (Exception ex)
            {
                ShowMessage("Invalid Quality Value", true);
            }
            finally
            {
                GC.Collect();
            }
            return false;

        }

        bool setTimeout()
        {
            try
            {
                timeout = Convert.ToInt32(txtTimeout.Text.Trim());
                return true;
            }
            catch (Exception ex)
            {
                ShowMessage("Invalid Timeout Value", true);
            }
            finally
            {
                GC.Collect();
            }
            return false;

        }

        void resetControl()
        {
            lblStatus.Text = "";
            picFinger.Image = null;
        }

        void ShowMessage(string msg, bool iserror)
        {
            MessageBox.Show(msg, "MFS100", MessageBoxButtons.OK, (iserror ? MessageBoxIcon.Error : MessageBoxIcon.Information), MessageBoxDefaultButton.Button1);
        }

    }
}
