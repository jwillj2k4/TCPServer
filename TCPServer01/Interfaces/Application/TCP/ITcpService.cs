using TCPServer01.Enums.Tcp;
using TCPServer01.Interfaces.Application.Form;
using TCPServer01.Interfaces.Application.Tcp;

namespace TCPServer01.Interfaces.Application.Tcp
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Interface for TCP service. </summary>
    ///
    /// <remarks>   Justin, 7/11/2015. </remarks>
    ///-------------------------------------------------------------------------------------------------
    public interface ITcpService
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the message. </summary>
        ///
        /// <value> The message. </value>
        ///-------------------------------------------------------------------------------------------------
        string Message { get; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the state. </summary>
        ///
        /// <value> The state. </value>
        ///-------------------------------------------------------------------------------------------------
        TcpState State { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the length of the byte array. </summary>
        ///
        /// <value> The length of the byte array. </value>
        ///-------------------------------------------------------------------------------------------------
        long ByteArrLength { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Creates a listener. </summary>
        ///
        /// <param name="ipAddress">    The IP address. </param>
        /// <param name="port">         The port. </param>
        /// <param name="form1">        The first form. </param>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>
        ///-------------------------------------------------------------------------------------------------
        bool CreateTcpListenerandClient(string ipAddress, string port, IForm form1);

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Sends a data. </summary>
        ///
        /// <param name="text"> The text. </param>
        ///-------------------------------------------------------------------------------------------------
        void SendToServer(string text);
    }
}
