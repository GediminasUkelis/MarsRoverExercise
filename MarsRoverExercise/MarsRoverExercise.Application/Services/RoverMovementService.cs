using MarsRoverExercise.Application.Enums;
using MarsRoverExercise.Application.Exceptions;
using MarsRoverExercise.Application.Models;
using MarsRoverExercise.Application.Repositories;
using Microsoft.Extensions.Options;
using System.Net;

namespace MarsRoverExercise.Application.Services
{
    public class RoverMovementService : IRoverMovementService
    {
        private readonly IRoverRepository _roverRepository;
        private readonly MarsRover _marsRover;
        private readonly MapSize _mapSize;

        public RoverMovementService(IOptions<MapSize> mapSize, IRoverRepository roverRepository)
        {
            _roverRepository = roverRepository;

            _mapSize = mapSize.Value;
            _marsRover = GetCurrentRoverState();
        }

        public MarsRover ProcessMoves(List<Command> moves)
        {
            foreach (var move in moves) {
                Move(move);
            }

            return _marsRover;
        }

        private void Move(Command move)
        {
            switch (move)
            {
                case Command.L:
                    TurnLeft();
                    break;

                case Command.R:
                    TurnRight();
                    break;

                case Command.F:
                    Move(true);
                    break;

                case Command.B:
                    Move(false);
                    break;
            }
        }

        private void Move(bool forward)
        {
            int deltaX = 0;
            int deltaY = 0;

            switch (_marsRover.Direction)
            {
                case Direction.North:
                    deltaY = forward ? 1 : -1;
                    break;
                case Direction.East:
                    deltaX = forward ? 1 : -1;
                    break;
                case Direction.South:
                    deltaY = forward ? -1 : 1;
                    break;
                case Direction.West:
                    deltaX = forward ? -1 : 1;
                    break;
            }

            int newX = _marsRover.X + deltaX;
            int newY = _marsRover.Y + deltaY;

            if (newX >= 0 && newX <= _mapSize.X && newY >= 0 && newY <= _mapSize.Y)
            {
                _marsRover.X = newX;
                _marsRover.Y = newY;
            }
            else
            {
                throw new InvalidMoveException(
                    HttpStatusCode.BadRequest,
                    $"You are trying to move out of map. Rover possition: {_marsRover.X}, {_marsRover.Y}, {_marsRover.Direction}, you just tried to move to: {newX}, {newY}.");
            }
        }

        private void TurnLeft()
        {
            _marsRover.Direction = _marsRover.Direction == Direction.North ? Direction.West : _marsRover.Direction - 1;
        }

        private void TurnRight()
        {
            _marsRover.Direction = _marsRover.Direction == Direction.West ? Direction.North : _marsRover.Direction + 1;
        }

        public MarsRover GetCurrentRoverState()
        {
            return _marsRover ?? _roverRepository.GetCurrentRoverState();
        }
    }
}