using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneRHinventorysystem
{
    class Program
    {
        // **************************************************
        //
        // Title: CapstoneRHinventorysystem 
        // Description: Inventory Your Guitars!
        // Application Type: Console
        // Author: Ryan D Hall
        // Dated Created: 12/1/18
        // Last Modified: 11//18
        //
        // Credit: John Velis For File_IO Code & for SimpleMonster Classes Code.
        //
        // **************************************************
        
        static void Main(string[] args)
        {
            string dataPath = @"Data\Data.txt";
            Console.ForegroundColor = ConsoleColor.Red;
            DisplayOpeningScreen();
            DisplayMenu(dataPath);
            DisplayClosingScreen();
        }

        /// <summary>
        /// load all characters from a file
        /// </summary>
        /// <param name="dataFile">data path</param>
        /// <returns>list of characters</returns>
        static List<Guitar> ReadCharactersFromCsvFile(string dataFile)
        {
            const char delineator = ',';

            List<string> CharacterStringList = new List<string>();

            List<Guitar> CharacterClassList = new List<Guitar>();

            Guitar tempGuitar = new Guitar();

            //
            // read each line and put it into an array and convert the array to a list
            //
            try
            {
                CharacterStringList = File.ReadAllLines(dataFile).ToList();
            }
            catch (Exception) // throw any exception up to the calling method
            {
                throw;
            }

            //
            // create character object for each line of data read and fill in the property values
            //
            foreach (string characterString in CharacterStringList)
            {
                tempGuitar = new Guitar();

                // use the Split method and the delineator on the array to separate each property into an array of properties
                string[] properties = characterString.Split(delineator);


                tempGuitar.Model = properties[0];
                tempGuitar.Weight = Convert.ToInt32(properties[1]);
                tempGuitar.IsElectric = Convert.ToBoolean(properties[2]);
                tempGuitar.Brand = (Guitar.GuitarBrand)Enum.Parse(typeof(Guitar.GuitarBrand), properties[3]);
                tempGuitar.CountryMadeIn = properties[4];
                tempGuitar.NumberOfStrings = Convert.ToInt32(properties[5]);

                CharacterClassList.Add(tempGuitar);
            }

            return CharacterClassList;
        }

        /// <summary>
        /// load character list from data file
        /// </summary>
        /// <param name="dataPath">data path</param>
        /// <returns>list of characters</returns>
        public static List<Guitar> DisplayLoadCharactersFromFile(string dataPath)
        {
            List<Guitar> guitars = new List<Guitar>();

            DisplayHeader("Load Characters from File");

            Console.WriteLine($"\tThe list of characters will be loaded from '{dataPath}'.");
            Console.WriteLine("\t\tPress any key to continue.");
            Console.ReadKey();

            //
            // try to read the characters from the data file into a list
            //
            try
            {
                guitars = ReadCharactersFromCsvFile(dataPath);
                Console.WriteLine("The characters were successfully loaded from the file.");
            }
            catch (Exception e) // catch any exception thrown by the read method
            {
                Console.WriteLine("The following error occurred when reading from the file.");
                Console.WriteLine(e.Message);
            }

            DisplayContinuePrompt();

            return guitars;
        }

        /// <summary>
        /// save list of characters to a file
        /// </summary>
        /// <param name="characterClassLIst">list of characters</param>
        /// <param name="dataPath">data path</param>
        static void WriteCharactersToCsvFile(string dataPath, List<Guitar> characterClassLIst)
        {
            string characterString;

            List<string> charactersStringListWrite = new List<string>();

            //
            // build the list to write to the text file line by line
            //
            foreach (var guitar in characterClassLIst)
            {
                characterString =
                    guitar.Model + "," +
                    guitar.CountryMadeIn + "," +
                    guitar.Weight + "," +
                    guitar.IsElectric + "," +
                    guitar.NumberOfStrings + ",";

                    

                charactersStringListWrite.Add(characterString);
            }

            //
            // write the list of strings (characters) to the data file
            //
            try
            {
                File.WriteAllLines(dataPath, charactersStringListWrite);
            }
            catch (Exception) // throw any exception up to the calling method
            {
                throw;
            }

        }

        /// <summary>
        /// save character list to the data file
        /// </summary>
        /// <param name="dataPath">data path</param>
        /// <param name="characters">list of characters</param>
        public static void DisplaySaveCharactersToFile(string dataPath, List<Guitar> guitars)
        {
            DisplayHeader("Save Characters to File");

            Console.WriteLine($"\tThe list of guitars will be saved to '{dataPath}'.");
            Console.WriteLine("\t\tPress any key to continue.");
            Console.ReadKey();

            //
            // try to write the list of characters to the file
            //
            try
            {
                WriteCharactersToCsvFile(dataPath, guitars);
                Console.WriteLine("The guitars were successfully saved to the file.");
            }
            catch (Exception e)// catch any exception thrown by the write method
            {
                Console.WriteLine("The following error occurred when writing to the file.");
                Console.WriteLine(e.Message);
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// instantiate and initialize sid the sea monster
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>SeaMonster object</returns>
        static Guitar InitializeGuitar1(string name)
        {
            Guitar Duck = new Guitar("The Duck")
            {
                Weight = 8,
                IsElectric = true,
                Brand = Guitar.GuitarBrand.Fender,
                CountryMadeIn = "USA",
                NumberOfStrings = 6
            };
            return Duck;
        }

        /// <summary>
        /// instantiate and initialize suzy the sea monster
        /// </summary>
        /// <returns>SeaMonster object</returns>
        static Guitar InitializeGuitar2()
        {
            Guitar REDS = new Guitar
            {
                Model = "Red Special",
                Weight = 9,
                IsElectric = true,
                Brand = Guitar.GuitarBrand.Custom,
                CountryMadeIn = "United Kingdom",
                NumberOfStrings = 6
            };
            return REDS;
        }

        /// <summary>
        /// display all information about a sea monster
        /// </summary>
        /// <param name="seaMonster">SeaMonster object</param>
        static void DisplayGuitarInfo(List<Guitar> guitars)
        {
            string GuitarModel;
            DisplayHeader("Display Guitar Info");

            //
            // Display List of Guitar Names
            //
            foreach (Guitar guitar in guitars)
            {
                Console.WriteLine(guitar.Model);
            }
            Console.WriteLine();
            Console.WriteLine("Enter Guitar Model");
            Console.WriteLine();
            GuitarModel = Console.ReadLine();
            bool GuitarFound = false;
            foreach (Guitar guitar in guitars)
            {
                if (guitar.Model == GuitarModel)
                {
                    Console.WriteLine();
                    Console.WriteLine("Name: " + guitar.Model);
                    Console.WriteLine("Weight lbs: " + guitar.Weight);
                    Console.WriteLine("Electric?: " + guitar.IsElectric);
                    Console.WriteLine("Brand: " + guitar.Brand);
                    Console.WriteLine("Number of Strings: " + guitar.NumberOfStrings);
                    Console.WriteLine();
                    GuitarFound = true;
                    break;
                }
            }
            if (!GuitarFound)
            {
                Console.WriteLine("Guitar unable to be found.");
            }
            DisplayContinuePrompt();
        }

        /// <summary>
        /// update a sea monsters information
        /// </summary>
        /// <param name="seaMonster">SeaMonster object</param>
        static void DisplayDeleteGuitar(List<Guitar> guitars)
        {
            string seaMonsterName;
            DisplayHeader("Delete Sea Monster Info");

            //
            // Display List of Guitars
            //
            foreach (Guitar seaMonster in guitars)
            {
                Console.WriteLine(seaMonster.Model);
            }
            Console.WriteLine();
            Console.WriteLine("Enter Name of Guitar to Delete");
            seaMonsterName = Console.ReadLine();
            bool guitarFound = false;
            foreach (Guitar seaMonster in guitars)
            {
                if (seaMonster.Model == seaMonsterName)
                {
                    guitars.Remove(seaMonster);

                    guitarFound = true;
                    break;
                }
            }
            if (!guitarFound)
            {
                Console.WriteLine("Guitar unable to be found.");
            }
            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a list of all sea monsters
        /// </summary>
        /// <param name="guitars">list of SeaMonster</param>
        static void DisplayAllGuitars(List<Guitar> guitars)
        {
            DisplayHeader("List of Guitars");
            foreach (Guitar seaMonster in guitars)
            {
                Console.WriteLine(seaMonster.Model);
            }
            DisplayContinuePrompt();
        }

        static void DisplayGetUpdatedGuitar(List<Guitar> guitars)
        {
            string Guitarmodel;
            DisplayHeader("Update guitar Info");

            //
            // Display List of Sea Monster Names
            //
            foreach (Guitar seaMonster in guitars)
            {
                Console.WriteLine(seaMonster.Model);
            }
            Console.WriteLine();
            Console.WriteLine("Enter Model of Guitar to Update");
            Console.WriteLine();
            Guitarmodel = Console.ReadLine();
            bool monsterFound = false;
            foreach (Guitar guitar in guitars)
            {
                if (guitar.Model == Guitarmodel)
                {
                    guitars.Remove(guitar);

                    monsterFound = true;
                    break;
                }
            }
            if (!monsterFound)
            {
                Console.WriteLine("Guitar unable to be found.");
            }
            DisplayContinuePrompt();

            Guitar updatedGuitar = new Guitar();
            string uv;
            DisplayHeader("Update a Guitar");

            Console.WriteLine("Enter Model");
            Console.WriteLine();
            updatedGuitar.Model = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Enter Weight (Lbs)");
            Console.WriteLine();
            Double.TryParse(Console.ReadLine(), out double weight);
            updatedGuitar.Weight = weight;
            Console.Clear();
            Console.WriteLine($"Is " + updatedGuitar.Model + " an electric instrument? Enter Yes or No:");
            Console.WriteLine();
            uv = Console.ReadLine();

            if (uv.ToUpper() == "YES")
            {
                updatedGuitar.IsElectric = true;
            }
            else
            {
                updatedGuitar.IsElectric = false;
            }
            Console.Clear();
            Console.WriteLine("Enter Guitar Brand");
            Console.WriteLine();
            Enum.TryParse(Console.ReadLine(), out Guitar.GuitarBrand Brand);
            updatedGuitar.Brand = Brand;
            Console.Clear();
            Console.WriteLine("Enter The Country The Guitar was Made in:");
            Console.WriteLine();
            updatedGuitar.CountryMadeIn = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Enter Number of Strings");
            Console.WriteLine();
            double.TryParse(Console.ReadLine(), out double NumberOfStrings);
            updatedGuitar.NumberOfStrings = NumberOfStrings;

            //
            // Add Updated Sea Monster to the List
            //
            guitars.Add(updatedGuitar);

            DisplayContinuePrompt();

        }

        /// <summary>
        /// display a screen to get a new sea monster from the user
        /// </summary>
        /// <param name="guitars">list of SeaMonster</param>
        static void DisplayGetUserGuitar(List<Guitar> guitars)
        {
            Guitar newGuitar = new Guitar();
            string uv;
            DisplayHeader("Add a Guitar");

            Console.WriteLine("Enter Model");
            Console.WriteLine();
            newGuitar.Model = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Enter Guitar Weight");
            Console.WriteLine();
            Double.TryParse(Console.ReadLine(), out double weight);
            newGuitar.Weight = weight;
            Console.Clear();
            Console.WriteLine("Is this an electric guitar? Enter Yes or No:");
            Console.WriteLine();
            uv = Console.ReadLine();
            if (uv.ToUpper() == "YES")
            {
                newGuitar.IsElectric = true;
            }
            else
            {
                newGuitar.IsElectric = false;
            }
            Console.Clear();
            Console.WriteLine("Enter Guitar Brand:");
            Console.WriteLine();
            Enum.TryParse(Console.ReadLine(), out Guitar.GuitarBrand Brand);
            newGuitar.Brand = Brand;
            Console.Clear();
            Console.WriteLine("Enter the Guitars County of Origin:");
            Console.WriteLine();
            newGuitar.CountryMadeIn = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Enter Number of Strings");
            Console.WriteLine();
            double.TryParse(Console.ReadLine(), out double NumberOfStrings);
            newGuitar.NumberOfStrings = NumberOfStrings;

            //
            // Add a guitar to the List
            //
            guitars.Add(newGuitar);

            DisplayContinuePrompt();

        }

        

        /// <summary>
        /// display menu and process user menu choices
        /// </summary>
        static void DisplayMenu(string dataPath)
        {
            //
            // instantiate guitars
            //
            Guitar REDS;
            REDS = InitializeGuitar2();
            Guitar Duck;
            Duck = InitializeGuitar1("The Duck");
           
            List<Guitar> guitars = new List<Guitar>
            {
                Duck,
                REDS
            };


            string menuChoice;
            bool exiting = false;

            while (!exiting)
            {
                DisplayHeader("Main Menu");

                Console.WriteLine("\t1) Display All Guitars");
                Console.WriteLine("\t2) Add a Guitar");
                Console.WriteLine("\t3) Display Guitar Info");
                Console.WriteLine("\t4) Delete Guitar Info");
                Console.WriteLine("\t5) Update a Guitars Info");
                Console.WriteLine("\t6) Save Guitars");
                Console.WriteLine("\t7) Load Guitars");
                Console.WriteLine("\t8) Exit");
                Console.WriteLine();
                Console.WriteLine("Enter Choice:");
                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                    case "a":
                        DisplayAllGuitars(guitars);
                        break;

                    case "2":
                    case "b":
                        DisplayGetUserGuitar(guitars);
                        break;

                    case "3":
                    case "c":
                        DisplayGuitarInfo(guitars);
                        break;

                    case "4":
                    case "d":
                        DisplayDeleteGuitar(guitars);
                        break;

                    case "5":
                    case "e":
                        DisplayGetUpdatedGuitar(guitars);
                        break;
                    case "6":
                    case "f":
                        DisplaySaveCharactersToFile(dataPath, guitars);
                        break;
                    case "7":
                    case "g":
                        guitars = DisplayLoadCharactersFromFile(dataPath);
                        break;
                    case "8":
                    case "h":
                        exiting = true;
                        break;

                    default:
                        Console.WriteLine("Error, please try again.");
                        break;
                }
            }
        }

        #region HELPER METHODS

        /// <summary>
        /// display opening screen
        /// </summary>
        static void DisplayOpeningScreen()
        {
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("\t\tWelcome to Ryan Hall's Guitar Inventory");
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
            Console.WriteLine("\t\tThank You for using My Guitar Inventory.");
            Console.WriteLine();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
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
        /// display header
        /// </summary>
        static void DisplayHeader(string headerTitle)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerTitle);
            Console.WriteLine();
        }

        #endregion
    }
}
