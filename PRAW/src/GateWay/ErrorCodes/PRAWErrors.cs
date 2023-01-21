using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAW.ErrorCodes
{
    public enum PRAWErrors
    {
        MaxReconnectThresholdReached = 0x1,
        InvalidSessionCantResume = 0x2,
    }

    public class ConnectionException : Exception
    {
        public ConnectionException(PRAWErrors opCode, string description) : base($"Error Code: {opCode}\n\nDescription:\n{description}") { }
    }
}
