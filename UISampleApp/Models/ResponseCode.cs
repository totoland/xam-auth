using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UISampleApp.Models
{
    public class ResponseCode
    {
        public static readonly string SUCCESS = "200";
        public static readonly string FAIL = "401";
        public static readonly string SERVICE_UNAVAILABLE = "500";
        public static readonly string NOT_FOUND = "404";

        private string respCode;
        private string respDesc;
        private Object data;

        public string RespCode { get => respCode; set => respCode = value; }
        public string RespDesc { get => respDesc; set => respDesc = value; }
        public Object Data { get => data; set => data = value; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
