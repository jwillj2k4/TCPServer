using System;
using System.Net.Sockets;
using TCPServer01.Enums.Tcp;
using TCPServer01.Interfaces.Converters;
using TCPServer01.Interfaces.Models.DTO.Responses.Tcp;
using TCPServer01.Models.DTO.Responses.Tcp;

namespace TCPServer01.Services.Converters.Tcp
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A TCP listner converter. </summary>
    ///
    /// <remarks>   Justin, 7/11/2015. </remarks>
    ///-------------------------------------------------------------------------------------------------
    public class TcpListnerConverter : ITcpListnerConverter
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Converts the given iar. </summary>
        ///
        /// <remarks>   Justin, 7/11/2015. </remarks>
        ///
        /// <param name="iar">  The iar. </param>
        ///
        /// <returns>   A TcpResponse. </returns>
        ///-------------------------------------------------------------------------------------------------
        public ITcpListenerResponse Convert(IAsyncResult iar)
        {
            var response = new TcpListenerResponse();

            var tcpl = iar.AsyncState as TcpListener;

            if (tcpl == null)
            {
                response.Result = "there was an issue casting the TCP listener";

                response.State = TcpState.Failed;
            }

            response.AsyncResult = iar;

            response.Listener = tcpl;
            
            response.State = TcpState.Success;

            return response;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Converts the given TCP response. </summary>
        ///
        /// <remarks>   Justin, 7/11/2015. </remarks>
        ///
        /// <param name="tcpResponse">  The TCP response. </param>
        ///
        /// <returns>   A list of. </returns>
        ///-------------------------------------------------------------------------------------------------
        public ITcpListenerResponse Convert(ITcpResponse tcpResponse)
        {
            ITcpListenerResponse result = new TcpListenerResponse();
            result.State = tcpResponse.State;
            result.AsyncResult = tcpResponse.AsyncResult;
            result.Result = tcpResponse.Result;
            result.Listener = tcpResponse.AsyncResult.AsyncState as TcpListener;
            return result;
        }
    }
}