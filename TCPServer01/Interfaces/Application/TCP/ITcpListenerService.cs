using System.Net;
using TCPServer01.Enums.Tcp;

namespace TCPServer01.Services.Application.Tcp
{
    public interface ITcpListenerService
    {
        void CreateListener(IPAddress ipaddr, int nPort);
        
        void StartListening();

        TcpState BeginAcceptTcpClient(out string message, long byteArrLength, Form1 form1);

        //tcp client role
        ITcpClientService MTcpClientService { get; set; }
    }
}