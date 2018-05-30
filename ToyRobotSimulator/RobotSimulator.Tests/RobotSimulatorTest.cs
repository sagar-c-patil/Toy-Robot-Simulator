using RobotSimulator.Domain;
using RobotSimulator.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RobotSimulator.Tests
{
    /// <summary>
    /// Test fixture for validating basic user stories of robot simulator
    /// </summary>
    public class RobotSimulatorTest
    {
        private Surface table;
        public RobotSimulatorTest(){
            table= new Surface(5, 5);
        }

        [Fact]
        public void Robot_Valid_Place_Command_Should_Set_CurrentPosition()
        {
            Robot toyRobot = new Robot(table);
            Command command = new PlaceCommand();

            command.Execute(toyRobot, "0,0,NORTH");
            var currentPosition = toyRobot.CurrentPosition;

            Assert.NotNull(currentPosition);
            Assert.Equal(0, currentPosition.Coordinate.X);
            Assert.Equal(0, currentPosition.Coordinate.Y);
            Assert.Equal("NORTH", currentPosition.Direction.ToString());
        }

        [Fact]
        public void Robot_Valid_Move_Command_To_North_Should_Adavance_Step_By_One_Unit()
        {
            Robot toyRobot = new Robot(table);
            Command command = new PlaceCommand();

            command.Execute(toyRobot, "0,0,NORTH");
            var afterPlacePosition = toyRobot.CurrentPosition;

            command = new MoveCommand();
            command.Execute(toyRobot);
            var afterMovePosition = toyRobot.CurrentPosition;

            Assert.NotNull(afterPlacePosition);
            Assert.NotNull(afterMovePosition);
            Assert.Equal(afterPlacePosition.Coordinate.Y+1, afterMovePosition.Coordinate.Y);           
            Assert.Equal("NORTH", afterMovePosition.Direction.ToString());
        }


        [Fact]
        public void Robot_Valid_Move_Command_To_South_Should_Adavance_Step_By_One_Unit()
        {
            Robot toyRobot = new Robot(table);
            Command command = new PlaceCommand();

            command.Execute(toyRobot, "2,2,SOUTH");
            var afterPlacePosition = toyRobot.CurrentPosition;

            command = new MoveCommand();
            command.Execute(toyRobot);
            var afterMovePosition = toyRobot.CurrentPosition;

            Assert.NotNull(afterPlacePosition);
            Assert.NotNull(afterMovePosition);
            Assert.Equal(afterPlacePosition.Coordinate.Y - 1, afterMovePosition.Coordinate.Y);
            Assert.Equal("SOUTH", afterMovePosition.Direction.ToString());
        }

        [Fact]
        public void Robot_Valid_Move_Command_To_West_Should_Adavance_Step_By_One_Unit()
        {
            Robot toyRobot = new Robot(table);
            Command command = new PlaceCommand();

            command.Execute(toyRobot, "2,2,WEST");
            var afterPlacePosition = toyRobot.CurrentPosition;

            command = new MoveCommand();
            command.Execute(toyRobot);
            var afterMovePosition = toyRobot.CurrentPosition;

            Assert.NotNull(afterPlacePosition);
            Assert.NotNull(afterMovePosition);
            Assert.Equal(afterPlacePosition.Coordinate.X - 1, afterMovePosition.Coordinate.X);
            Assert.Equal("WEST", afterMovePosition.Direction.ToString());
        }

        [Fact]
        public void Robot_Valid_Move_Command_To_East_Should_Adavance_Step_By_One_Unit()
        {
            Robot toyRobot = new Robot(table);
            Command command = new PlaceCommand();

            command.Execute(toyRobot, "2,2,EAST");
            var afterPlacePosition = toyRobot.CurrentPosition;

            command = new MoveCommand();
            command.Execute(toyRobot);
            var afterMovePosition = toyRobot.CurrentPosition;

            Assert.NotNull(afterPlacePosition);
            Assert.NotNull(afterMovePosition);
            Assert.Equal(afterPlacePosition.Coordinate.X + 1, afterMovePosition.Coordinate.X);
            Assert.Equal("EAST", afterMovePosition.Direction.ToString());
        }

        [Fact]
        public void Robot_Valid_Rotate_Right_Command_From_North_Should_Turn_Robot_To_East()
        {
            Robot toyRobot = new Robot(table);
            Command command = new PlaceCommand();

            command.Execute(toyRobot, "2,2,NORTH");
            var afterPlacePosition = toyRobot.CurrentPosition;

            command = new RightCommand();
            command.Execute(toyRobot);
            var afterTurnRightPosition = toyRobot.CurrentPosition;

            Assert.NotNull(afterPlacePosition);
            Assert.NotNull(afterTurnRightPosition);           
            Assert.Equal("EAST", afterTurnRightPosition.Direction.ToString());
        }

        [Fact]
        public void Robot_Valid_Rotate_Left_Command_From_North_Should_Turn_Robot_To_West()
        {
            Robot toyRobot = new Robot(table);
            Command command = new PlaceCommand();

            command.Execute(toyRobot, "2,2,NORTH");
            var afterPlacePosition = toyRobot.CurrentPosition;

            command = new LeftCommand();
            command.Execute(toyRobot);
            var afterTurnLeftPosition = toyRobot.CurrentPosition;

            Assert.NotNull(afterPlacePosition);
            Assert.NotNull(afterTurnLeftPosition);
            Assert.Equal("WEST", afterTurnLeftPosition.Direction.ToString());
        }

        [Fact]
        public void Robot_Report_Command_Without_Place_Should_Ignore()
        {
            Robot toyRobot = new Robot(table);
            Command command = new ReportCommand();

            var report = command.Execute(toyRobot);
            
            Assert.Equal(string.Empty, report);
        }

        [Fact]
        public void Robot_Report_Command_With_Place_Should_Success()
        {
            Robot toyRobot = new Robot(table);

            Command command = new PlaceCommand();

            command.Execute(toyRobot, "2,2,NORTH");
            var afterPlacePosition = toyRobot.CurrentPosition;

            command = new ReportCommand();
            var report = command.Execute(toyRobot);

            Assert.Equal("Output: 2,2,NORTH", report);
        }

        [Theory]
        [InlineData("6,5,NORTH")]
        [InlineData("0,-1,NORTH")]
        [InlineData("5,6,NORTH")]
        [InlineData("-1,0,NORTH")]
        public void Robot_Placed_Outside_Table_Boundary_Should_Ignore_Command(string parameters)
        {
            Robot toyRobot = new Robot(table);
            Command command = new PlaceCommand();

            command.Execute(toyRobot, parameters);
            var currentPosition = toyRobot.CurrentPosition;

            Assert.Null(currentPosition);
        }

        [Theory]
        [InlineData("0,0,SOUTH")]
        public void Robot_Moved_To_Outside_Table_Boundary_Should_Ignore_Command(string parameters)
        {
            Robot toyRobot = new Robot(table);
            Command command = new PlaceCommand();

            command.Execute(toyRobot, parameters);
            var afterPlacePosition = toyRobot.CurrentPosition;

            command = new MoveCommand();
            command.Execute(toyRobot);
            var afterMovePosition = toyRobot.CurrentPosition;

            Assert.NotNull(afterPlacePosition);       

            Assert.Equal(afterMovePosition.Coordinate.Y, afterPlacePosition.Coordinate.Y);
        }
    }
}
