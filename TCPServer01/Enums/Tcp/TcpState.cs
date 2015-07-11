namespace TCPServer01.Enums.Tcp
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Values that represent TCP states. </summary>
    ///
    /// <remarks>   Justin, 7/11/2015. </remarks>
    ///-------------------------------------------------------------------------------------------------
    public enum TcpState
    {
        /// <summary>   An enum constant representing the none option. </summary>
        None,
        /// <summary>   An enum constant representing the started option. </summary>
        Started,
        /// <summary>   An enum constant representing the failed to start option. </summary>
        Failed,
        /// <summary>   An enum constant representing the ready option. </summary>
        Ready,
        /// <summary>   An enum constant representing the not ready option. </summary>
        NotReady,
        /// <summary>   An enum constant representing the success option. </summary>
        Success
    }
}