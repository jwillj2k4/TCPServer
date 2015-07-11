namespace TCPServer01.Interfaces.Application.TCP
{
    public interface IMtcpMessagingService
    {
        void SendData(long byteArrLength, string text);
    }
}