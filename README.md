# Jupiter Rover API Documentation

## Overview

The Jupiter Rover API is designed to control the movement of a rover on Jupiter's surface. The planet is represented as a grid, and the rover's position and direction are defined by x, y coordinates and a cardinal direction (N, E, S, W). The API allows the rover to move forward or backward on the grid and turn left or right, based on commands provided by NASA.

## Features

- Grid-Based Movement: The rover navigates on a grid, with each movement altering its x or y coordinates.
- Directional Control: The rover can face one of four cardinal directions—North, East, South, or West.
- Movement Commands:
  - F: Move forward one grid space in the current direction.
  - B: Move backward one grid space in the current direction.
  - L: Turn 90 degrees left (without changing position).
  - R: Turn 90 degrees right (without changing position).
 - Input Validation: Ensures commands are valid and within the grid boundaries.
 - Error Handling: Custom exceptions and error responses for invalid movements or input.

## Layered Architecture

The Jupiter Rover API is organized into two main layers: the API Layer and the Application Layer. Each layer serves a distinct purpose and interacts with other layers through interfaces.

## API Layer
Responsibility: The API layer handles HTTP requests, routes them to the appropriate controllers, and returns HTTP responses. It is the entry point of the application and exposes endpoints that NASA can use to send movement commands to the rover.

## Application Layer

Responsibility: The application layer contains the business logic of the rover's movement. It is responsible for processing commands, updating the rover's state, and ensuring the rover's movements are within the grid boundaries. The application layer communicates with the data access layer (repositories, in this case stored in Application layer as well, just to keep it simple. In cases where we have a need for a database an additional Persistance layer would be created) to persist and retrieve data.

## Testing
The Jupiter Rover API includes a comprehensive test project specifically designed to validate the rover's movements and ensure the correctness of the business logic. The test project plays a crucial role in ensuring that the rover behaves as expected under various scenarios.

 
