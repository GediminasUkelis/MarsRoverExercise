using MarsRoverExercise.Application.Models;

namespace MarsRoverExercise.Application.Repositories
{
    public class RoverRepository : IRoverRepository
    {
        public MarsRover GetCurrentRoverState()
        {
            return new MarsRover();
        }
    }
}
