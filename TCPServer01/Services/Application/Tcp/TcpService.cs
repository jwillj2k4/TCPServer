using System.Net;
using TCPServer01.Enums.Tcp;
using TCPServer01.Interfaces.Application.Tcp;

namespace TCPServer01.Services.Application.Tcp
{
    public class TcpService : ITcpService
    {
        public string Message { get; private set; }

        //tcp server role
        public ITcpListenerService MTcpListenerService { get; set; }

        public TcpState State { get; set; }

        public long ByteArrLength { get; set; }

        public TcpService(long byteArrLength)
        {
            MTcpListenerService = new TcpListenerService();
            ByteArrLength = byteArrLength;
        }

        public bool CreateListener(string ipAddress, string port, Form1 form1)
        {
            IPAddress ipaddr;
            int nPort;
            string tcpClientMessage;
            Message = string.Empty;

            if (!int.TryParse(port, out nPort))
                Message = "invalid port supplied";

            if (!IPAddress.TryParse(ipAddress, out ipaddr))
                Message += " invalid ip address supplied"; //this is the default if the try parse fails

            //if either of these are not set, return back
            if (nPort == 0 || ipaddr == null) return false;

            //create a listener
            MTcpListenerService.CreateListener(ipaddr, nPort);

            //call start method for listener
            MTcpListenerService.StartListening();

            State = MTcpListenerService.BeginAcceptTcpClient(out tcpClientMessage, ByteArrLength, form1);

            Message = tcpClientMessage;

            return true;
        }
    }
}