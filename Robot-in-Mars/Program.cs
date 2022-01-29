using System;
using System.Text.RegularExpressions;

namespace Robot_in_Mars
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("-- Welcome --");
            Console.WriteLine("");
            Console.WriteLine("Do you want listen about this program?");
            Console.WriteLine("");
            Console.WriteLine("y or n?");
            Console.WriteLine("");

            var answer = Console.ReadLine();
            var resposta = answer.ToUpper();

            if (resposta == "Y")
            {
                Console.WriteLine("");
                Console.WriteLine("This program will simulate a robot moving on Mars");
                Console.WriteLine("");
                System.Threading.Thread.Sleep(5000);
                Console.WriteLine("First you will enter the size of the grid you want");
                Console.WriteLine("");
                System.Threading.Thread.Sleep(5000);
                Console.WriteLine("Next are the commands for it to move, which can be the following commands:");
                Console.WriteLine("");
                System.Threading.Thread.Sleep(5000);
                Console.WriteLine("L: Turn the robot left");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("R: Turn the robot right");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("F: Move forward on it's facing direction");
                System.Threading.Thread.Sleep(2000);
                Console.WriteLine("");
                Console.WriteLine("");
            }
            else if (resposta == "N")
            {
                Console.WriteLine("");
                Console.WriteLine("All right");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Invalid option");
                return;
            }

            Console.WriteLine("Enter the grid size:");
            Console.WriteLine("Example: 5x5, 3x4, 6x2, etc.");
            var sizeGrid = Console.ReadLine();
            Console.WriteLine("");

            var xPosition = sizeGrid.IndexOf('x');
            var xValue = sizeGrid.Substring(0, xPosition);

            // Grid x validation
            if (!Regex.IsMatch(xValue, @"^[0-9]+$") || Int64.Parse(xValue) == 0)
            {
                Console.WriteLine("Grid size format invalid.");
                return;
            }
            
            var yPosition = xPosition + 1;
            var yValue = sizeGrid.Substring(yPosition);

            // Grid y validation
            if(!Regex.IsMatch(yValue, @"^[0-9]+$") || Int64.Parse(yValue) == 0)
            {
                Console.WriteLine("Grid size format invalid.");
                return;
            }

            Console.WriteLine("");
            Console.WriteLine("Enter the commands for the robot to move:");
            Console.WriteLine("Example: LFLRFLFF");
            Console.WriteLine("");
            var commands = Console.ReadLine().ToUpper();
            var commandsList = commands.ToCharArray();

            string direction = "NORTH";
            int xStart = 1;
            int yStart = 1;

            foreach (char command in commandsList)
            {
                switch (command)
                {
                    case 'L':
                        if(direction == "NORTH") direction = "WEST";
                        else if (direction == "WEST") direction = "SOUTH";
                        else if (direction == "SOUTH") direction = "EAST";
                        else if (direction == "EAST") direction = "NORTH";
                        break;
                    case 'R':
                        if (direction == "NORTH") direction = "EAST";
                        else if (direction == "EAST") direction = "SOUTH";
                        else if (direction == "SOUTH") direction = "WEST";
                        else if (direction == "WEST") direction = "NORTH";
                        break;
                    case 'F':
                        if (direction == "NORTH" && yStart < Int64.Parse(yValue)) yStart++;
                        else if (direction == "EAST" && xStart < Int64.Parse(xValue)) xStart++;
                        else if (direction == "SOUTH" && yStart < Int64.Parse(yValue)) yStart--;
                        else if (direction == "WEST" && xStart < Int64.Parse(xValue)) xStart--;
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Final position: " + xStart + "," + yStart + "," + direction);
            System.Threading.Thread.Sleep(10000);
        }       
    }
}
