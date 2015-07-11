using System;
using TCPServer01.Interfaces.Models.DTO.Responses.Tcp;

namespace TCPServer01.Interfaces.Converters
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Interface for TCP listner converter. </summary>
    ///
    /// <remarks>   Justin, 7/11/2015. </remarks>
    ///-------------------------------------------------------------------------------------------------
    public interface ITcpListnerConverter
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Converts the given iar. </summary>
        ///
        /// <param name="iar">  The iar. </param>
        ///
        /// <returns>   A TcpResponse. </returns>
        ///-------------------------------------------------------------------------------------------------
        ITcpListenerResponse Convert(IAsyncResult iar);
    }
}