using System;
using TCPServer01.Enums.Tcp;
using TCPServer01.Interfaces.Application.Form;

namespace TCPServer01.Interfaces.Application.TCP
{
    public interface ITcpClientService
    {
        TcpState EndAcceptTcpClient(IAsyncResult iar, out string message);
        TcpState BeginReadStream(long byteArrLength, out string message, IForm form1);
        string ResultText { get; set; }
    }
}