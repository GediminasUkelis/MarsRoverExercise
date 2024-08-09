using FluentAssertions;
using MarsRoverExercise.Application.Enums;
using MarsRoverExercise.Application.Models;
using MarsRoverExercise.Application.Repositories;
using MarsRoverExercise.Application.Services;
using Microsoft.Extensions.Options;
using Moq;

namespace MarsRoverExercise.ApplicationTests.Services
{
    public class RoverMovementServiceTests
    {
        private readonly Mock<IOptions<MapSize>> _mapSizeMock;
        private readonly Mock<IRoverRepository> _roverRepositoryMock;


        public RoverMovementServiceTests()
        {
            var rover = new MarsRover()
            {
                X = 1,
                Y = 1,
                Direction = Direction.North,
            };

            _roverRepositoryMock = new Mock<IRoverRepository>();
            _roverRepositoryMock.Setup(x => x.GetCurrentRoverState()).Returns(rover);

            var mapSize = new MapSize() { X = 3, Y = 3 };

            var optionsMock = new Mock<IOptions<MapSize>>();
            optionsMock.Setup(x => x.Value).Returns(mapSize);
    
            _mapSizeMock = optionsMock;
        }

        [Fact]
        public void ProcessMoves_WithSequenceOfMoves_UpdatesPositionAndDirectionCorrectly()
        {
            var moves = new List<Command> {
                Command.F,
                Command.F,
                Command.R,
                Command.F,
                Command.F
            };

            var roverRepositoryMock = new Mock<IRoverRepository>();
            roverRepositoryMock.Setup(x => x.GetCurrentRoverState()).Returns(new MarsRover());

            var roverMovementService = new RoverMovementService(_mapSizeMock.Object, roverRepositoryMock.Object);

            var marsRover = roverMovementService.ProcessMoves(moves);

            marsRover.X.Should().Be(2);
            marsRover.Y.Should().Be(2);
            marsRover.Direction.Should().Be(Direction.East);
        }

        [Fact]
        public void ProcessMoves_WithSequenceOfMovesLF_UpdatesPositionAndDirectionCorrectly()
        {
            var moves = new List<Command> {
                Command.L,
                Command.F
            };

            var roverMovementService = new RoverMovementService(_mapSizeMock.Object, _roverRepositoryMock.Object);

            var marsRover = roverMovementService.ProcessMoves(moves);

            marsRover.X.Should().Be(0);
            marsRover.Y.Should().Be(1);
            marsRover.Direction.Should().Be(Direction.West);
        }

        [Fact]
        public void ProcessMoves_WithSequenceOfMovesRF_UpdatesPositionAndDirectionCorrectly()
        {
            var moves = new List<Command> {
                Command.R,
                Command.F
            };

            var roverMovementService = new RoverMovementService(_mapSizeMock.Object, _roverRepositoryMock.Object);

            var marsRover = roverMovementService.ProcessMoves(moves);

            marsRover.X.Should().Be(2);
            marsRover.Y.Should().Be(1);
            marsRover.Direction.Should().Be(Direction.East);
        }

        [Fact]
        public void ProcessMoves_WithSequenceOfMovesLB_UpdatesPositionAndDirectionCorrectly()
        {
            var moves = new List<Command> {
                Command.L,
                Command.B
            };

            var roverMovementService = new RoverMovementService(_mapSizeMock.Object, _roverRepositoryMock.Object);

            var marsRover = roverMovementService.ProcessMoves(moves);

            marsRover.X.Should().Be(2);
            marsRover.Y.Should().Be(1);
            marsRover.Direction.Should().Be(Direction.West);
        }

        [Fact]
        public void ProcessMoves_WithSequenceOfMovesRB_UpdatesPositionAndDirectionCorrectly()
        {
            var moves = new List<Command> {
                Command.R,
                Command.B
            };

            var roverMovementService = new RoverMovementService(_mapSizeMock.Object, _roverRepositoryMock.Object);

            var marsRover = roverMovementService.ProcessMoves(moves);

            marsRover.X.Should().Be(0);
            marsRover.Y.Should().Be(1);
            marsRover.Direction.Should().Be(Direction.East);
        }

        [Fact]
        public void ProcessMoves_WithSequenceOfMovesR_UpdatesPositionAndDirectionCorrectly()
        {
            var moves = new List<Command> {
                Command.R
            };

            var roverMovementService = new RoverMovementService(_mapSizeMock.Object, _roverRepositoryMock.Object);

            var marsRover = roverMovementService.ProcessMoves(moves);

            marsRover.X.Should().Be(1);
            marsRover.Y.Should().Be(1);
            marsRover.Direction.Should().Be(Direction.East);
        }

        [Fact]
        public void ProcessMoves_WithSequenceOfMovesRR_UpdatesPositionAndDirectionCorrectly()
        {
            var moves = new List<Command> {
                Command.R,
                Command.R
            };

            var roverMovementService = new RoverMovementService(_mapSizeMock.Object, _roverRepositoryMock.Object);

            var marsRover = roverMovementService.ProcessMoves(moves);

            marsRover.X.Should().Be(1);
            marsRover.Y.Should().Be(1);
            marsRover.Direction.Should().Be(Direction.South);
        }

        [Fact]
        public void ProcessMoves_WithSequenceOfMovesRRR_UpdatesPositionAndDirectionCorrectly()
        {
            var moves = new List<Command> {
                Command.R,
                Command.R,
                Command.R
            };

            var roverMovementService = new RoverMovementService(_mapSizeMock.Object, _roverRepositoryMock.Object);

            var marsRover = roverMovementService.ProcessMoves(moves);

            marsRover.X.Should().Be(1);
            marsRover.Y.Should().Be(1);
            marsRover.Direction.Should().Be(Direction.West);
        }

        [Fact]
        public void ProcessMoves_WithSequenceOfMovesRRRR_UpdatesPositionAndDirectionCorrectly()
        {
            var moves = new List<Command> {
                Command.R,
                Command.R,
                Command.R,
                Command.R,
            };

            var roverMovementService = new RoverMovementService(_mapSizeMock.Object, _roverRepositoryMock.Object);

            var marsRover = roverMovementService.ProcessMoves(moves);

            marsRover.X.Should().Be(1);
            marsRover.Y.Should().Be(1);
            marsRover.Direction.Should().Be(Direction.North);
        }

        [Fact]
        public void ProcessMoves_WithSequenceOfMovesL_UpdatesPositionAndDirectionCorrectly()
        {
            var moves = new List<Command> {
                Command.L
            };

            var roverMovementService = new RoverMovementService(_mapSizeMock.Object, _roverRepositoryMock.Object);

            var marsRover = roverMovementService.ProcessMoves(moves);

            marsRover.X.Should().Be(1);
            marsRover.Y.Should().Be(1);
            marsRover.Direction.Should().Be(Direction.West);
        }

        [Fact]
        public void ProcessMoves_WithSequenceOfMovesLL_UpdatesPositionAndDirectionCorrectly()
        {
            var moves = new List<Command> {
                Command.L,
                Command.L
            };

            var roverMovementService = new RoverMovementService(_mapSizeMock.Object, _roverRepositoryMock.Object);

            var marsRover = roverMovementService.ProcessMoves(moves);

            marsRover.X.Should().Be(1);
            marsRover.Y.Should().Be(1);
            marsRover.Direction.Should().Be(Direction.South);
        }

        [Fact]
        public void ProcessMoves_WithSequenceOfMovesLLL_UpdatesPositionAndDirectionCorrectly()
        {
            var moves = new List<Command> {
                Command.L,
                Command.L,
                Command.L
            };

            var roverMovementService = new RoverMovementService(_mapSizeMock.Object, _roverRepositoryMock.Object);

            var marsRover = roverMovementService.ProcessMoves(moves);

            marsRover.X.Should().Be(1);
            marsRover.Y.Should().Be(1);
            marsRover.Direction.Should().Be(Direction.East);
        }

        [Fact]
        public void ProcessMoves_WithSequenceOfMovesLLLL_UpdatesPositionAndDirectionCorrectly()
        {
            var moves = new List<Command> {
                Command.L,
                Command.L,
                Command.L,
                Command.L,
            };

            var roverMovementService = new RoverMovementService(_mapSizeMock.Object, _roverRepositoryMock.Object);

            var marsRover = roverMovementService.ProcessMoves(moves);

            marsRover.X.Should().Be(1);
            marsRover.Y.Should().Be(1);
            marsRover.Direction.Should().Be(Direction.North);
        }
    }
}
