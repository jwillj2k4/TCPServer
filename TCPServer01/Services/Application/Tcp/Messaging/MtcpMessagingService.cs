using System;
using System.Net.Sockets;
using System.Text;
using TCPServer01.Enums.Tcp;
using TCPServer01.Interfaces.Application.Tcp;
using TCPServer01.Interfaces.Application.Tcp.Messaging;
using TCPServer01.Interfaces.Models.DTO.Responses.Tcp;

namespace TCPServer01.Services.Application.Tcp.Messaging
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A TCP messaging service. </summary>
    ///
    /// <remarks>   Justin, 7/11/2015. </remarks>
    ///-------------------------------------------------------------------------------------------------
    public class MTcpMessagingService : IMTcpMessagingService
    {
        /// <summary>   The TCP client service. </summary>
        private readonly ITcpClientService _mTcpClientService;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Justin, 7/11/2015. </remarks>
        ///
        /// <param name="mTcpClientService">    The TCP client service. </param>
        ///-------------------------------------------------------------------------------------------------
        public MTcpMessagingService(ITcpClientService mTcpClientService)
        {
            _mTcpClientService = mTcpClientService;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Sends a data. </summary>
        ///
        /// <remarks>   Justin, 7/11/2015. </remarks>
        ///
        /// <param name="byteArrLength">    Length of the byte array. </param>
        /// <param name="text">             The text. </param>
        ///-------------------------------------------------------------------------------------------------
        public void SendToServer(long byteArrLength, string text)
        {
            var response = new TcpMessageResponse { State = TcpState.Failed };

            if (string.IsNullOrWhiteSpace(text))
            {
                TcpMessageService.ShowMessage("Please type some data!!"); 
                return;
            }
            
            try
            {
                //if the client is null or the socket is not connected, return
                if (_mTcpClientService.MtcpClient == null || !_mTcpClientService.MtcpClient.Client.Connected) return;

                //buffer for data transmission
                //convert user text to bytes
                var tx = Encoding.ASCII.GetBytes(text);

                //begin writing to the byte array
                _mTcpClientService.MtcpClient.GetStream().BeginWrite(tx, 0, tx.Length, ar =>
                {
                    try
                    {
                        //all that is needed for this write call back is to end the write stream
                        ((TcpClient)ar.AsyncState).GetStream().EndWrite(ar);
                    }
                    catch (Exception ex)
                    {
                        response.Result = ex.Message;
                        TcpMessageService.ShowMessage("There was an error", response);
                    }

                }, _mTcpClientService.MtcpClient);

            }
            catch (Exception ex)
            {
                response.Result = ex.Message;
                TcpMessageService.ShowMessage("There was an error", response);
            }
        }
    }
}