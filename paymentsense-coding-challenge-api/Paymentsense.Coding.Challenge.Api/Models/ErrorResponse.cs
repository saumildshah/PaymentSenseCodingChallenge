using System.Net;

namespace Paymentsense.Coding.Challenge.Api.Models
{
    public class ErrorResponse
    {
        public HttpStatusCode Status { get; set; }
        public string Message { get; set; }
    }
}
