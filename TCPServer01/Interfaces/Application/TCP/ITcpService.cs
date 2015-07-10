using System.Net.Sockets;
using TCPServer01.Enums.Tcp;

namespace TCPServer01.Interfaces.Application.Tcp
{
    public interface ITcpService
    {
        bool CreateListener(string ipAddress, string port);
        TcpListener TcpListener { get; set; }
        string Message { get; }
        TcpServerState State { get; set; }
    }
}
