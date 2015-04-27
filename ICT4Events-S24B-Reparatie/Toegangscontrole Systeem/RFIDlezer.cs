using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phidgets;
using Phidgets.Events;

namespace ICT4Events_S24B_Reparatie
{
    public class RFIDLezer
    {
        #region Fields
        public Phidgets.RFID rfid { get; set; }

        private Toegangscontrole toegangsControle;
        #endregion

        #region Constructor
        public RFIDLezer(Toegangscontrole toegangsControle)
        {
            this.toegangsControle = toegangsControle;

            rfid = new Phidgets.RFID();

            rfid.Attach += rfid_Attach;
            rfid.Detach += rfid_Detach;

            rfid.Tag += rfid_Tag;
            rfid.TagLost += rfid_TagLost;

            OpenCmdLine(rfid);
        }

        #endregion

        #region Command line open functions

        /// <summary>
        /// Parses command line arguments and calls the appropriate open.
        /// </summary>
        /// <param name="p"></param>
        private void OpenCmdLine(Phidget p)
        {
            openCmdLine(p, null);
        }

        /// <summary>
        /// Parses command line arguments and calls the appropriate open.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="pass"></param>
        private void openCmdLine(Phidget p, String pass)
        {
            int serial = -1;
            String logFile = null;
            int port = 5001;
            String host = null;
            bool remote = false, remoteIp = false;
            string[] args = Environment.GetCommandLineArgs();
            String appName = args[0];

            try
            {
                // Parse the flags.
                for (int i = 1; i < args.Length; i++)
                {
                    if (args[i].StartsWith("-"))
                        switch (args[i].Remove(0, 1).ToLower())
                        {
                            case "l":
                                logFile = (args[++i]);
                                break;
                            case "n":
                                serial = int.Parse(args[++i]);
                                break;
                            case "r":
                                remote = true;
                                break;
                            case "s":
                                remote = true;
                                host = args[++i];
                                break;
                            case "p":
                                pass = args[++i];
                                break;
                            case "i":
                                remoteIp = true;
                                host = args[++i];
                                if (host.Contains(":"))
                                {
                                    port = int.Parse(host.Split(':')[1]);
                                    host = host.Split(':')[0];
                                }
                                break;
                            default:
                                goto usage;
                        }
                    else
                        goto usage;
                }
                if (logFile != null)
                    Phidget.enableLogging(Phidget.LogLevel.PHIDGET_LOG_INFO, logFile);
                if (remoteIp)
                    p.open(serial, host, port, pass);
                else if (remote)
                    p.open(serial, host, pass);
                else
                    p.open(serial);
                return; // Success.
            }
            catch
            {
            }
        usage:
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Invalid Command line arguments." + Environment.NewLine);
            sb.AppendLine("Usage: " + appName + " [Flags...]");
            sb.AppendLine("Flags:\t-n   serialNumber\tSerial Number, omit for any serial");
            sb.AppendLine("\t-l   logFile\tEnable phidget21 logging to logFile.");
            sb.AppendLine("\t-r\t\tOpen remotely");
            sb.AppendLine("\t-s   serverID\tServer ID, omit for any server");
            sb.AppendLine("\t-i   ipAddress:port\tIp Address and Port. Port is optional, defaults to 5001");
            sb.AppendLine("\t-p   password\tPassword, omit for no password" + Environment.NewLine);
            sb.AppendLine("Examples: ");
            sb.AppendLine(appName + " -n 50098");
            sb.AppendLine(appName + " -r");
            sb.AppendLine(appName + " -s myphidgetserver");
            sb.AppendLine(appName + " -n 45670 -i 127.0.0.1:5001 -p paswrd");
            MessageBox.Show(sb.ToString(), "Argument Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Application.Exit();
        }

        #endregion

        #region Methodes

        /// <summary>
        /// Attach event handler...populate the details fields as well as display the attached status.  
        /// Enable the checkboxes to change the values of the attributes of the RFID reader such as enable or disable the antenna and onboard led.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rfid_Attach(object sender, AttachEventArgs e)
        {
            Phidgets.RFID attached = (Phidgets.RFID)sender;

            if (rfid.outputs.Count > 0)
            {
                rfid.Antenna = true;
                rfid.LED = true;
            }
            #region template
            /*
            tbAttached.Text = attached.Attached.ToString();
            tbName.Text = attached.Name;
            tbSerialNo.Text = attached.SerialNumber.ToString();
            tbVersion.Text = attached.Version.ToString();
            tbOutputs.Text = attached.outputs.Count.ToString();

            //if (rfid.outputs.Count > 0)
            {
                cbAntenna.Checked = true;
                rfid.Antenna = true;
                cbAntenna.Enabled = true;
                cbLed.Enabled = true;
                cbLed.Checked = true;
            }
            */
            #endregion
        }

        /// <summary>
        /// Detach event handler...clear all the fields, display the attached status, and disable the checkboxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rfid_Detach(object sender, DetachEventArgs e)
        {
            Phidgets.RFID attached = (Phidgets.RFID)sender;
            if (rfid.outputs.Count > 0)
            {
                rfid.Antenna = false;
                rfid.LED = false;
            }
            #region template
            /*
            Phidgets.RFID detached = (Phidgets.RFID)sender;
            tbAttached.Text = detached.Attached.ToString();
            tbName.Text = "";
            tbSerialNo.Text = "";
            tbVersion.Text = "";
            tbOutputs.Text = "";
            cbLed.Checked = false;

            //if (rfid.outputs.Count > 0)
            {
                
                cbLed.Enabled = false;
            }
            */
            #endregion
        }

        /// <summary>
        /// Tag event handler...we'll display the tag code in the field on the GUI.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rfid_Tag(object sender, TagEventArgs e)
        {
            toegangsControle.RFIDGescand(e.Tag);
            //tbTagStringTagRead.Text = e.Tag;
            //tbProtocolTagRead.Text = e.protocol.ToString();
        }

        /// <summary>
        /// Tag lost event handler...here we simply want to clear our tag field in the GUI.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rfid_TagLost(object sender, TagEventArgs e)
        {
            //tbTagStringTagRead.Text = "";
            //tbProtocolTagRead.Text = "";
        }

        public void Sluit()
        {
            rfid.Attach -= rfid_Attach;
            rfid.Detach -= rfid_Detach;
            rfid.Tag -= rfid_Tag;
            rfid.TagLost -= rfid_TagLost;

            rfid.close();
        }
        #endregion
    }
}
