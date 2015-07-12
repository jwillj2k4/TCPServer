using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using TCPServer01.Enums.Tcp;
using TCPServer01.Interfaces.Application.Form;
using TCPServer01.Interfaces.Application.Tcp;
using TCPServer01.Services.Application.Tcp.Messaging;

namespace TCPServer01.Services.Application.Tcp
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A TCP service. </summary>
    ///
    /// <remarks>   Justin, 7/11/2015. </remarks>
    ///-------------------------------------------------------------------------------------------------
    public class TcpService : ITcpService
    {

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   tcp server role. </summary>
        ///
        /// <value> The m TCP listener service. </value>
        ///-------------------------------------------------------------------------------------------------
        private ITcpListenerService _mTcpListenerService;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the message. </summary>
        ///
        /// <value> The message. </value>
        ///-------------------------------------------------------------------------------------------------
        public string Message { get; private set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the state. </summary>
        ///
        /// <value> The state. </value>
        ///-------------------------------------------------------------------------------------------------
        public TcpState State { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the length of the byte array. </summary>
        ///
        /// <value> The length of the byte array. </value>
        ///-------------------------------------------------------------------------------------------------
        public long ByteArrLength { get; set; }

        /// -------------------------------------------------------------------------------------------------
        ///  <summary>   Constructor. </summary>
        /// 
        ///  <remarks>   Justin, 7/11/2015. </remarks>
        /// 
        ///  <param name="byteArrLength">        The length of the byte array. </param>
        /// -------------------------------------------------------------------------------------------------
        public TcpService(long byteArrLength)
        {
            ByteArrLength = byteArrLength;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Creates a listener. </summary>
        ///
        /// <remarks>   Justin, 7/11/2015. </remarks>
        ///
        /// <param name="ipAddress">    The IP address. </param>
        /// <param name="port">         The port. </param>
        /// <param name="form1">        The first form. </param>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>
        ///-------------------------------------------------------------------------------------------------
        public bool CreateTcpListenerandClient(string ipAddress, string port, IForm form1)
        {
            IPAddress ipaddr;

            int nPort;

            Message = string.Empty;

            if (!int.TryParse(port, out nPort))
                Message = "invalid port supplied";

            if (!IPAddress.TryParse(ipAddress, out ipaddr))
                Message += " invalid ip address supplied"; //this is the default if the try parse fails

            //if either of these are not set, return back
            if (nPort == 0 || ipaddr == null) return false;

            //create new instance of listener service
            _mTcpListenerService = new TcpListenerService(ipaddr, nPort);

            //call start listening
            _mTcpListenerService.StartListening();

            var response = _mTcpListenerService.BeginAcceptTcpClient(ByteArrLength, form1);

            Message = response.Result;

            return true;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Sends a data. </summary>
        ///
        /// <remarks>   Justin, 7/11/2015. </remarks>
        ///
        /// <param name="text"> The text. </param>
        ///-------------------------------------------------------------------------------------------------
        public void SendDataToClient(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            //send payload to server
            new MTcpMessagingService(_mTcpListenerService.MTcpClientService).SendToServer(ByteArrLength, text);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Searches for the IPv4 addrss of this machine. </summary>
        ///
        /// <remarks>   Justin, 7/11/2015. </remarks>
        ///
        /// <returns>   The found my IPv4 addrss. </returns>
        ///-------------------------------------------------------------------------------------------------
        public IPAddress FindMyIpv4Addrss()
        {
            //used to get the host entry info for this pc from the dns server of my network
            IPAddress result = null;

            try
            {
                //get local host name computer
                var hostName = Dns.GetHostName();

                var dnsEntry = Dns.GetHostEntry(hostName);

                //includes ipv4 and ipv6 addresses
                var allIps = dnsEntry.AddressList.ToList();

                //get the Ipv4 address
                result = allIps.FirstOrDefault(z => z.AddressFamily.Equals(AddressFamily.InterNetwork));

            }
            catch (Exception ex)
            {
                TcpMessageService.ShowMessage(string.Format("There was a problem: {0}", ex.Message));
            }

            return result;
        }
    }
}