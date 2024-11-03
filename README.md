# Rocket Control Game

A Unity-based 3D rocket control game where players navigate a rocket through levels by managing thrust and rotation. The game involves avoiding obstacles and reaching the designated "Finish" zones to progress to the next level.

## Features

- **Rocket Thrust and Rotation**: Players control thrust with the spacebar and rotation with left/right arrow keys (or A/D keys).
- **Collision Detection**: Custom collision handling for interactions with obstacles, friendly objects, and finish zones.
- **Particle Effects and Sound**: Particle and sound effects for thrust, rotation, success, and crash events.
- **Debug Options**: Toggle collision detection and skip levels for easier testing.

## Project Structure

The project contains the following main scripts:

### 1. Movement.cs

Handles all rocket movement and controls:
- **Thrust Control**: Applies upward thrust when the spacebar is pressed, with associated engine sound and particles.
- **Rotation Control**: Rotates the rocket left and right using the arrow keys or A/D keys, displaying directional particles.
- **Debug Options**: 
  - Press `C` to toggle collision detection.
  - Press `L` to skip to the next level.

### 2. CollisionHandler.cs

Manages rocket collision responses:
- **Friendly Objects**: No action on collision.
- **Finish Zone**: Triggers a success sequence, plays a success sound, and advances to the next level after a short delay.
- **Obstacles**: Initiates a crash sequence with failure sound and particles, then respawns the player after a delay.

### 3. Oscillator.cs

Controls environmental object movement:
- Uses a sine wave function to create oscillating movement, adding variety and dynamic obstacles within levels.

## How to Play

1. **Control Thrust**: Press the spacebar to apply thrust and move upward.
2. **Rotate the Rocket**: Use the left and right arrow keys (or A/D keys) to rotate the rocket.
3. **Navigate Levels**: Reach the finish zone without crashing into obstacles to progress to the next level.

4. ## Setup

1. Clone the repository.
2. Open the project in Unity.
3. Play!


