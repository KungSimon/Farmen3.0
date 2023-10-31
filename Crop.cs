using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Farmen2._0
{
    internal class Crop : Entity
    {
        public int Quantity { get; set; }
        public string CropType { get; set; }
        public Crop(string name, int quantity, string cropType)
            : base(name)
        {
            Quantity = quantity;
            CropType = cropType;
        }
        public string GetName()
        {
            return Name;
        }
        public override string GetDescription()
        {

            if (Name.Length <= 6)
            {
                Console.WriteLine("Id" + Id + "\t" + "Cropname: " + Name + "\t\t\t" + "Quantity of crop: " + Quantity + "\t" + "Croptype: " + CropType);
            }
            else if (Name.Length > 6 || Name.Length <= 12)
            {
                Console.WriteLine("Id" + Id + "\t" + "Cropname: " + Name + "\t\t" + "Quantity of crop: " + Quantity + "\t" + "Croptype: " + CropType);
            }
            else
            {
                Console.WriteLine("Id" + Id + "\t" + "Cropname: " + Name + "\t" + "Quantity of crop: " + Quantity + "\t" + "Croptype: " + CropType);
            }

            return null;
        }
        public void AddCrop(List<Crop> crops, int id)
        {

            /*foreach (Crop c in crops)
            {
                Console.WriteLine(c.GetDescription());
            }*/

            for (int i = 0; i < crops.Count; i++)
            {
                if (crops[i].Id == id)
                {
                    Console.WriteLine("Enter the quantity of the crop: ");
                    int Newquantity = int.Parse(Console.ReadLine());
                    crops[i].Quantity += Newquantity;
                    Console.WriteLine($" The quantity of {crops[i].Name} is {crops[i].Quantity} ");
                    break;
                }
                /*CropManager cropManager = new CropManager();
                List<Crop> crops = cropManager.GetCrops();
                foreach (Crop c in crops) {
                    Console.WriteLine( GetDescription());
                }
                for (int i = 0; i < crops.Count; i++)
                {
                    Console.WriteLine(GetDescription());
                    if (crops[i].Id == id)
                    {
                        Console.WriteLine("Enter the quantity of the crop: ");
                        int Newquantity = int.Parse(Console.ReadLine());
                        crops[i].Quantity += Newquantity;
                        Console.WriteLine($" The new quantity of {crops[i].Name} is {crops[i].Quantity} ");
                        break;
                    }*/
                }
            }

        public bool TakeCrop(int Id)
        {
            CropManager cropManager = new CropManager();
            List<Crop> crops = cropManager.GetCrops();
            for (int i = 0; i < crops.Count; i++)
            {
                if (Id == crops[i].Id)
                {

                    int quantity = CheckQuantity();
                    crops[i].Quantity = -quantity;
                    Console.WriteLine($"Now you have {crops[i].Quantity} left");


                }
            }

            return true;

        }
        public int CheckQuantity() //Skapade denna funktion för att inte fåp för många måsvingar så att koden blir mer överskådlig
        {
            /*while (true)
            {
                try
                {
                    Console.WriteLine($"How much {crop.CropType} do you want to use");
                    int quantity = int.Parse(Console.ReadLine());

                    if (quantity > 0 && quantity <= crop.Quantity)
                    {
                        return quantity;
                    }
                    else if (quantity == 0)
                    {
                        return quantity;
                    }
                    else
                    {
                        Console.WriteLine("Not enough Crops");
                        Console.WriteLine("0 will cancel the request");
                    }
                }
                catch
                {
                    Console.WriteLine("Please use numbers");
                }
            }*/
            CropManager cropManager = new CropManager();
            List<Crop> crops = cropManager.GetCrops();

            for (int i = 0; i < crops.Count; i++)
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine($"How much {crops[i].Name} do you whant to use");
                        int quantity = int.Parse(Console.ReadLine());

                        if (crops[i].Quantity - quantity! < 0)
                        {
                            return quantity;
                            break;
                        }
                        else if (quantity == 0)
                        {
                            return quantity;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Not enough Crops ");
                            Console.WriteLine("0 will cancel the request");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Please use numbers");
                    }
                }
            }
            return 0;
        }
    }
}
