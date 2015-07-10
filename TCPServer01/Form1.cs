using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using TCPServer01.Enums.Tcp;
using TCPServer01.Interfaces.Application.Tcp;
using TCPServer01.Services.Application.Tcp;

namespace TCPServer01
{
    public partial class Form1 : Form
    {
        //define tcp listener 
        ITcpService _mTcpService;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStartListening_Click(object sender, EventArgs e)
        {
           // ITcpService _mTcpService;

            _mTcpService = new TcpService();

            if (!_mTcpService.CreateListener(tbIpAddress.Text, tbPort.Text))
            {
                MessageBox.Show(_mTcpService.Message);
                return;
            }

            MessageBox.Show(string.Format("Now listening at end point: {0}, port {1}", tbIpAddress.Text, tbPort.Text));
        }
    }
}
