using System;
using System.Drawing;
using System.Windows.Forms;

namespace GTA5Helper
{
    public partial class Form1 : Form
    {        
        const int SWITCH_PROCESS_ID = 0;

        Boolean mIsProcessRunning = false;
        int mTotalRunningTimes;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        enum KeyModifier
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            WinKey = 8
        }

        public Form1()
        {
            InitializeComponent();
            RegisterHotKey(this.Handle, SWITCH_PROCESS_ID, (int)KeyModifier.None, Keys.F6.GetHashCode());            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterHotKey(this.Handle, SWITCH_PROCESS_ID);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            switchProcessState();
        }

        private void switchProcessState()
        {
            if(mIsProcessRunning)            
                stopProcess();            
            else           
                startProcess();            
            mIsProcessRunning = !mIsProcessRunning;
        }

        private void startProcess()
        {
            // UI
            buttonStart.Text = "Stop";
            buttonStart.ForeColor = Color.Red;
            domainUpDown.ReadOnly = true;
            log.AppendText("Start the process with " + domainUpDown.Text + " times.\n");
        }

        private void stopProcess()
        {
            // UI
            buttonStart.Text = "Start";
            buttonStart.ForeColor = Color.Blue;
            domainUpDown.ReadOnly = false;
            log.AppendText("Stop the process.\n");
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0x0312)
            {
                switch (m.WParam.ToInt32())
                {
                    case SWITCH_PROCESS_ID:
                        switchProcessState();
                        break;
                    default:
                        break;
                }
            }
        }

        private void domainUpDown_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
