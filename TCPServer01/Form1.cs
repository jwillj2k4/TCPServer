using System;
using System.Windows.Forms;
using TCPServer01.Interfaces.Application.Form;
using TCPServer01.Interfaces.Application.Tcp;
using TCPServer01.Services.Application.Tcp;

namespace TCPServer01
{
    public partial class Form1 : Form, IForm
    {
        delegate void SetTextCallback(string text);
        delegate string GetTextCallback();

        //define tcp listener 
        ITcpService _mTcpService;

        public Form1()
        {
            InitializeComponent();
        }

        public void SetOutput(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (tbConsoleOutput.InvokeRequired)
            {
                SetTextCallback d = SetOutput;
                Invoke(d, text);
            }
            else
            {
                tbConsoleOutput.Text += text + Environment.NewLine;
            }
        }

        public string GetOutput()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (tbConsoleOutput.InvokeRequired)
            {
                GetTextCallback d = GetOutput;
                Invoke(d);
            }
            else
            {
               return tbConsoleOutput.Text;
            }

            return string.Empty;
        }

        private void btnStartListening_Click(object sender, EventArgs e)
        {
            // ITcpService _mTcpService;

            _mTcpService = new TcpService(655568);

            if (!_mTcpService.CreateListener(tbIpAddress.Text, tbPort.Text, this))
            {
                MessageBox.Show(_mTcpService.Message);
                return;
            }

            MessageBox.Show(string.Format("Now listening at end point: {0}, port {1}", tbIpAddress.Text, tbPort.Text));
        }
    }
}
