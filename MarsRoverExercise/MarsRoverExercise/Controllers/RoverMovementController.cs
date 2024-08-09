using MarsRoverExercise.API.Infrastructure.Validations;
using MarsRoverExercise.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarsRoverExercise.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoverMovementController : ControllerBase
    {
        private readonly InputValidator inputValidator;
        private readonly IRoverMovementService roverMovementService;

        public RoverMovementController(IRoverMovementService roverMovementService, InputValidator inputValidator)
        {
            this.roverMovementService = roverMovementService;
            this.inputValidator = inputValidator;
        }

        [HttpPost]
        public ActionResult Move([FromBody]string moves)
        {
            var validMoves = inputValidator.Validate(moves);

            var rover = this.roverMovementService.ProcessMoves(validMoves);

            return Ok(rover);
        }
    }
}
