using System;
namespace AiAssignment
{
    // Author: [Cenk Latif Kavsut] 
    // SID: [1572556] 
    // Edited: [26/11/2019] 
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;//makes the foreground colour of the console 
            Console.BackgroundColor = ConsoleColor.Black;//makes the background black of the console

            Console.WriteLine("Please Enter Start execude the Application!");
            int timeStep = 0;//this is the counter for the turn
            Grid grid = new Grid();//call the grids operations
            grid.gridMaker();//this generates the initial grid

            do
            {//this loop will stop when escape key has been pressed and another key afterwards
                if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                {//if enter has been clicked display next state   
                    Console.Clear();//clears the previous output
                    Console.ForegroundColor = ConsoleColor.White;//makes the foreground colour of the console 
                    Console.WriteLine("Cellular automata/Game of life!");
                    Console.WriteLine("Greenfly is o" + "\nLadybird is x");//the explanation

                    grid.gridUpdater();//this updates the state of the game
                    Console.ForegroundColor = ConsoleColor.Red;//makes the foreground colour of the console 
                    timeStep += 1;//the turn it increases each press of enter clicked
                    Console.WriteLine("Time step " + timeStep);
                    Console.ForegroundColor = ConsoleColor.White;//makes the foreground colour of the console 
                    Console.WriteLine("Click Escape key to end the game of life " +"\nEnter to go to the next iteration!");
                }
                else
                {//waits for response of user pressing an enter key 
                    Console.ReadLine();//this pauses it//System.Threading.Thread.Sleep(10);
                }

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            Environment.Exit(0);//if this key is pressed it closed the application directly.
            Console.ReadLine();
        }
    }
}