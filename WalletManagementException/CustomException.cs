using System;

namespace WalletManagementException
{
    public class CustomException : Exception
    {
        public CustomException(string msg):base(msg)
        {

        }
    }
}
