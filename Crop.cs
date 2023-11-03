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
            string formattedName = Name.PadRight(25);
            string formattedQuantity = Quantity.ToString().PadRight(10);
            string formattedCropType = CropType.PadRight(25);
            return $"Id {Id}\tCropname: {formattedName}Quantity of crop: {formattedQuantity}Croptype: {formattedCropType}";
        }
        public void AddCrop(Crop crop, int cropQuantity) //Vi la till en crop så att vi vet vilken crop den ska lägga till quantity på. 
        {
            int newQuantity = crop.Quantity + cropQuantity;
            crop.Quantity = newQuantity;
            Console.WriteLine($"Your {crop.GetName()} quantity is now {crop.Quantity}");
        }
        public bool TakeCrop(Crop crop, int cropQuantity)
        {
            if (crop.Quantity - cropQuantity < 0)
            {
                Console.WriteLine("Not enough crops.");
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
