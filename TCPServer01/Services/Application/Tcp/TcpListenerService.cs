using System;
using System.Net;
using System.Net.Sockets;
using TCPServer01.Enums.Tcp;
using TCPServer01.Interfaces.Application.Form;
using TCPServer01.Interfaces.Application.Tcp;
using TCPServer01.Interfaces.Models.DTO.Responses.Tcp;
using TCPServer01.Models.DTO.Responses.Tcp;
using TCPServer01.Services.Application.Tcp.Messaging;
using TCPServer01.Services.Converters.Tcp;

namespace TCPServer01.Services.Application.Tcp
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A TCP listener service. </summary>
    ///
    /// <remarks>   Justin, 7/11/2015. </remarks>
    ///-------------------------------------------------------------------------------------------------
    public class TcpListenerService : ITcpListenerService
    {
        private readonly TcpListnerConverter _tcpListnerConverter = new TcpListnerConverter();
        
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the TCP listener. </summary>
        ///
        /// <value> The m TCP listener. </value>
        ///-------------------------------------------------------------------------------------------------
        public TcpListener MTcpListener { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   tcp client role. </summary>
        ///
        /// <value> The m TCP client service. </value>
        ///-------------------------------------------------------------------------------------------------
        public ITcpClientService MTcpClientService { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Justin, 7/11/2015. </remarks>
        ///
        /// <param name="ipaddr">   The ipaddr. </param>
        /// <param name="nPort">    The port. </param>
        ///-------------------------------------------------------------------------------------------------
        public TcpListenerService(IPAddress ipaddr, int nPort)
        {
            //create an instance of the client service
            MTcpClientService = new TcpClientService();

            //create a listener with ip and port number
            MTcpListener = new TcpListener(ipaddr, nPort);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Starts a listening. </summary>
        ///
        /// <remarks>   Justin, 7/11/2015. </remarks>
        ///-------------------------------------------------------------------------------------------------
        public void StartListening()
        {
            //start listening to incoming requests
            MTcpListener.Start();
        }

        /// -------------------------------------------------------------------------------------------------
        ///  <summary>   Begins accept TCP client. </summary>
        /// 
        ///  <remarks>   Justin, 7/11/2015. </remarks>
        /// <param name="byteArrLength">    Length of the byte array. </param>
        /// <param name="form1">            The first form. </param>
        /// <returns>   A TcpState. </returns>
        /// -------------------------------------------------------------------------------------------------
        public ITcpResponse BeginAcceptTcpClient(long byteArrLength, IForm form1)
        {
            //async operation to accept incoming requests
            ITcpResponse response = new TcpListenerResponse { Result = string.Empty, State = TcpState.NotReady };

            MTcpListener.BeginAcceptTcpClient(iar =>
            {
                try
                {
                    //cast the iar async state contains reference to original tcp object that called begin accept tcp client
                    //cast object to a listener
                    response = _tcpListnerConverter.Convert(iar);

                    if (response.State != TcpState.Success)
                    {
                        TcpMessageService.ShowMessage("There was an error ", response);
                        return;
                    }

                    MTcpClientService.EndAcceptTcpClient(response.AsyncResult);
                    
                    form1.SetOutput("Client Connected...");
                    
                    response = MTcpClientService.BeginReadStream(byteArrLength, form1);
                }
                catch (Exception ex)
                {
                    response.Result = ex.Message;
                    response.State = TcpState.Failed;
                }

            }, MTcpListener);

            return response;
        }
    }
}