using FluentAssertions;
using HbRoboticCase.Commands;
using Xunit;
using System;
using HbRoboticCase.Exceptions;
using HbRoboticCase.Models;
using HbRoboticCase.Enums;
using HbRoboticCase.Core.Services;

namespace HbRoboticCase.Tests
{
    public class RoverTests
    {
        [Fact]
        public void Should_CommandMatcher_Throw_InvalidCommandStringException()
        { 
            //Arrange
            var commandMatcher = new CommandMatcher(); 

            //Act
            Action action = () =>
            {
                var response = commandMatcher.GetCommandType("5 5xxxxxxx");
            };

            //Assert
            action.Should().Throw<InvalidCommandStringException>();   
        }

        [Fact]
        public void Should_CommandMatcher_Return_Expected_CommandType()
        {
            var commandMatcher = new CommandMatcher();

            var areaCommandType = commandMatcher.GetCommandType("5 5");
            areaCommandType.Should().BeEquivalentTo(CommandType.AreaCommand);

            var moveCommandType = commandMatcher.GetCommandType("LMLMLMLMMM");
            moveCommandType.Should().BeEquivalentTo(CommandType.MoveCommand);
        }

        [Fact]
        public void Should_Move_Return_Expected_Position()
        {
            char[] moves = new char[] { 'L', 'M', 'L', 'M', 'L', 'M', 'L', 'M', 'M' };
            Position position = new Position()
            {
                X = 1,
                Y = 2,
                Direction = Direction.N
            };
            Size size = new Size(5,5); 
            var area = new Area();

            area.SetSize(size);
        
            var result = new Position()
            {
                X = 1,
                Y = 3,
                Direction = Direction.N
                
            };
           
          var rover = new Rover(position);

          var response = rover.Move(moves, area);

          response.Should().BeEquivalentTo(result);
          
        }


        [Fact]
        public void Should_Move_Return_Unexcepted_Position()
        {
            char[] moves = new char[] { 'L', 'M', 'L', 'M', 'L', 'M', 'L', 'M', 'M' };

            Position position = new Position()
            {
                X = 1,
                Y = 2,
                Direction = Direction.N
            };
            Size size = new Size(5, 5);

            var area = new Area(); 
            area.SetSize(size); 

            var result = new Position()
            {
                X = 2,
                Y = 3,
                Direction = Direction.N

            };

            var rover = new Rover(position);

            var response = rover.Move(moves, area);

            response.Should().NotBe(result);

        }


        [Fact]
        public void Should_SetPositon_Expected_Position()
        {

            Position position = new Position()
            {
                X = 10,
                Y = 2,
                Direction = Direction.N
            };
            
            Size size = new Size(5, 5);

            var area = new Area(); 
            area.SetSize(size);

            var rover = new Rover(position);

            Action action = () =>
            {
                rover.SetPosition(position, area);
            };

            //Assert
            action.Should().Throw<Exception>();
             
            
        }
    }
}