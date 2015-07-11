using System;
using System.Net.Sockets;
using TCPServer01.Enums.Tcp;
using TCPServer01.Interfaces.Models.DTO.Responses.Tcp;

namespace TCPServer01.Models.DTO.Responses.Tcp
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A TCP listener response. </summary>
    ///
    /// <remarks>   Justin, 7/11/2015. </remarks>
    ///-------------------------------------------------------------------------------------------------
    public class TcpListenerResponse : ITcpListenerResponse
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the result. </summary>
        ///
        /// <value> The result. </value>
        ///-------------------------------------------------------------------------------------------------
        public string Result { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the state. </summary>
        ///
        /// <value> The state. </value>
        ///-------------------------------------------------------------------------------------------------
        public TcpState State { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the asynchronous result. </summary>
        ///
        /// <value> The asynchronous result. </value>
        ///-------------------------------------------------------------------------------------------------
        public IAsyncResult AsyncResult { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the listener. </summary>
        ///
        /// <value> The listener. </value>
        ///-------------------------------------------------------------------------------------------------
        public TcpListener Listener { get; set; }
    }
}