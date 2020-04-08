using System;
using System.Collections.Generic;
namespace AiAssignment
{
    public class Grid
    {
        private int x = 20, y = 20, chooserLadybird = 0, choosergreenfly = 0, chooser = 0, count = 0;//counters relation to movements or steps

        private char[,] currentWorld = new char[20, 20];//the current grid and the 
        private string asciiReplacment;//temporary ascii key container
        private Ladybird ladybird = new Ladybird();//this calls the ladybird class
        private Greenfly greenfly = new Greenfly();//this calls the greenfly class
        private Random random = new Random();//this creates a random for inserting values randomly
        private bool boardGenerated;//this checks if greenfly is 5  and  board is 99
        public bool BoardGenerated { get { return boardGenerated; } set { boardGenerated = value; } }
        public int CountLadybird, CountGreenfly;//this contain a bug not incrementing it

        private string SupportDrawer(string asciiO, string asciiX)//this allows to draw the board with random values
        {
            if (chooserLadybird == 4 && choosergreenfly == 99)//this allows to stop generating more than required
            {
                BoardGenerated = true;//this disables further generation of the board and allows stop adding more in
            }
            if (BoardGenerated == false)
            {            
                chooser = random.Next(1, 4);//this allows to insert values randomly based on choice
                switch (chooser)
                {
                    case 1:
                        if ( chooserLadybird < 5)//if one choose ladybird
                        {
                            asciiReplacment = asciiX;//this stores the value of the asci character
                            chooserLadybird += 1;//increase the counter to check the amount inserted
                            CountLadybird+= 1;
                        }
                        else//this allows to generate it faster
                        {
                            chooser = random.Next(2, 4);//this allows to insert values randomly based on choice
                        }
                        break;
                    case 2:
                        if (choosergreenfly < 100)//if two choose greenfly
                        {
                            asciiReplacment = asciiO;//this stores the value of the asci character
                            choosergreenfly += 1;//increase the counter to check the amount inserted
                            CountGreenfly += 1;
                        }
                        else//this allows to generate it faster
                        {
                            chooser = 3;
                        }
                        break;
                    case 3:
                        asciiReplacment = " ";//insert empty value
                        break;
                }
            }

            return asciiReplacment;
        }

        public void gridMaker()//this allows to generate the 20x20 initial grid
        {
            string asciiO = greenfly.greenflyMarker;//call the ascii character for greenfly
            string asciiX = ladybird.ladybirdMarker;//call the ascii character for ladybird
            Console.WriteLine("Click Enter to start\nand when the game of life starts it will display the turn! ");

            Console.WriteLine("-+-----------------------------------------+-");//draws a line on the top side
            for (int column = 0; column < x; column++)//this draws hight of the grid
            {
                Console.Write(" | ");//draws a line to left side
                for (int row = 0; row < y; row++)//this draws width of the grid
                {
                    if (BoardGenerated == false)
                    {
                        asciiReplacment = SupportDrawer(asciiO, asciiX);//this allows to draw it randomly
                    }
                    char[] container = asciiReplacment.ToCharArray();//convert it to char
                    currentWorld[column, row] = container[0];//add the value into the array
                    Console.Write("{0} ", currentWorld[column, row]);//it generates the board
                }
                Console.Write("|");//draws a line to right side
                Console.WriteLine(" ");
            }
            Console.WriteLine("-+-----------------------------------------+-");//draws a line on the bottom side
            Console.ForegroundColor = ConsoleColor.Green;//makes the foreground colour of the console 
            Console.WriteLine("Ladybird amount {0}\nGreenfly amount {1}", CountLadybird, CountGreenfly);
            BoardGenerated = true;
        }

        public void LadybirdUpdate()//this updates the ladybirds
        {
            string asciiX = ladybird.ladybirdMarker;//call the ascii character for ladybird
            char[] ladybirdChecker = asciiX.ToCharArray();//stores the value of the ladybird into a char array
            for (int column = 0; column < x; column++)
            {
                for (int row = 0; row < y; row++)
                {
                    if (currentWorld[column, row] == ladybirdChecker[0])//ladybird movement
                    {
                        currentWorld[column, row] = ladybird.move(currentWorld, column, row);

                        if (ladybird.PreLocation == true)//this allows for the previous location to be empty
                        {
                            currentWorld[ladybird.LocX, ladybird.LocY] = ' ';
                        }
                    }

                    if (ladybird.BreedCaller == true&&count >7)//this allows for it to generate a new ladybird
                    {
                        currentWorld[column, row] = ladybird.breed(currentWorld, column, row);//breed a new ladybird
                    }
                }
            }
        }

        public void GreenflyUpdate()//this updates the greenflies
        {
            string asciiO = greenfly.greenflyMarker;//call the ascii character for greenfly
            char[] greenflyChecker = asciiO.ToCharArray();//stores the value of the greenfly into a char array
            for (int column = 0; column < x; column++)
            {
                for (int row = 0; row < y; row++)
                {
                    if (currentWorld[column, row] == greenflyChecker[0])//greenfly movement
                    {
                        currentWorld[column, row] = greenfly.move(currentWorld, column, row);

                        if (greenfly.PreLocation == true )//this allows for the previous location to be empty
                        {
                            currentWorld[greenfly.LocX, greenfly.LocY] = ' ';
                        }
                    }

                    if (greenfly.BreedCaller == true&&count>=3)//this allows for it to generate a new greenfly
                    {
                        currentWorld[column, row] = greenfly.breed(currentWorld, column, row);//breed a new greenfly
                    }
                }
            }
        }

        public void gridUpdater()
        {
            LadybirdUpdate();//update ladybird
            GreenflyUpdate();//update greenfly
            count++;
            Console.ForegroundColor = ConsoleColor.Green;//makes the foreground colour of the console 
            Console.WriteLine("-+-----------------------------------------+-");//draws a line on the top side of the loop
            for (int column = 0; column < x; column++)//this draws hight of the grid
            {
                Console.ForegroundColor = ConsoleColor.Green;//makes the foreground colour of the console 
                Console.Write(" | ");//draws a line to left side
                for (int row = 0; row < y; row++)//this draws width of the grid
                {
                    Console.ForegroundColor = ConsoleColor.White;//makes the foreground colour of the console                    
                    Console.Write("{0} ", currentWorld[column, row]);//draw the updated grid state   
                }                
                Console.ForegroundColor = ConsoleColor.Green;//makes the foreground colour of the console 
                Console.Write("|");//draws a line to right side
                Console.WriteLine(" ");
            }
            Console.WriteLine("-+-----------------------------------------+-");//draws a line on the bottom side
        }
    }
}