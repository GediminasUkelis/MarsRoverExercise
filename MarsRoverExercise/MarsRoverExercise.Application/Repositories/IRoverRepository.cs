using MarsRoverExercise.Application.Models;

namespace MarsRoverExercise.Application.Repositories
{
    public interface IRoverRepository
    {
        public MarsRover GetCurrentRoverState();
    }
}
