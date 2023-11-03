using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Farmen2._0
{
    internal class Animal : Entity
    {
        public string Species { get; set; }
        public List<string> acceptableCropTypes { get; set; }

        public Animal(string name, string species)
            : base(name)
        {
            Species = species;
            acceptableCropTypes = new List<string>();
        }
        public Animal(string name) : base(name)
        {

        }
        public override string GetDescription()
        {
            string cropTypes = string.Join(", ", acceptableCropTypes);
            string formattedName = Name.PadRight(25);
            string formattedSpecies = Species.PadRight(10);
            return $"Id{Id}\tName: {formattedName}Species: {formattedSpecies} Eats: {cropTypes}";
            
        }
        public void Feed(Crop crop) //Vi använder inte Feed, eftersom vi gör funktionen i AnimalManager i FeedAnimal.
        {
            
            Console.WriteLine("How much do you want to feed the animal?");
            try
            {
                int foodQuantity = int.Parse(Console.ReadLine());
                crop.TakeCrop(crop, foodQuantity);
            }
            catch
            {
                Console.WriteLine("Enter a number.");
            }
        }
        public void AddCropType(string acceptableCropType)
        {
            acceptableCropTypes.Add(acceptableCropType);
        }
    }
}
