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

            if (Name.Length <= 6)
            {
                Console.WriteLine("Id" + Id + "\t" + Name + "\t\t\t" + Species);
            }
            else if (Name.Length > 6 || Name.Length <= 12)
            {
                Console.WriteLine("Id" + Id + "\t" + Name + "\t\t" + Species);
            }
            else
            {
                Console.WriteLine("Id" + Id + "\t" + Name + "\t" + Species);
            }

            return null;
        }
        public void Feed(Crop crop)
        {
            //CropManager cropManager = new CropManager();
            //List<Crop> crops = cropManager.GetCrops();
            //for (int i = 0; i < crops.Count; i++)
            //{
            //    if (crops[i] == crop)
            //    {
            //        crops[i].TakeCrop(crops[i] );
            //    }
            //}
            //foreach (Crop c in crops) 
            //{
            //    Console.WriteLine(c.GetDescription());
            //}



        }
        public void AddCropType(string acceptableCropType)
        {
            acceptableCropTypes.Add(acceptableCropType);
        }
    }
}
