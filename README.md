# Hb Mars Rover Case Study Task
A squad of robotic rovers are to be landed by NASA on a plateau on Mars. This plateau, which is curiously rectangular, must be navigated by the rovers so that their on-board cameras can get a complete view of the surrounding terrain to send back to Earth.

A rover’s position and location is represented by a combination of x and y co-ordinates and a letter representing one of the four cardinal compass points. The plateau is divided up into a grid to simplify navigation. An example position might be 0, 0, N, which means the rover is in the bottom left corner and facing North.

In order to control a rover, NASA sends a simple string of letters. The possible letters are ‘L’, ‘R’ and ‘M’. ‘L’ and ‘R’ makes the rover spin 90 degrees left or right respectively, without moving from its current spot. ‘M’ means move forward one grid point, and maintain the same heading.

Assume that the square directly North from (x, y) is (x, y+1).

Input: The first line of input is the upper-right coordinates of the plateau, the lower-left coordinates are assumed to be 0,0.

The rest of the input is information pertaining to the rovers that have been deployed. Each rover has two lines of input. The first line gives the rover’s position, and the second line is a series of instructions telling the rover how to explore the plateau.

The position is made up of two integers and a letter separated by spaces, corresponding to the x and y co-ordinates and the rover’s orientation.

Each rover will be finished sequentially, which means that the second rover won’t start to move until the first one has finished moving.

Output: The output for each rover should be its final co-ordinates and heading.

Input and Output

Test Input:
 - 5 5
 - 1 2 N
 - LMLMLMLMM
 - 3 3 E
 - MMRMMRMRRM
 
Expected Output:
 - 1 3 N
 - 5 1 E

# Project Structure 
```
├── HbRoboticCase                   # Code base
├── HbRoboticCase.Test              # Test suit
└── README.md
```

### Development
HbRoboticCase uses a number of design patterns and platforms as follows:

* [C# / .Net Core] - An object-oriented programming language from Microsoft that aims to combine the computing power of C++ with the programming ease of Visual Basic
* [Ninject] - Dependency Injection framework. 
* [Command Pattern] - Behavioral design pattern in which an object is used to encapsulate all information needed to perform an action or trigger an event at a later time.
* [IoC] - the control of objects or portions of a program is transferred to a container or framework
* [Fluent Assertion] - asserting the results of unit tests that targets
* [Xunit] - free, open source, community-focused unit testing tool for the .NET Framework

### Installation

HbRoboticCase requires .Net Core SDK 2.*

Install .Net Core Sdk - https://dotnet.microsoft.com/download/dotnet-core/2.0

1. Go to HbRoboticCase folder or in run this command `cd HbRoboticCase/`  in your cli
 2. Run this command in your cli `dotnet build` for project dependencies
 3. Run the project in your `dotnet run`

### Test
1. Go to HbRoboticCase folder or in run this command `cd HbRoboticCase/`  in your cli
 2. Run this command in your cli `dotnet build` for project dependencies
 3. Run the project in your `dotnet run`


