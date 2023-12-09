using System;
using System.Linq;

namespace Tic_Tac_Game__XO_Game_
{
    internal class Program
    {
        static int Player = 1;
        static string[] Game = { "0", "1", "2", "3", "4","5" ,"6", "7", "8"};
        static int TryIntNumb;
        static int Winner;
        static char anotherGame;


        static void Main(string[] args)
        {
            playAnotherGame:
            do
            {
            StartAgain:
                Console.Clear();
                Console.WriteLine(" Player 1 --> X \n\n Player 2 --> O");
                Console.WriteLine("\n");

                //Check which player has the chance to play 
                if (Player % 2 == 0)
                {
                    Console.WriteLine("Player '2' Will Play, Choose The Position For 'O'\n");
                }
                else
                {
                    Console.WriteLine("Player '1' Will Play, Choose The Position For 'X'\n");
                }
                DrawTheGrid(Game);

                //Constraint for Enter only numbers to choose the position in the grid
                 bool Choice = int.TryParse(Console.ReadLine()?.ToUpper(), out TryIntNumb);
                if (Choice)
                {
                    //The Entered number should be in range 0->8
                    if (TryIntNumb >= 0 && TryIntNumb <= 8)
                    {
                        if (Game[TryIntNumb] != "X" && Game[TryIntNumb] != "O")
                        {
                            if (Player % 2 == 0)
                            {
                                Game[TryIntNumb] = "O";
                                Player++;
                            }
                            else
                            {
                                Game[TryIntNumb] = "X";
                                Player++;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"\nSorry You Can't Enter a '{Game[TryIntNumb]}' in position '{TryIntNumb}' ");
                            Console.WriteLine("\n");
                            Console.WriteLine("Please Wait For '3' Seconds to reload The Grid");
                            Thread.Sleep(3000);
                        }


                    }
                    else
                    {
                        Console.WriteLine("\nWrong Position You Can Choose From '0 To 8' Only\n");
                        Console.WriteLine("Please Wait For '3' Seconds to reload The Grid");
                        Thread.Sleep(3000);
                        goto StartAgain;
                    }
                }
                else
                {
                    Console.WriteLine("\nWrong.. You should Enter Only Numbers in Range '0 To 8'\n");
                    Console.WriteLine("Please Wait For '3' Seconds to reload The Grid");
                    Thread.Sleep(3000);
                    goto StartAgain;
                }

                Winner = CheckTheWinner(Game);
            } while (Winner != 1 && Winner != -1);

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("[ End Game Copy Rights By 'Eyad' ]\n");
            Console.ForegroundColor = ConsoleColor.White;
            DrawTheGrid(Game);

            if (Winner == 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"\nThe Player {(Player % 2) + 1} ( {((Player % 2) + 1 == 1 ? 'X' : 'O')} ) is a Winner ^_^ ");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("Do You Want to Play another Game ? (Y/N)");
                anotherChoice: bool yesOrNo = char.TryParse(Console.ReadLine()?.ToUpper(), out anotherGame);
                if(yesOrNo)
                {
                    if (anotherGame == 'Y')
                    {
                        Player = 1;
                        Game =new string[]{ "0", "1", "2", "3", "4", "5", "6", "7", "8" };
                        DrawTheGrid(Game);
                        goto playAnotherGame;
                    }
                    if (anotherGame=='N')
                        Console.WriteLine("Thank you, We hope you enjoy the game experience ");
                    else
                    {
                        Console.WriteLine("Wrong Choise.. Please enter only 'Y' to play another game or 'N' for Exit\n");
                        Console.WriteLine("Please Wait For '3' Seconds to reload The Grid");
                        Thread.Sleep(2000);
                        goto anotherChoice;
                    }

                }
                else
                {
                    Console.WriteLine("Wrong Choise.. Please enter only 'Y' to play another game or 'N' for Exit\n");
                    Console.WriteLine("Please Wait For '3' Seconds to reload The Grid");
                    Thread.Sleep(2000);
                    goto anotherChoice;
                }
               
                
            }
            else if (Winner == -1)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nThere is No Winner ):\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Do You Want to Play another Game ? (Y/N)");
            anotherChoice: bool yesOrNo = char.TryParse(Console.ReadLine()?.ToUpper(), out anotherGame);
                if (yesOrNo)
                {
                    if (anotherGame == 'Y')
                    {
                        Player = 1;
                        Game = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8" };
                        DrawTheGrid(Game);
                        goto playAnotherGame;
                    }
                    if (anotherGame == 'N')
                        Console.WriteLine("Thank you, We hope you enjoy the game experience ");
                    else
                    {
                        Console.WriteLine("Wrong Choise.. Please enter only 'Y' to play another game or 'N' for Exit\n");
                        Console.WriteLine("Please Wait For '3' Seconds to reload The Grid");
                        Thread.Sleep(2000);
                        goto anotherChoice;
                    }


                }
                else
                {
                    Console.WriteLine("Wrong Choise.. Please enter only 'Y' to play another game or 'N' for Exit\n");
                    Console.WriteLine("Please Wait For '3' Seconds to reload The Grid");
                    Thread.Sleep(2000);
                    goto anotherChoice;
                }

            }
            Console.ReadKey();
        }


        // Draw The Grid
        #region Region For Darwing the Grid
        static void DrawTheGrid(string[]XOGrid)
        {
            Console.WriteLine("     |     |     ");
            Console.WriteLine($"   {XOGrid[0]} |   {XOGrid[1]} |   {XOGrid[2]} ");
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine($"   {XOGrid[3]} |   {XOGrid[4]} |   {XOGrid[5]} ");
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine($"   {XOGrid[6]} |   {XOGrid[7]} |   {XOGrid[8]} ");
            Console.WriteLine("     |     |     ");

        }
        #endregion

        //Assign The Symbols For Each Position
        #region Region for Draw Each symbol in the grid
        static int CheckTheWinner(string[]XOGrid)
        {
            if (XOGrid[0] == XOGrid[1] && XOGrid[1] == XOGrid[2])
                return 1;
            else if (XOGrid[3] == XOGrid[4] && XOGrid[4] == XOGrid[5])
                return 1;
            else if (XOGrid[6] == XOGrid[7] && XOGrid[7] == XOGrid[8])
                return 1;
            else if (XOGrid[0] == XOGrid[3] && XOGrid[3] == XOGrid[6])
                return 1;
            else if (XOGrid[1] == XOGrid[4] && XOGrid[4] == XOGrid[7])
                return 1;
            else if (XOGrid[2] == XOGrid[5] && XOGrid[5] == XOGrid[8])
                return 1;
            else if (XOGrid[0] == XOGrid[4] && XOGrid[4] == XOGrid[8])
                return 1;
            else if (XOGrid[2] == XOGrid[4] && XOGrid[4] == XOGrid[6])
                return 1;
            else if (XOGrid[0] != "0" && XOGrid[1] != "1" && XOGrid[2] != "2" && XOGrid[3] != "3" && XOGrid[4] != "4" && XOGrid[5] != "5" && XOGrid[6] != "6" && XOGrid[7] != "7" && XOGrid[8] != "8")
                return -1;
            else
                return 0;
        }
        #endregion
        
    }
}