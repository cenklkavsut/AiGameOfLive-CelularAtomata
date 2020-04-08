using System;
using System.Text;
namespace AiAssignment
{
    public class Ladybird//preditor
    {
        private string x = Encoding.ASCII.GetString(new byte[] { 88 });//transforms the ascii key to  x
        private bool occupied, moved, consumed, breedCaller, preLocation,timeCheck;//this bool checks if it is occupied,cosumed and moved
        private int survivalCounter = 0, starveCounter = 0, locX, locY;
        public Random random = new Random();//this used for the random movement
        public string ladybirdMarker { get { return this.x; } set { this.x = value; } }//gets,sets the character representing ladybird
        public bool Occupied { get { return occupied; } set { occupied = value; } }
        public bool Consumed { get { return consumed; } set { consumed = value; } }
        public bool Moved { get { return moved; } set { moved = value; } }//this should check if moved or not
        public bool BreedCaller { get { return breedCaller; } set { breedCaller = value; } }
        public bool PreLocation { get { return preLocation; } set { preLocation = value; } }
        public int LocX { get { return locX; } set { locX = value; } }//location column to set previous value to empty
        public int LocY { get { return locY; } set { locY = value; } }//location row to set previous value to empty

        public char move(char[,] field, int locationX, int locationY)//location is the current column and row 
        {
         Greenfly greenfly = new Greenfly();//this calls the greenfly class
         char[] xVal = ladybirdMarker.ToCharArray();
         char[] oVal = greenfly.greenflyMarker.ToCharArray();
         Moved = false;
            try
            {
                if (Moved == false && field[locationX, locationY - 1] == oVal[0])//move left
                {//first it checks if it can consume any greenfly 
                    LocX = locationX;//this allows to make the previous location empty
                    LocY = locationY;//this allows to make the previous location empty
                    locationY -= 1;
                    field[locationX, locationY] = xVal[0];//this should allow it to consume it
                    starveCounter = 0;//when it consumes it sets it to zero
                    Consumed = true;
                    PreLocation = true;
                    Moved = true;
                }

                if (Moved == false && field[locationX, locationY + 1] == oVal[0])//move right
                {//first it checks if it can consume any greenfly 
                    LocX = locationX;//this allows to make the previous location empty
                    LocY = locationY;//this allows to make the previous location empty
                    locationY += 1;
                    field[locationX, locationY] = xVal[0];//this should allow it to consume it
                    starveCounter = 0;//when it consumes it sets it to zero
                    Consumed = true;
                    PreLocation = true;
                    Moved = true;
                }

                if (Moved == false && field[locationX - 1, locationY] == oVal[0])//move up
                {//first it checks if it can consume any greenfly 
                    LocX = locationX;//this allows to make the previous location empty
                    LocY = locationY;//this allows to make the previous location empty
                    locationX -= 1;
                    field[locationX, locationY] = xVal[0];//this should allow it to consume it
                    starveCounter = 0;//when it consumes it sets it to zero
                    Consumed = true;
                    PreLocation = true;
                    Moved = true;
                }

                if (Moved == false && field[locationX + 1, locationY] == oVal[0])//move down
                {//first it checks if it can consume any greenfly 
                    LocX = locationX;//this allows to make the previous location empty
                    LocY = locationY;//this allows to make the previous location empty
                    locationX += 1;
                    field[locationX, locationY] = xVal[0];//this should allow it to consume it
                    starveCounter = 0;//when it consumes it sets it to zero
                    Consumed = true;
                    PreLocation = true;
                    Moved = true;
                }


                int rn = random.Next(1, 5);//here it will give a random number for movement if it did not move yet
                if (rn == 1 && Moved == false && field[locationX - 1, locationY] == ' ')//move up
                {
                    LocX = locationX;//this allows to make the previous location empty
                    LocY = locationY;//this allows to make the previous location empty
                    locationX -= 1;
                    field[locationX, locationY] = xVal[0];//set the current location to x
                    Consumed = false;
                    PreLocation = true;
                    Moved = true;
                }

                if (rn == 2 && Moved == false && field[locationX + 1, locationY] == ' ')//move down
                {
                        LocX = locationX;//this allows to make the previous location empty
                        LocY = locationY;//this allows to make the previous location empty
                        locationX += 1;
                        field[locationX, locationY] = xVal[0];
                        Consumed = false;
                        PreLocation = true;
                        Moved = true;
                }

                if (rn == 3 && Moved == false && field[locationX, locationY - 1] == ' ')//move left
                {
                    LocX = locationX;//this allows to make the previous location empty
                    LocY = locationY;//this allows to make the previous location empty
                    locationY -= 1;
                    field[locationX, locationY] = xVal[0];
                    Consumed = false;
                    PreLocation = true;
                    Moved = true;
                }

                if (rn == 4 && Moved == false && field[locationX, locationY + 1] == ' ')//move right
                {
                    LocX = locationX;//this allows to make the previous location empty
                    LocY = locationY;//this allows to make the previous location empty
                    locationY += 1;
                    field[locationX, locationY] = xVal[0];
                    Consumed = false;
                    PreLocation = true;
                    Moved = true;
                }
                
            } catch (Exception ex){ PreLocation = false; }

            if (starveCounter == 3)//this checks the starving state
            {
                    starveCounter = 0;//when it is zero it dies
                    survivalCounter = 0;//makes it zero to breed next time
                    field[locationX, locationY] = starve(field, locationX, locationY);//this is the starve effect of the ladybird
            }
            else if (Consumed == false)
            {
                    starveCounter += 1;//it increases until 3 if it is three it starves
            }

            if (survivalCounter == 8)//this checks the survival and breeding state
            {
               BreedCaller = true;//this sets it true and allow it to breed a ladybird after it
               survivalCounter = 0;//makes it zero to breed next time
            }
            else
            {
                survivalCounter += 1;//increase the counter if it exists
            }

            return field[locationX, locationY];//this should generate a new ladybird
        }

        public char breed(char[,] field, int locationX, int locationY)
        {//this allows to add a new ladybird
            char[] xVal = ladybirdMarker.ToCharArray();
            Moved = false;
            try
            {
                if (Moved == false && field[locationX - 1, locationY] == ' ')//move up
                {//if empty then breed new ladybird
                    locationX -= 1;
                    field[locationX, locationY] = xVal[0];
                    Moved = true;
                }

                if ( Moved == false && field[locationX + 1, locationY] == ' ')//move down
                {//if empty then breed new ladybird
                    locationX += 1;
                    field[locationX, locationY] = xVal[0];
                    Moved = true;
                }

                if ( Moved == false && field[locationX, locationY - 1] == ' ')//move left
                {//if empty then breed new ladybird
                    locationY -= 1;
                    field[locationX, locationY] = xVal[0];
                    Moved = true;
                }

                if (Moved == false && field[locationX, locationY + 1] == ' ')//move right
                {//if empty then breed new ladybird
                    locationY += 1;
                    field[locationX, locationY] = xVal[0];
                    Moved = true;
                }

                BreedCaller = false;
            } catch (Exception ex) { }

            return field[locationX, locationY];//this should generate a new ladybird
        }

        public char starve(char[,] field, int locationX, int locationY)
        {
            Grid count = new Grid();
            return field[locationX, locationY] = ' ';
        }
    }
}