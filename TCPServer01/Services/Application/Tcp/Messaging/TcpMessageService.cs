using System;
using System.Windows.Forms;
using TCPServer01.Interfaces.Models.DTO.Responses.Tcp;
using TCPServer01.Models.DTO.Responses.Tcp;
using TcpState = TCPServer01.Enums.Tcp.TcpState;

namespace TCPServer01.Services.Application.Tcp.Messaging
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A messaging box service. </summary>
    ///
    /// <remarks>   Justin, 7/11/2015. </remarks>
    ///-------------------------------------------------------------------------------------------------
    public class TcpMessageService
    {

        public static void ShowMessage(string message)
        {
            ShowMessage(message, new TcpResponse());
        }

        /// -------------------------------------------------------------------------------------------------
        ///  <summary>   Shows the error. </summary>
        /// 
        ///  <remarks>   Justin, 7/11/2015. </remarks>
        /// <param name="message">  The message. </param>
        /// <param name="response"> The response. </param>
        /// -------------------------------------------------------------------------------------------------
        public static void ShowMessage(string message, ITcpResponse response)
        {
            Show(message, response.Result, response.State, MessageBoxButtons.OK,
                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                MessageBoxOptions.ServiceNotification);

        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Shows. </summary>
        ///
        /// <remarks>   Justin, 7/11/2015. </remarks>
        ///
        /// <param name="message">              The message. </param>
        /// <param name="result">               The result. </param>
        /// <param name="state">                The state. </param>
        /// <param name="ok">                   The ok. </param>
        /// <param name="messageBoxIcon">       The message box icon. </param>
        /// <param name="button1">              The first button. </param>
        /// <param name="serviceNotification">  The service notification. </param>
        ///-------------------------------------------------------------------------------------------------
        public static void Show(string message, string result, TcpState state, MessageBoxButtons ok, MessageBoxIcon messageBoxIcon,
            MessageBoxDefaultButton button1, MessageBoxOptions serviceNotification)
        {
            MessageBox.Show(String.Format("{0} result: {1}, Tcp State: {2}", message, result, state),
                @"Information", ok,
                messageBoxIcon, button1,
                serviceNotification);
        }

    }
}