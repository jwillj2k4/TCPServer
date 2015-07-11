using System;
using System.Net;
using System.Net.Sockets;
using TCPServer01.Enums.Tcp;
using TCPServer01.Interfaces.Application.Form;
using TCPServer01.Interfaces.Application.TCP;

namespace TCPServer01.Services.Application.Tcp
{
    public class TcpListenerService : ITcpListenerService
    {
        public TcpListener MTcpListener { get; set; }

        public ITcpClientService MTcpClientService { get; set; }

        public void CreateListener(IPAddress ipaddr, int nPort)
        {
            MTcpClientService = new TcpClientService();
            MTcpListener = new TcpListener(ipaddr, nPort);
        }

        public void StartListening()
        {
            MTcpListener.Start();
        }

        public TcpState BeginAcceptTcpClient(out string message, long byteArrLength, IForm form1)
        {
            var result = string.Empty;
            var state = TcpState.None;

            MTcpListener.BeginAcceptTcpClient(iar =>
            {
                try
                {
                    //cast the iar async state contains reference to original tcp object that called begin accept tcp client
                    //cast object to a listener
                    var tcpl = iar.AsyncState as TcpListener;

                    if (tcpl == null)
                    {
                        result = "there was an issue casting the TCP listener";

                        state = TcpState.FailedToStart;
                        return;
                    }

                    state = MTcpClientService.EndAcceptTcpClient(iar, out result);
                    
                    form1.SetOutput("Client Connected...");
                    
                    state = MTcpClientService.BeginReadStream(byteArrLength, out result, form1);
                }
                catch (Exception ex)
                {
                    result = ex.Message;
                    state = TcpState.FailedToStart;
                }

            }, MTcpListener);

            message = result;
            return state;
        }
    }
}