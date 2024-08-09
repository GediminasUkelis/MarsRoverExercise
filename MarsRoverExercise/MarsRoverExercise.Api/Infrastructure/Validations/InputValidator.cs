using MarsRoverExercise.API.Infrastructure.Exceptions;
using MarsRoverExercise.Application.Enums;
using System.Net;

namespace MarsRoverExercise.API.Infrastructure.Validations
{
    public class InputValidator
    {
        public List<Command> Validate(string input)
        {
            List<Command> validMoves = new();
            foreach (char move in input.ToUpper())
            {
                switch (move)
                {
                    case 'L':
                    case 'R':
                    case 'F':
                    case 'B':
                        validMoves.Add(Enum.Parse<Command>(move.ToString()));
                        break;

                    default:
                        throw new InputValidationException(HttpStatusCode.BadRequest, $"Provided input should only contain commands: L,R,F or B. Input contains '{move}'");
                }
            }

            return validMoves;
        }
    }
}
