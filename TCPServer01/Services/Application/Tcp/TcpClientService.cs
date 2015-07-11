using System;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using TCPServer01.Interfaces.Application.Form;
using TCPServer01.Interfaces.Application.TCP;
using TcpState = TCPServer01.Enums.Tcp.TcpState;

namespace TCPServer01.Services.Application.Tcp
{
    public class TcpClientService : ITcpClientService
    {
        public TcpClient MtcpClient { get; set; }

        public byte[] Mrx { get; set; }
        public string ResultText { get; set; }

        public TcpState EndAcceptTcpClient(IAsyncResult iar, out string message)
        {
            var result = string.Empty;
            var state = TcpState.NotReady;
            try
            {
                MtcpClient = new TcpClient();

                //must call an end against every begin
                var tcpl = iar.AsyncState as TcpListener;

                if (tcpl != null)
                    MtcpClient = tcpl.EndAcceptTcpClient(iar);

                state = TcpState.Ready;
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            finally
            {
                message = result;
            }
         
            return state;
        }

        public TcpState BeginReadStream(long byteArrLength, out string message, IForm form1)
        {
            var result = string.Empty;
            var state = TcpState.NotReady;

            try
            {
                Mrx = new byte[byteArrLength];

                result = GetTcpStream(form1);

                state = TcpState.Ready;
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            finally
            {
                message = result;
            }
            
            return state;
        }

        private string GetTcpStream(IForm mainForm)
        {
            var result = string.Empty;

            //begin reading the stream from the client into the byte array
            MtcpClient.GetStream().BeginRead(Mrx, 0, Mrx.Length, ar =>
            {
                var countReadBytes = 0;
                try
                {
                    var tcpc = ar.AsyncState as TcpClient;

                    if (tcpc != null)
                    {
                        countReadBytes = tcpc.GetStream().EndRead(ar);
                        if (countReadBytes == 0)
                            throw new NetworkInformationException();
                    }

                    mainForm.SetOutput(Encoding.ASCII.GetString(Mrx, 0, countReadBytes));

                    GetTcpStream(mainForm);
                }
                catch (Exception ex)
                {
                    result = ex.Message;
                }
            }, MtcpClient);

            return result;
        }
    }
}