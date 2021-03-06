using System;
using TCPServer01.Enums.Tcp;
using TCPServer01.Interfaces.Models.DTO.Responses.Tcp;

namespace TCPServer01.Models.DTO.Responses.Tcp
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A TCP response. </summary>
    ///
    /// <remarks>   Justin, 7/11/2015. </remarks>
    ///-------------------------------------------------------------------------------------------------
    public class TcpResponse : ITcpResponse
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
        /// <summary>   Gets or sets the object. </summary>
        ///
        /// <value> The object. </value>
        ///-------------------------------------------------------------------------------------------------
        public IAsyncResult AsyncResult { get; set; }

        public TcpResponse()
        {
            State = TcpState.None;
            AsyncResult = null;
        }
    }
}