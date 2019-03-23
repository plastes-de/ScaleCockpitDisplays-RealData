using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.Management;

namespace RxTxSimulator
{
    public partial class FormMain : Form
    {
        protected const byte ACK = 6;
        private static SimValList m_listSimVals = new SimValList();
        private static bool ExitLoop;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            ExitLoop = false;

            foreach (var sv in m_listSimVals)
            {
                String s = sv.Pos.ToString() + "\t" + "0" + "\t" + "-";
                listBoxOutput.Items.Add(s);
            }

            foreach (string s in SerialPort.GetPortNames())
            {
                string c = s; // TODO ComPortNames.ComPortNameFromFriendlyNamePrefix(s);

                try
                {
                    ManagementObjectSearcher searcher =
                        new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PnPEntity");

                    foreach (ManagementObject queryObj in searcher.Get())
                    {
                        if (queryObj["Caption"] != null)
                        {
                            if (queryObj["Caption"].ToString().Contains("(" + c))
                            {
                                c = c + " " + queryObj["Caption"];
                                break;
                                // Console.WriteLine("serial port : {0}", queryObj["Caption"]);
                            }
                        }
                    }
                }
                catch (ManagementException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                if (c != null)
                {
                    comboBoxComPort.Items.Add(c);
                }
                else
                {
                    comboBoxComPort.Items.Add(s);
                }
            }
            comboBoxComPort.SelectedIndex = 1;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Byte[] bufferRead = new byte[10];
            String sRow = "";
            string sPort = comboBoxComPort.SelectedItem.ToString();

            sPort = sPort.Substring(0, 5).TrimEnd(); 
            sPort = sPort.ToLower();

            ExitLoop = false;


            serialPort1.PortName = sPort; 
            serialPort1.BaudRate = 115200;
            serialPort1.Parity = Parity.None;
            serialPort1.DataBits = 8;
            serialPort1.StopBits = StopBits.One;
            serialPort1.Handshake = Handshake.None;
            serialPort1.ReadTimeout = 100;
            serialPort1.WriteTimeout = 100;
            //serialPort1.RtsEnable=true;
            //serialPort1.DtrEnable = true;

            serialPort1.Open();
            while (ExitLoop == false)
            {
                foreach (var sv in m_listSimVals)
                {
                    Application.DoEvents();
                    switch (sv.Style)
                    {
                        case SimVal.SimStyles.STRING:
                            sRow = "@" + string.Format("{0:d2}", sv.Pos) + ":" + sv.Text + ";\n";
                            break;
                        case SimVal.SimStyles.COORD:
                            sRow = "@" + string.Format("{0:d2}", sv.Pos) + ":" + sv.Text + ";\n";
                            break;
                        case SimVal.SimStyles.INTEGER:
                            if (sv.CurrValue < sv.RangeMin)
                            {
                                sv.CurrValue += Math.Abs(sv.Speed);
                                sv.Speed *= (-1);
                            }
                            else if (sv.CurrValue >= sv.RangeMax)
                            {
                                sv.CurrValue -= Math.Abs(sv.Speed);
                                sv.Speed *= (-1);
                            }
                            else
                            {
                                sv.CurrValue += sv.Speed;
                            }

                            sRow = "@" + string.Format("{0:d2}", sv.Pos) + ":" + sv.CurrValue.ToString() + ";\n";
                            break;
                    }
                    if (serialPort1.IsOpen)
                    {
                        // Ausgabe der zu sendenden Werte.
                        for (int n = 0; n < listBoxOutput.Items.Count; n++)
                        {
                            String s = listBoxOutput.Items[n].ToString();
                            string[] words = s.Split('\t');

                            if (words[0] == sv.Pos.ToString())
                            {
                                int nValue = Int32.Parse(words[1]) + 1;
                                String sItem = sv.Pos.ToString() + "\t" + nValue.ToString() + "\t" + sRow;

                                listBoxOutput.SelectedIndex = listBoxOutput.FindString(sv.Pos.ToString() + "\t");
                                listBoxOutput.Items[listBoxOutput.SelectedIndex] = sItem;
                            }
                        } // for (int n = 0; n < listBoxOutput.Items.Count; n++)

                        serialPort1.Write(sRow);
                    } // if (serialPort1.IsOpen)
                } // foreach (var sv in m_listSimVals)
            } // while (ExitLoop == false)
            serialPort1.Close();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            ExitLoop = true;
        }

        private void pictureBoxLogo_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxComPort_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            listBoxOutput.Height = this.Bottom - this.Top - listBoxOutput.Top - 50;
            listBoxOutput.Width = this.Right - this.Left - 50;
        }
    }
}
