using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SteamLibraryCapstoneProject
{
    class Program
    {
        //********************
        // Title: Capstone Project CIT 110
        // Application type: .net Framework C#
        // Description: The pupose of this app is to organize your steam library into value and hours played to see how much 
        // time and money you have wasted.
        // Author: Devon Kleinschmit
        // Date Created: 11/28/2018
        // Last Modified: 12/7/2018
        //********************

        static void Main(string[] args)
        {

            DisplayOpeningScreen();
            DisplayMainMenu();
            DisplayClosingScreen();
        }

        static void DisplayMainMenu()
        {
            // string dataPath = @"Data\DataFile1.txt";
            string menuChoice;
            bool exiting = false;
            List<SteamGame> steamGames = new List<SteamGame>();
            while (!exiting)
            {
                DisplayHeader("\t\tMain Menu");

                Console.WriteLine("\tA) Display All Steam Games");
                Console.WriteLine("\tB) Add to The List");
                Console.WriteLine("\tC) Delete a Steam Game");
                Console.WriteLine("\tD) Display Detailed Info");
                //Console.WriteLine("\tE) Save List to File");
                //Console.WriteLine("\tF) Read List from File");
                Console.WriteLine("");
                Console.WriteLine("\tQ) Quit");
                Console.WriteLine("");
                Console.Write("Enter Choice:");
                menuChoice = Console.ReadLine();
                switch (menuChoice)
                {
                    case "A":
                    case "a":
                        DisplayAllSteamGames(steamGames);
                        break;

                    case "B":
                    case "b":
                        DisplayAddSteamGame(steamGames);
                        break;

                    case "C":
                    case "c":
                        DisplayDeleteSteamGame(steamGames);
                        break;

                    case "D":
                    case "d":
                        DisplaySteamGameInfo(steamGames);
                        break;

                    //case "E":
                    //case "e":
                    //    DisplayWriteToFile(steamGames, dataPath);
                    //    break;

                    //case "F":
                    //case "f":
                    //    DisplayReadFromFile(steamGames, dataPath);
                    //    break;

                    case "Q":
                    case "q":
                        exiting = true;
                        break;

                    default:
                        break;
                }
            }

        }

        //static void DisplayReadFromFile(List<SteamGame> steamGames, string dataPath)
        //{
        //    string dataInfo;
        //    Console.Clear();
        //    dataInfo = File.ReadAllText(dataPath);
        //    Console.WriteLine(dataInfo);
        //    DisplayContinuePrompt();
        //}

        //static void DisplayWriteToFile(List<SteamGame> steamGames, string dataPath)
        //{

        //    Console.WriteLine("Writing to file.");
        //    File.WriteAllText(dataPath, steamGames);
        //    Console.WriteLine("Successful");

        //    DisplayContinuePrompt();
        //}

        static void DisplaySteamGameInfo(List<SteamGame> steamGames)
        {
            bool runApp = true;
            bool found = false;
            string userResponse;
            while (runApp)
            {
                
                DisplayHeader("In Depth Steam Game Info");

                foreach (SteamGame steamGame in steamGames)
                {
                    Console.WriteLine(steamGame.Name);
                }
                Console.WriteLine();
                Console.Write("Enter Name:");
                string steamGameName = Console.ReadLine();

                foreach (SteamGame steamGame in steamGames)
                {
                    if (steamGame.Name == steamGameName)
                    {
                        Console.WriteLine("Genre:" + steamGame.CurrentGameGenre.ToString().PadLeft(10));
                        Console.WriteLine("Price:" + steamGame.Price.ToString("C").PadLeft(10));
                        Console.WriteLine("Hours:" + steamGame.Hours.ToString().PadLeft(10));
                        found = true;
                        Console.WriteLine();
                        break;
                        
                    }
                }
                if (!found)
                {
                    Console.WriteLine($"Unable to locate Steam Game named {steamGameName}.");
                    DisplayContinuePrompt();
                }
                Console.WriteLine("Would you like to search again?");
                Console.WriteLine("Yes or No");
                userResponse = Console.ReadLine();

                if (userResponse.ToLower() == "yes")
                {
                    runApp = true;
 
                }
                else
                {
                    runApp = false;
                    
                }
                Console.Clear();
                
            }
        }

        static void DisplayDeleteSteamGame(List<SteamGame> steamGames)
        {
            bool deleteLoop = true;
            
            string userResponse;
            while (deleteLoop)
            {
                DisplayHeader("Delete a Steam Game");

                foreach (SteamGame steamGame in steamGames)
                {
                    Console.WriteLine(steamGame.Name);
                }
                Console.WriteLine();
                Console.Write("Enter Name:");
                string steamGameName = Console.ReadLine();

                bool found = false;
                foreach (SteamGame steamGame in steamGames)
                {
                    if (steamGame.Name == steamGameName)
                    {
                        steamGames.Remove(steamGame);
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Console.WriteLine($"Can not locate: {steamGameName}.");
                }
                Console.WriteLine("Would you like to delete another game?");
                Console.WriteLine("Yes or No");
                userResponse = Console.ReadLine();

                if (userResponse.ToLower() == "yes")
                {
                    deleteLoop = true;

                }
                else
                {
                    deleteLoop = false;

                }
                Console.Clear();

              
            }
        }
            

        static void DisplayAddSteamGame(List<SteamGame> steamGames)
        {
            SteamGame userSteamGame = new SteamGame();
            bool runApp = true;
            string userResponse;
            while (runApp)
            {
                DisplayHeader("Add a Steam Game");

                Console.Write("Enter Name:");
                userSteamGame.Name = Console.ReadLine();

                Console.WriteLine();
                Console.WriteLine("Game Genres:");
                foreach (string genreName in Enum.GetNames(typeof(SteamGame.GameGenre)))
                {
                    if (genreName != SteamGame.GameGenre.unknown.ToString())
                    {
                        Console.WriteLine(genreName);
                    }
                }

                Console.WriteLine();
                Console.Write("Enter Genre:");
                Enum.TryParse(Console.ReadLine().ToLower(), out SteamGame.GameGenre genre);
                userSteamGame.CurrentGameGenre = genre;

                Console.WriteLine(genre);

                Console.Write("Enter Price:");
                double.TryParse(Console.ReadLine(), out double price);
                userSteamGame.Price = price;

                Console.Write("Enter Hours Played:");
                int.TryParse(Console.ReadLine(), out int hours);
                userSteamGame.Hours = hours;

                steamGames.Add(userSteamGame);

                Console.WriteLine("Would you like to add another game?");
                Console.WriteLine("Yes or No");
                userResponse = Console.ReadLine();

                if (userResponse.ToLower() == "yes")
                {
                    runApp = true;

                }
                else
                {
                    runApp = false;

                }
                Console.Clear();
            }


        }


            static void DisplayAllSteamGames(List<SteamGame> steamGames)
            {
            
                DisplayHeader("List of Steam Games");

                foreach (SteamGame steamGame in steamGames)
                {
                    Console.WriteLine(steamGame.SteamGameQuickDescription());
                }

                DisplayContinuePrompt();
            
            }
        #region HELPFUL METHODS
        static void DisplayHeader(string header)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + header);
            Console.WriteLine();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display opening screem
        /// </summary>
        static void DisplayOpeningScreen()
        {
            Console.WriteLine();
            Console.WriteLine("\t\tSteam library organizer");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display closing screen
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for organizing your Steam library.");
            Console.WriteLine();

            DisplayContinuePrompt();

        }
        #endregion
    }
}
