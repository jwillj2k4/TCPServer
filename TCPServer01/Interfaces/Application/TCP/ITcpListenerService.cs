using System.Net;
using TCPServer01.Interfaces.Application.Form;
using TCPServer01.Interfaces.Models.DTO.Responses.Tcp;

namespace TCPServer01.Interfaces.Application.TCP
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Interface for TCP listener service. </summary>
    ///
    /// <remarks>   Justin, 7/11/2015. </remarks>
    ///-------------------------------------------------------------------------------------------------
    public interface ITcpListenerService
    {
        /// <summary>   Starts a listening. </summary>
        void StartListening();

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   tcp client role. </summary>
        ///
        /// <value> The m TCP client service. </value>
        ///-------------------------------------------------------------------------------------------------
        ITcpClientService MTcpClientService { get; set; }

        /// -------------------------------------------------------------------------------------------------
        ///  <summary>   Begins accept TCP client. </summary>
        /// <param name="byteArrLength">    Length of the byte array. </param>
        /// <param name="form1">            The first form. </param>
        /// <returns>   A TcpState. </returns>
        /// -------------------------------------------------------------------------------------------------
        ITcpResponse BeginAcceptTcpClient(long byteArrLength, IForm form1);

        /// -------------------------------------------------------------------------------------------------
        ///  <summary>   Sends a data. </summary>
        /// <param name="byteArrLength"></param>
        /// <param name="text"> The text. </param>
        /// -------------------------------------------------------------------------------------------------
        void SendData(long byteArrLength, string text);
    }
}