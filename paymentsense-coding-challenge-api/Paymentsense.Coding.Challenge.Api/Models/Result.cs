namespace Paymentsense.Coding.Challenge.Api.Models
{
    public class Result<T>
        where T : class
    {
        public bool Success => Error == null;

        public ErrorResponse Error { get; set; }
       
        public virtual T Response { get; set; }
    }
}
