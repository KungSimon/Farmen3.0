using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmen2._0
{
    internal class Farm
    {
         
        CropManager cropManager;
        AnimalManager animalManager;

        public Farm() 
        {
            this.cropManager = new CropManager();
            this.animalManager = new AnimalManager(cropManager);
        }

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
                        animalManager.AnimalMenu();
                        break;
                    case "2":
                        cropManager.CropMenu();
                        break;

                    case "9":
                        mainMenu = false;
                        break;
                }
            }
        }
    }
}
