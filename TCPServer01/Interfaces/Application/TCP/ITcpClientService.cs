using System;
using System.Net.Sockets;
using TCPServer01.Interfaces.Application.Form;
using TCPServer01.Interfaces.Models.DTO.Responses.Tcp;

namespace TCPServer01.Interfaces.Application.TCP
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Interface for TCP client service. </summary>
    ///
    /// <remarks>   Justin, 7/11/2015. </remarks>
    ///-------------------------------------------------------------------------------------------------
    public interface ITcpClientService
    {
        /// -------------------------------------------------------------------------------------------------
        ///  <summary>   Ends accept TCP client. </summary>
        /// <param name="asyncResult"></param>
        /// <returns>   A TcpState. </returns>
        /// -------------------------------------------------------------------------------------------------
        ITcpResponse EndAcceptTcpClient(IAsyncResult asyncResult);

        /// -------------------------------------------------------------------------------------------------
        ///  <summary>   Begins read stream. </summary>
        /// <param name="byteArrLength">    Length of the byte array. </param>
        /// <param name="form1">            The first form. </param>
        /// <returns>   A TcpState. </returns>
        /// -------------------------------------------------------------------------------------------------
        ITcpResponse BeginReadStream(long byteArrLength, IForm form1);

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the result text. </summary>
        ///
        /// <value> The result text. </value>
        ///-------------------------------------------------------------------------------------------------
        string ResultText { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the mtcp client. </summary>
        ///
        /// <value> The mtcp client. </value>
        ///-------------------------------------------------------------------------------------------------
        TcpClient MtcpClient { get; set; }
    }
}