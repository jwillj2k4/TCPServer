using TCPServer01.Enums.Tcp;
using TCPServer01.Services.Application.Tcp;

namespace TCPServer01.Interfaces.Application.Tcp
{
    public interface ITcpService
    {
        string Message { get; }
        ITcpListenerService MTcpListenerService { get; set; }
        TcpState State { get; set; }
        long ByteArrLength { get; set; }
        bool CreateListener(string ipAddress, string port, Form1 form1);
    }
}
