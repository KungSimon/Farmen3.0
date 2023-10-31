using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmen2._0
{
    internal class Farm
    {
        AnimalManager AnimalManager = new AnimalManager();
        CropManager CropManager = new CropManager();
        public Farm() { }

        public void MainMenu()
        {
            bool mainMenu = true;
            while (mainMenu)
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("1. Animals");
                Console.WriteLine("2. Crops");
                Console.WriteLine("9. Quit The Farm");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AnimalManager.AnimalMenu();
                        break;
                    case "2":
                        CropManager.CropMenu();
                        break;

                    case "9":
                        mainMenu = false;
                        break;
                }
            }
        }
    }
}
