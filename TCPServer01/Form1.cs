using System;
using System.Windows.Forms;
using TCPServer01.Interfaces.Application.Form;
using TCPServer01.Interfaces.Application.Tcp;
using TCPServer01.Services.Application.Tcp;

namespace TCPServer01
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A form 1. </summary>
    ///
    /// <remarks>   Justin, 7/11/2015. </remarks>
    ///-------------------------------------------------------------------------------------------------
    public partial class Form1 : Form, IForm
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Callback, called when the set text. </summary>
        ///
        /// <remarks>   Justin, 7/11/2015. </remarks>
        ///
        /// <param name="text"> The text. </param>
        ///-------------------------------------------------------------------------------------------------
        delegate void SetTextCallback(string text);

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Callback, called when the get text. </summary>
        ///
        /// <remarks>   Justin, 7/11/2015. </remarks>
        ///
        /// <returns>   A string. </returns>
        ///-------------------------------------------------------------------------------------------------
        delegate string GetTextCallback();

        //define tcp listener 
        /// <summary>   The TCP service. </summary>
        ITcpService _mTcpService;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Justin, 7/11/2015. </remarks>
        ///-------------------------------------------------------------------------------------------------
        public Form1()
        {
            InitializeComponent();
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Sets an output. </summary>
        ///
        /// <remarks>   Justin, 7/11/2015. </remarks>
        ///
        /// <param name="text"> The text. </param>
        ///-------------------------------------------------------------------------------------------------
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

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the output. </summary>
        ///
        /// <remarks>   Justin, 7/11/2015. </remarks>
        ///
        /// <returns>   The output. </returns>
        ///-------------------------------------------------------------------------------------------------
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

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Event handler. Called by btnStartListening for click events. </summary>
        ///
        /// <remarks>   Justin, 7/11/2015. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ///-------------------------------------------------------------------------------------------------
        private void btnStartListening_Click(object sender, EventArgs e)
        {
            // ITcpService _mTcpService;

            _mTcpService = new TcpService(655568);

            //pass Ip address, port number and form pointer to create a tcp listner and client (tcp server and client)
            if (!_mTcpService.CreateTcpListenerandClient(tbIpAddress.Text, tbPort.Text, this))
            {
                //display the error message if not successful
                MessageBox.Show(_mTcpService.Message);
                return;
            }

            MessageBox.Show(string.Format("Now listening at end point: {0}, port {1}", tbIpAddress.Text, tbPort.Text));
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            _mTcpService.SendData(tbPayload.Text);
        }
    }
}
