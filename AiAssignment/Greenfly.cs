using System;
using System.Text;
namespace AiAssignment
{
    public class Greenfly//prey 
    {
        private string o = Encoding.ASCII.GetString(new byte[] { 111 });//transforms the ascii key to o
        public Random random = new Random();//this used for the random movement
        private int survivalCounter = 0,locX,locY;//column,row and the location recieved
        private bool moved,breedCaller, preLocation,timeCheck;//this bool checks if it exist/dead ,occupied and moved
        public string greenflyMarker {get { return this.o; } set { this.o = value; }}//gets,sets the character representing greenfly
        public bool Moved { get { return moved; } set { moved = value; } }//this should check if moved or not
        public bool BreedCaller { get { return breedCaller; } set { breedCaller = value; } }
        public bool PreLocation { get { return preLocation; } set { preLocation = value; } }
        public int LocX { get { return locX; } set { locX = value; } }//location column to set previous value to empty
        public int LocY { get { return locY; } set { locY = value; } }//location row to set previous value to empty

        public char move(char[,] field, int locationX, int locationY)//location is the current column and row 
        {
            char[] oVal = greenflyMarker.ToCharArray();
            Moved = false;
            int rn = random.Next(1, 5);
            try{

            if (rn == 1 && Moved == false && field[locationX - 1, locationY] == ' ')
             {//move up
                LocX = locationX;//this allows to make the previous location empty
                LocY = locationY;//this allows to make the previous location empty
                locationX -= 1;
                field[locationX, locationY] = oVal[0];
                Moved = true;
                PreLocation = true;
             }   

            if (rn == 2 && Moved == false && field[locationX + 1, locationY] == ' ')
            {//move down
                LocX = locationX;
                LocY = locationY;
                PreLocation = true;
                locationX += 1;
                field[locationX, locationY] = oVal[0];
                Moved = true;
            }

            if (rn == 3 && Moved == false && field[locationX, locationY - 1] == ' ')
            {//move left
                LocX = locationX;//this allows to make the previous location empty
                LocY = locationY;//this allows to make the previous location empty
                PreLocation = true;
                locationY -= 1;
                field[locationX, locationY] = oVal[0];
                Moved = true;
            }

            if (rn == 4 && Moved == false && field[locationX, locationY + 1] == ' ')
            {//move right
                LocX = locationX;//this allows to make the previous location empty
                LocY = locationY;//this allows to make the previous location empty
                PreLocation = true;
                locationY += 1;
                field[locationX, locationY] = oVal[0];
                Moved = true;
            }

            }catch (Exception ex) { PreLocation = false; }

            if (survivalCounter == 3)//if survived for three turns it breeds
            {
                BreedCaller = true;//this sets it true and allow it to breed a greenfly after it
                survivalCounter = 0;//makes it zero to breed next time
            }
            else
            {
                survivalCounter += 1;//increase the counter if it exists
            }

            return field[locationX, locationY];//this should generate a greenfly's new position
        }

        public char breed(char[,] field, int locationX, int locationY)//this allows to add a new greenfly
        {
            char[] oVal = greenflyMarker.ToCharArray();
            Moved = false;
            try
            {
                if ( Moved == false && field[locationX - 1, locationY] == ' ')//if empty then breed new greenfly
                {//move up
                    locationX -= 1;
                    field[locationX, locationY] = oVal[0];
                    Moved = true;
                }

                if ( Moved == false && field[locationX+1, locationY] == ' ')//if empty then breed new greenfly
                {//move down
                    locationX += 1;
                    field[locationX, locationY] = oVal[0];
                    Moved = true;
                }

                if ( Moved == false && field[locationX, locationY - 1] == ' ')//if empty then breed new greenfly
                {//move left
                    locationY -= 1;
                    field[locationX, locationY] = oVal[0];
                    Moved = true;
                }

                if ( Moved == false && field[locationX, locationY+1] == ' ')//if empty then breed new greenfly
                {//move right
                    locationY += 1;
                    field[locationX, locationY] = oVal[0];
                    Moved = true;
                }

                BreedCaller = false;
            }catch (Exception ex) { }

            return field[locationX, locationY];//this should generate a new greenfly
        }
    }
}