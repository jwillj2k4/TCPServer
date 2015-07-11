using System;
using TCPServer01.Enums.Tcp;

namespace TCPServer01.Interfaces.Models.DTO.Responses.Tcp
{
    public class TcpMessageResponse : ITcpMessageResponse
    {
        public string Result { get; set; }
        public TcpState State { get; set; }
        public IAsyncResult AsyncResult { get; set; }
    }
}