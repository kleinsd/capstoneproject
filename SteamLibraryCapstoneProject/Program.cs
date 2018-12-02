using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        // Last Modified: 12/2/2018
        //********************

        static void Main(string[] args)
        {
            DisplayOpeningScreen();
            DisplayMainMenu();
            DisplayClosingScreen();
        }

        static void DisplayMainMenu()
        {
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

                    case "Q":
                    case "q":
                        exiting = true;
                        break;

                    default:
                        break;
                }
            }

        }
        static void DisplaySteamGameInfo(List<SteamGame> steamGames)
        {
            DisplayHeader("In Depth Steam Game Info");


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
                    Console.WriteLine("Genre:" + steamGame.CurrentGameGenre);
                    Console.WriteLine("Price : $" + steamGame.Price);
                    Console.WriteLine("Hours played:" + steamGame.Hours);
                    found = true;
                    break;
                }
            }
            //
            // CHECK FORMATTING ********
            //
            if (!found)
            {
                Console.WriteLine($"Unable to locate Steam Game named {steamGameName}.");
            }

            DisplayContinuePrompt();
        }

        static void DisplayDeleteSteamGame(List<SteamGame> steamGames)
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

            DisplayContinuePrompt();
        }

        static void DisplayAddSteamGame(List<SteamGame> steamGames)
        {
            SteamGame userSteamGame = new SteamGame();

            DisplayHeader("Add a Steam Game");

            Console.Write("Enter Name:");
            userSteamGame.Name = Console.ReadLine();

            //
            // list game genres so they know *****  ADD HERE
            //

            Console.WriteLine();

            Console.Write("Enter Genre:");
            Enum.TryParse(Console.ReadLine().ToLower(), out SteamGame.GameGenre genre);
            userSteamGame.CurrentGameGenre = genre;

            Console.Write("Enter Price:");
            double.TryParse(Console.ReadLine(), out double price);
            userSteamGame.Price = price;

            Console.Write("Enter Hours Played:");
            int.TryParse(Console.ReadLine(), out int hours);
            userSteamGame.Hours = hours;

            steamGames.Add(userSteamGame);
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
