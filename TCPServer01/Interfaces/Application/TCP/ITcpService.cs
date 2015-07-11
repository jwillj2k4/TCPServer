using TCPServer01.Enums.Tcp;
using TCPServer01.Interfaces.Application.Form;
using TCPServer01.Interfaces.Application.TCP;

namespace TCPServer01.Interfaces.Application.Tcp
{
    public interface ITcpService
    {
        string Message { get; }
        ITcpListenerService MTcpListenerService { get; set; }
        TcpState State { get; set; }
        long ByteArrLength { get; set; }
        bool CreateListener(string ipAddress, string port, IForm form1);
    }
}
