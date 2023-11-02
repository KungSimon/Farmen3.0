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

            if (Name.Length <= 5)
            {
                Console.WriteLine("Id" + Id + "\t" + "Cropname: " + Name + "\t\t\t\t" + "Quantity of crop: " + Quantity + "\t" + "Croptype: " + CropType);
            }
            else if (Name.Length > 5 || Name.Length <= 10)
            {
                Console.WriteLine("Id" + Id + "\t" + "Cropname: " + Name + "\t\t\t" + "Quantity of crop: " + Quantity + "\t" + "Croptype: " + CropType);
            }
            else if (Name.Length > 10 || Name.Length <= 14)
            {
                Console.WriteLine("Id" + Id + "\t" + "Cropname: " + Name + "\t\t" + "Quantity of crop: " + Quantity + "\t" + "Croptype: " + CropType);
            }
            else
            {
                Console.WriteLine("Id" + Id + "\t" + "Cropname: " + Name  + "Quantity of crop: " + Quantity + "\t" + "Croptype: " + CropType);
            }

            return null;
        }
        public void AddCrop(int cropQuantity)
        {
            Quantity += cropQuantity;
            Console.WriteLine($"Your new quantity is {Quantity}");
        }
        public bool TakeCrop(Crop crop, int cropQuantity)
        {
            //Console.WriteLine(crop.Quantity);
            if (crop.Quantity - cropQuantity < 0)
            {
                return false;  
            }
            else
            {
                int newQuantity = crop.Quantity - cropQuantity;
                crop.Quantity = newQuantity;
                Console.WriteLine("Your new quantity is " + crop.Quantity);
                return true;
            }
        }
        
    }
}
