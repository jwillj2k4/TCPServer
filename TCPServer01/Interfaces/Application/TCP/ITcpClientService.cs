using System;
using TCPServer01.Enums.Tcp;

namespace TCPServer01.Services.Application.Tcp
{
    public interface ITcpClientService
    {
        TcpState EndAcceptTcpClient(IAsyncResult iar, out string message);
        TcpState BeginReadStream(long byteArrLength, out string message, Form1 form1);
        string ResultText { get; set; }
    }
}