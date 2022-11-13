using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attendance.Management.Common
{
    public class ApiResponse
    {
        public int StatusCode { get; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; }
        public object Response { get;  }

        public ApiResponse(int statusCode, string message = null, object response = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
            Response = response;
        }

        private static string GetDefaultMessageForStatusCode(int statusCode)
        {
            switch (statusCode)
            {
                case 200:
                    return "Succuess in fetching data";
                case 404:
                    return "Resource not found";
                case 500:
                    return "An unhandled error occurred";
                case 401:
                    return "You are not authorized for this request";
                default:
                    return null;
            }
        }
    }
}
