using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmen2._0
{
    internal class CropManager
    {
        public List<Crop> crops = new List<Crop>();

        public CropManager()
        {
            Crop crop = new Crop("Wheat", 100, "Grain");
            Crop crop1 = new Crop("Corn", 80, "Seed");
            Crop crop2 = new Crop("Rye", 100, "Grain");
            Crop crop3 = new Crop("Oat", 100, "Grain");
            Crop crop4 = new Crop("Silage", 100, "Grass");
            Crop crop5 = new Crop("Sugar snap peas", 170, "Seed");
            Crop crop6 = new Crop("Pumpkin seeds", 500, "Seed");
            Crop crop7 = new Crop("Pumkin", 180, "Cucumber plant");
            Crop crop8 = new Crop("Melon", 20, "Cucumber plant");
            Crop crop9 = new Crop("Cucumber", 100, "Cucumber plant");

            crops.Add(crop);
            crops.Add(crop1);
            crops.Add(crop2);
            crops.Add(crop3);
            crops.Add(crop4);
            crops.Add(crop5);
            crops.Add(crop6);
            crops.Add(crop7);
            crops.Add(crop8);
            crops.Add(crop9);

        }
        public void CropMenu()
        {

            bool cropMenu = true;
            while (cropMenu)
            {
                Console.WriteLine("");
                Console.WriteLine("Crop Menu");
                Console.WriteLine("1. View Crops");
                Console.WriteLine("2. Add Crop");
                Console.WriteLine("3. Remove Crop");
                Console.WriteLine("9. Quit Menu");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewCrops();
                        break;

                    case "2":
                        AddCrop();
                        break;

                    case "3":
                        Crop crop = Checkcrop();
                        RemoveCrop(crop.Id);
                        break;

                    case "9":
                        cropMenu = false;
                        break;
                }
            }
        }

        private void AddCrop() //Kollar om sädeslaget finns, och om det finns så läggs kvantiteten till på det gamla objektet.
                               //Annars läggs nytt sädeslag till i listan. 
                               
        {
            bool foundCrop = false;
            int quantity;
            Console.WriteLine("What's the crop's name?");
            string name = Console.ReadLine();
            name = name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower();
            for (int i = 0; i < crops.Count; i++) 
            {
               if (name == crops[i].GetName())
                {
                    Console.WriteLine("How much crop do you whant to add ");
                    quantity = int.Parse(Console.ReadLine());
                    crops[i].AddCrop(crops[i], quantity);
                   
                    foundCrop = true;
                    break;
                }
            }
            if (!foundCrop)
            {
                Console.WriteLine("What's the crop's type?");
                string type = Console.ReadLine();
                Console.WriteLine("How much crop do you whant to add ");
                quantity = int.Parse(Console.ReadLine());
                crops.Add(new Crop(name, quantity, type));
            }
        }

        private void RemoveCrop(int id)
        {
            
                for (int i = 0; i < crops.Count; i++)
                {
                    if (crops[i].Id == id)
                    {
                        Console.WriteLine($"Crop {crops[i].Id} was succesfully removed.");
                        crops.Remove(crops[i]);
                    }
                }
        }

        private void ViewCrops()
        {
            Console.WriteLine("List of Crops:");
            Console.WriteLine("");
            foreach (Crop crop in crops)
            {
                Console.WriteLine(crop.GetDescription());
            }
        }
        public List<Crop> GetCrops()
        {
            return crops;
        }
        public Crop Checkcrop() // Kollar så att Id't tillhör en crop, och ger tillbaka en crop när du har rätt Id. 
        {
            foreach (Crop crop in crops)
            {
                Console.WriteLine(crop.GetDescription());
            }
            bool foundCrop = false;
            while (foundCrop == false)
            {
                Console.WriteLine("With what crop? Choose by Id");
                try
                {
                    int cropId = int.Parse(Console.ReadLine());
                    foreach (Crop crop in crops)
                    {
                        if (cropId == crop.Id)
                        {
                            Console.WriteLine("found crop ");

                            return crop;
                            foundCrop = true;
                            break;
                        }
                    }
                    if (!foundCrop)
                    {
                        Console.WriteLine("This is not an crop Id");
                    }
                }
                catch { Console.WriteLine("Please choose a crop Id"); }
            }
            return null;
        }
    }
}
