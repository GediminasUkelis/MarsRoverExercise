using MarsRoverExercise.Application.Enums;
using MarsRoverExercise.Application.Models;

namespace MarsRoverExercise.Application.Services
{
    public interface IRoverMovementService
    {
        public MarsRover ProcessMoves(List<Command> moves);

        public MarsRover GetCurrentRoverState();
    }
}
