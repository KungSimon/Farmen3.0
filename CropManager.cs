using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmen2._0
{
    internal class CropManager
    {
        List<Crop> crops = new List<Crop>();

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
                        ViewCrops();
                        Console.WriteLine("Choose an crop to use by ID");
                        int id = int.Parse(Console.ReadLine());
                        RemoveCrop(id);
                        ViewCrops();
                        break;

                    case "9":
                        cropMenu = false;
                        break;
                }
            }
        }

        private void AddCrop()
        {
            /*foreach (Crop crop in crops)
            {
                Console.WriteLine(crop.GetDescription());
            }*/

            Console.WriteLine("What's the crop's name?");
            string name = Console.ReadLine();
            Console.WriteLine("What's the crop's type?");
            string type = Console.ReadLine();
            int quantity = 0;
            Crop newCrop = new Crop(name, quantity, type);
            crops.Add(newCrop);

            if (crops.Count > 0)
            {
                Crop lastItem = crops[crops.Count - 1];
                lastItem.AddCrop(crops,lastItem.Id); // Skicka hela listan av grödor som en parameter
            }

            /*foreach (Crop crop in crops)
            {
                Console.WriteLine(crop.GetDescription());
            }
            Console.WriteLine("Whats the crops name?");
            string name = Console.ReadLine();
            Console.WriteLine("Whats the crops type?");
            string type = Console.ReadLine();
            int quantity = 0;
            Crop newCrop = new Crop(name, quantity, type);
            crops.Add(newCrop);
            Console.WriteLine(newCrop.Id);
            newCrop.AddCrop(newCrop.Id);*/


            //for (int i = 0; i < crops.Count; i++)
            //{
            //    int id = 0;
            //    if (crops[i].Id == newCrop.Id)
            //    {
            //        crops[i].Id = id;
            //        newCrop.AddCrop(id);
            //    }    
            //}

        }

        private void RemoveCrop(int id)
        {
            for (int i = 0; i < crops.Count; i++)
            {
                if (crops[i].Id == id)
                {
                    crops.Remove(crops[i]);
                }
            }
        }

        private void ViewCrops()
        {
            Console.WriteLine("List of Crops:");
            foreach (Crop crop in crops)
            {
                crop.GetDescription();
            }
        }
        public List<Crop> GetCrops()
        {
            return crops;
        }
       
    }
}
