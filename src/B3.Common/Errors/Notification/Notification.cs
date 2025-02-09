using System.Net;

namespace B3.Common.Errors
{
    public class Notification
    {
        public string Message { get; set; }
        public HttpStatusCode ErroCode { get; set; }

        public Notification(string message, HttpStatusCode erroCode = HttpStatusCode.BadRequest)
        {
            Message = message;
            ErroCode = erroCode;
        }
    }
}
