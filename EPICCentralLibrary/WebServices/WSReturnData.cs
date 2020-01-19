
using System;
using System.Collections;

namespace EPICCentralLibrary.WebServices
{
    public enum WSReturnResultType
    {
        Success,
        Failure,
        NoAuth
    }

    public class GetCurrentMessagesReturnType
    {
        public WSReturnResultType FunctionStatus;
        public ArrayList Messages;
        public Byte[] ExceptionThrown;
    }

    public class IsDeviceAuthorizedReturnType
    {
        public WSReturnResultType FunctionStatus;
        public Boolean IsDeviceAuthorized;
        public Byte[] ExceptionThrown;
    }

    public class DeleteAMessageReturnType
    {
        public WSReturnResultType FunctionStatus;
        public Byte[] ExceptionThrown;
    }

    public class SendExceptionReturnType
    {
        public WSReturnResultType FunctionStatus;
        public Byte[] ExceptionThrown;
    }

    public class SendCurrentStatusReturnType
    {
        public WSReturnResultType FunctionStatus;
        public Byte[] ExceptionThrown;
    }

    public class ScansAvailableReturnType
    {
        public WSReturnResultType FunctionStatus;
        public Int32 NumberOfScansAvailable;
        public Byte[] ExceptionThrown;
    }

    public class DecrementScansReturnType
    {
        public WSReturnResultType FunctionStatus;
        public Byte[] ExceptionThrown;
    }

    public class GetWSAccessTokenReturnType
    {
        public WSReturnResultType FunctionStatus;
        public string WSAccessToken;
        public Byte[] ExceptionThrown;
    }
}
