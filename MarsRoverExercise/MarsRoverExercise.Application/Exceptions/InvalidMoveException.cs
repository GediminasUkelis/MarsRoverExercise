using System.Net;

namespace MarsRoverExercise.Application.Exceptions
{
    public class InvalidMoveException : Exception
    {
        public HttpStatusCode Code { get; set; }

        public string Error { get; set; }

        public InvalidMoveException(HttpStatusCode code, string error) : base(error)
        {
            this.Code = code;
            this.Error = error;
        }
    }
}
