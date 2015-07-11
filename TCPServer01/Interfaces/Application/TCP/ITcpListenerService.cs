using System.Net;
using TCPServer01.Enums.Tcp;
using TCPServer01.Interfaces.Application.Form;

namespace TCPServer01.Interfaces.Application.TCP
{
    public interface ITcpListenerService
    {
        void CreateListener(IPAddress ipaddr, int nPort);
        
        void StartListening();

        TcpState BeginAcceptTcpClient(out string message, long byteArrLength, IForm form1);

        //tcp client role
        ITcpClientService MTcpClientService { get; set; }
    }
}