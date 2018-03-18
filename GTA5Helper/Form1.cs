using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GTA5Helper
{
    public partial class Form1 : Form
    {        
        const int SWITCH_PROCESS_ID = 0;
        const int TEST_ID = 1;

        Boolean mIsProcessRunning = false;
        int mTotalRunningTimes;
        BackgroundWorker mBackgroundWorker;

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
            RegisterHotKey(this.Handle, TEST_ID, (int)KeyModifier.None, Keys.F7.GetHashCode());
            mBackgroundWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            mBackgroundWorker.DoWork += new DoWorkEventHandler(MyTask.loop);
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
            if (mIsProcessRunning)            
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
            MyTask.sIsRun = true;
            mBackgroundWorker.RunWorkerAsync();
        }

        private void stopProcess()
        {
            // UI
            buttonStart.Text = "Start";
            buttonStart.ForeColor = Color.Blue;
            domainUpDown.ReadOnly = false;
            log.AppendText("Stop the process.\n");
            MyTask.sIsRun = false;
            mBackgroundWorker.CancelAsync();
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
                    case TEST_ID:
                        log.AppendText(Cursor.Position.X + ", " + Cursor.Position.Y + "\n");
                        MouseSimulator.LeftClick();
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
