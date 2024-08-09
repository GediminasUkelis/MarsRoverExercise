using System.Net;

namespace MarsRoverExercise.API.Infrastructure.Exceptions
{
    public class InputValidationException : Exception
    {
        public HttpStatusCode Code { get; set; }

        public string Error { get; set; }

        public InputValidationException(HttpStatusCode code, string error) : base (error)
        {
            this.Code = code;
            this.Error = error;
        }
    }
}
