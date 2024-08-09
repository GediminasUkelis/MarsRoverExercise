using MarsRoverExercise.Application.Enums;

namespace MarsRoverExercise.Application.Models
{
    public class MarsRover
    {
        public int X { get; set; } = 0;

        public int Y { get; set; } = 0;

        public Direction Direction { get; set; } = Direction.North;
    }
}
