# Chess

A **3D chess game prototype** developed with **Unity and C#**, focused on implementing an interactive chessboard, 3D chess pieces, piece selection and movement, and visual feedback for player interaction.

## Overview

Chess is a Unity project that experiments with representing a traditional chessboard as an interactive 3D environment. The scene contains separate white and black piece collections, a 3D board, interaction effects, and gameplay scripts responsible for managing the board and pieces.

The main scene is configured with references to the chessboard and **16 white and 16 black pieces**, indicating that the project models a complete initial set of chess pieces in the scene. fileciteturn50file0

## Gameplay and Interaction

The project is structured around an interactive board controller. The main scene contains references for mouse interaction, piece capture, movement effects, the board, both sets of pieces, and a move counter. fileciteturn49file0

The scene also contains dedicated 3D models for the chess pieces and board. The repository includes FBX assets for the **bishop, knight, pawn, king, queen, rook, and board**, together with materials for the pieces and visual effects. fileciteturn27file0

This organization separates the visual representation of the chess set from the gameplay logic, allowing the Unity scene and C# scripts to control the interactive behavior of the pieces.

## Visual Presentation

The project uses custom 3D assets rather than relying exclusively on Unity primitives. The chess pieces and board are stored as FBX assets, while dedicated materials are used for the different piece variants and interaction effects. fileciteturn27file0

The scene is configured with baked lighting support and Unity's standard scene lighting systems, providing the foundation for presenting the chessboard as a 3D environment. fileciteturn49file0

## Technologies

- **Unity 2020.3.17f1** — game engine and scene management
- **C#** — gameplay and interaction programming
- **Unity Physics** — interaction and object behavior
- **Unity UI (uGUI)** — available project UI framework
- **TextMeshPro** — available text rendering system
- **Timeline** — available Unity timeline system
- **Universal Render Pipeline (URP)** — configured render pipeline
- **FBX 3D assets** — chess pieces and board
- **Unity Materials** — visual appearance and interaction effects

The project explicitly uses Unity **2020.3.17f1**. fileciteturn48file0 Its package configuration includes URP 10.6.0, TextMeshPro 3.0.6, Timeline 1.5.6, Unity Test Framework 1.1.27, and uGUI 1.0.0. fileciteturn47file0

## Project Structure

```text
Chess/
├── Assets/
│   ├── FBX/             # 3D chess pieces and board
│   ├── Materials/       # Piece and environment materials
│   ├── Scenes/          # Unity scenes
│   └── ...              # Scripts, prefabs and other assets
├── BlenderModel/        # 3D modeling resources
├── Packages/            # Unity package configuration
├── ProjectSettings/     # Unity project configuration
└── README.md
```

## Development Focus

The project demonstrates practical Unity development concepts including:

- 3D scene composition
- Object references through Unity components
- Interactive game objects
- Chess piece organization
- Mouse-based interaction
- Movement and capture feedback
- 3D asset integration
- Materials and visual effects
- C# scripting for gameplay logic

## Status

Personal game-development prototype. The repository documents an experimental implementation of a 3D chess experience and may not contain every rule and feature required for a complete production chess game.

## Author

**Pietro Rodrigues**

[GitHub](https://github.com/PietroRodrigues)