using System;
using System.Collections.Generic;
using System.Text;

namespace Shield.classes.net
{
    public class BaseSocketEvent : EventArgs
    {
        public String _protocol { get; set; }
        public String _type { get; set; }
        public BaseSocketPacket _data { get; set; }

        public const String SECURITY_ERROR = "securityError";//"securityError"
        public const String IO_ERROR = "ioError";//"ioError"
        public const String RECEIVED = "received";
		public const String SENT = "sent";
        public const String CLOSE = "close";//"close"
        public const String CONNECT = "connect";//"connect"
        public const String RESPONSE_CODE_NO_RESULTS = "response_code_no_results";
        public const String RESPONSE_CODE_RESOLVE_ERROR = "response_code_resolve_error";
        public const String RESPONSE_CODE_NO_RIGHT = "response_code_no_right";
        public const String RESPONSE_CODE_AUTH_CODE_ERROR = "response_code_auth_code_error";
        public const String RESPONSE_CODE_ERROR = "response_code_error";

        public BaseSocketEvent(String type, String protocol = null, BaseSocketPacket data = null)
        {
            this._protocol = protocol;
            this._data = data;
            this._type = type;
        }
}
}
