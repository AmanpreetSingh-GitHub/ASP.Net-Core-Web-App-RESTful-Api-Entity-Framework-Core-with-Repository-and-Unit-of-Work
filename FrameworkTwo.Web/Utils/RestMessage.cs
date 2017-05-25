using System;
using System.Net;

namespace FrameworkTwo.Web.Utils
{
    public class RestMessage<T> where T : class
    {
        public HttpStatusCode StatusCode { get; set; }

        public string StatusText { get; set; }

        public bool Success { get { return StatusCode == HttpStatusCode.OK; } }

        public bool Unauthorized { get { return StatusCode == HttpStatusCode.Unauthorized; } }

        public Exception Exception { get; set; }

        public int Total { get; set; }

        public T Result { get; set; }

        public void SetAsBadRequest()
        {
            StatusCode = HttpStatusCode.BadRequest;
        }

        public void SetAsGoodRequest()
        {
            StatusCode = HttpStatusCode.OK;
        }
    }
}
