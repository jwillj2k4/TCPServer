using System;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using TCPServer01.Interfaces.Application.Form;
using TCPServer01.Interfaces.Application.TCP;
using TCPServer01.Interfaces.Models.DTO.Responses.Tcp;
using TCPServer01.Models.DTO.Responses.Tcp;
using TcpState = TCPServer01.Enums.Tcp.TcpState;

namespace TCPServer01.Services.Application.Tcp
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A TCP client service. </summary>
    ///
    /// <remarks>   Justin, 7/11/2015. </remarks>
    ///-------------------------------------------------------------------------------------------------
    public class TcpClientService : ITcpClientService
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the mtcp client. </summary>
        ///
        /// <value> The mtcp client. </value>
        ///-------------------------------------------------------------------------------------------------
        public TcpClient MtcpClient { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the mrx. </summary>
        ///
        /// <value> The mrx. </value>
        ///-------------------------------------------------------------------------------------------------
        public byte[] Mrx { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the result text. </summary>
        ///
        /// <value> The result text. </value>
        ///-------------------------------------------------------------------------------------------------
        public string ResultText { get; set; }

        /// -------------------------------------------------------------------------------------------------
        ///  <summary>   Ends accept TCP client. </summary>
        /// 
        ///  <remarks>   Justin, 7/11/2015. </remarks>
        /// <param name="asyncResult"></param>
        /// <returns>   A TcpState. </returns>
        /// -------------------------------------------------------------------------------------------------
        public ITcpResponse EndAcceptTcpClient(IAsyncResult asyncResult)
        {
            var response = new TcpResponse
            {
                Result = string.Empty,
                State = TcpState.NotReady,
                AsyncResult = asyncResult
            };

            try
            {
                MtcpClient = new TcpClient();

                //must call an end against every begin
                var tcpl = asyncResult.AsyncState as TcpListener;

                if (tcpl == null) return response;

                //asynchronously accepts incoming tcp requests
                MtcpClient = tcpl.EndAcceptTcpClient(asyncResult);

                response.State = TcpState.Ready;
            }
            catch (Exception ex)
            {
                response.Result = ex.Message;
            }

            return response;
        }

        /// -------------------------------------------------------------------------------------------------
        ///  <summary>   Begins read stream. </summary>
        /// 
        ///  <remarks>   Justin, 7/11/2015. </remarks>
        /// <param name="byteArrLength">    Length of the byte array. </param>
        /// <param name="form1">            The first form. </param>
        /// <returns>   A TcpState. </returns>
        /// -------------------------------------------------------------------------------------------------
        public ITcpResponse BeginReadStream(long byteArrLength, IForm form1)
        {
            var response = new TcpResponse
            {
                Result = string.Empty,
                State = TcpState.NotReady
            };

            try
            {
                //create byte array to hold read stream
                Mrx = new byte[byteArrLength];

                //Get the tcp stream, return the result
                response.Result = GetTcpStream(form1);

                response.State = TcpState.Ready;
            }
            catch (Exception ex)
            {
                response.Result = ex.Message;
            }

            return response;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets TCP stream. </summary>
        ///
        /// <remarks>   Justin, 7/11/2015. </remarks>
        ///
        /// <exception cref="NetworkInformationException">  Thrown when a Network Information error
        ///                                                 condition occurs. </exception>
        ///
        /// <param name="mainForm"> The main form. </param>
        ///
        /// <returns>   The TCP stream. </returns>
        ///-------------------------------------------------------------------------------------------------
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
                        //read to end of stream, get a count of the bytes read
                        countReadBytes = tcpc.GetStream().EndRead(ar);

                        if (countReadBytes == 0)
                        {
                            MessageBox.Show(@"Client Disconnected", @"Disconnected", MessageBoxButtons.OK,
                                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.ServiceNotification);
                            return;
                        }
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