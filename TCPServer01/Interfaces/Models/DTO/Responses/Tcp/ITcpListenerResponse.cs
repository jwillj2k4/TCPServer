using System.Net.Sockets;

namespace TCPServer01.Interfaces.Models.DTO.Responses.Tcp
{
    public interface ITcpListenerResponse : ITcpResponse
    {
        TcpListener Listener { get; set; }
    }
}