using System.Net;
using System.Net.Sockets;
using TCPServer01.Enums.Tcp;
using TCPServer01.Interfaces.Application.Tcp;

namespace TCPServer01.Services.Application.Tcp
{
    public class TcpService : ITcpService
    {
        public string Message { get; private set; }

        public TcpListener TcpListener { get; set; }
        
        public TcpServerState State { get; set; }
        
        public bool CreateListener(string ipAddress, string port)
        {
            var result = false;            
            IPAddress ipaddr;
            int nPort;
            Message = string.Empty;

            if(!int.TryParse(port, out nPort))
                Message = "invalid port supplied";

            if (!IPAddress.TryParse(ipAddress, out ipaddr))
                Message += " invalid ip address supplied"; //this is the default if the try parse fails

            //if either of these are not set, return back
            if (nPort == 0 || ipaddr == null) return false;

            //create a listener
            TcpListener = new TcpListener(ipaddr, nPort);

            //call start method for listener
            TcpListener.Start();

            BeginAcceptTcpClient();

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        private void BeginAcceptTcpClient()
        {
            TcpListener.BeginAcceptTcpClient(iar =>
            {
                //cast the iar async state contains reference to original tcp object that called begin accept tcp client
                //cast object to a listener
                var tcpl = iar.AsyncState as TcpListener;

                if (tcpl == null)
                {
                    Message = "there was an issue casting the TCP listener";

                    State = TcpServerState.FailedToStart;
                    return;
                }

                //must call an end against every begin
                tcpl.EndAcceptTcpClient(iar);

            }, TcpListener);
        }
    }
}