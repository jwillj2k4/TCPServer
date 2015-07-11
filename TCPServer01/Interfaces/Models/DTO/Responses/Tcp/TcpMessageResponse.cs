using System;
using TCPServer01.Enums.Tcp;

namespace TCPServer01.Interfaces.Models.DTO.Responses.Tcp
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A TCP message response. </summary>
    ///
    /// <remarks>   Justin, 7/11/2015. </remarks>
    ///-------------------------------------------------------------------------------------------------
    public class TcpMessageResponse : ITcpMessageResponse
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
    }
}