# Alone Tourist - Console RPG

This repository contains the source code and documentation for the **Alone Tourist** console game. The project was designed and implemented as the final coursework for the **Designing and Creating High-Level Object-Oriented Applications** course at AGH University of Krakow.

## Project Description

The primary objective of this project is to demonstrate the practical application of Object-Oriented Programming (OOP) principles, including encapsulation, inheritance, polymorphism, and design patterns (such as Factory Method). The application is a simulation-based RPG where the user plays as a tourist navigating a procedurally generated city.

The codebase covers:
* **Simulation Logic:** Management of time, player resources (money, hunger, thirst), and spatial navigation.
* **Procedural Generation:** Random generation of city maps and attraction placements upon each new game using `CityMap` and `AttractionFactory`.
* **Polymorphism & Abstraction:** A unified interface (`IAttraction`) for diverse city attractions (Museums, Parks, Shops) allowing for extensible interactions.
* **Game Loop:** A custom `GameEngine` handling the state machine and user input processing.

## Repository Structure

The repository is organized to separate the source code from project documentation:

* **`src/AloneTourist/`**: Contains the main application source code implemented in C#.
    * **Core Engine:** `GameEngine.cs`, `Program.cs`, `TimeManager.cs` - Responsible for the main game loop, time flow, and application entry point.
    * **World & Navigation:** `CityMap.cs`, `Position.cs`, `Direction.cs` - Handles the grid-based map logic and movement mechanics.
    * **Player & State:** `Tourist.cs`, `Inventory.cs` - Manages player statistics, needs (hunger, budget), and collected items.
    * **Attraction System:** `BaseAttraction.cs`, `IAttraction.cs`, `AttractionFactory.cs` - Implements the hierarchy of interactive locations using the Factory pattern.
    * **Locations:** Specific implementations of attractions including `Museum.cs`, `Hotel.cs`, `Restaurant.cs`, `Park.cs`, `Beach.cs`, `Castle.cs`, and `SouvenirShop.cs`.
    * **Items:** `Souvenir.cs`, `Photo.cs` - Classes representing collectible objects within the game.

* **`docs/`**: Project documentation and design artifacts.
    * `AloneTourist_UML.png`: Visual representation of class relationships and architecture.
    * `Filip_Zurek_Plan_projektu.pdf`: Initial project plan and requirements analysis.
    * `Zadanie projektowe.pdf`: Course assignment details.

## Dependencies

The project is built on the .NET platform and utilizes standard libraries:

* **Target Framework:** .NET 8.0.
* **System.Collections:** Used for managing inventories and map objects.
* **System.IO:** File handling.

## Usage Instructions

To run the game on your local machine, follow these steps:

1. Clone the repository
    ```bash
    git clone https://github.com/BeneNat/alone-tourist-console
    cd alone-tourist-console
    ```

2. Build the Project Ensure you have the .NET 8.0 SDK installed. Run the following command in the root directory:

    ```bash
    dotnet build
    ```

3. Run the Game Execute the application directly from the terminal:

    ```bash
    dotnet run --project src/AloneTourist
    ```

## Author and Context

* **Author:** Filip Żurek
* **Institution:** AGH University of Krakow
* **Faculty:** Faculty of Computer Science, Electronics and Telecommunications
* **Field of Study:** Electronics and Telecommunications
* **Course:** Designing and Creating High-Level Object-Oriented Applications

## License
This software is distributed under the MIT License. Refer to the [LICENSE](LICENSE) file for the full text.

---
AGH University of Krakow - Designing and Creating High-Level Object-Oriented Applications Project 2025