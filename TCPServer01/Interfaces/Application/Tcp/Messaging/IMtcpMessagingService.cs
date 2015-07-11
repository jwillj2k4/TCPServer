namespace TCPServer01.Interfaces.Application.Tcp.Messaging
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Interface for mtcp messaging service. </summary>
    ///
    /// <remarks>   Justin, 7/11/2015. </remarks>
    ///-------------------------------------------------------------------------------------------------
    public interface IMTcpMessagingService
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Sends a data. </summary>
        ///
        /// <param name="byteArrLength">    Length of the byte array. </param>
        /// <param name="text">             The text. </param>
        ///-------------------------------------------------------------------------------------------------
        void SendToServer(long byteArrLength, string text);
    }
}