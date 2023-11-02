using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmen2._0
{
    internal class AnimalManager
    {

        public CropManager manager;    
        List<Animal> animals = new List<Animal>();
        
        public AnimalManager(CropManager manager)
        {
            this.manager = manager;

            //AnimalManager animalManager = new AnimalManager();
            Animal animal1 = new Animal("Matilda", "Pig");
            animal1.AddCropType("Grain");
            animal1.AddCropType("Grass");
            animal1.AddCropType("Cucumber plant");
            Animal animal2 = new Animal("Ruby", "Pig");
            animal2.AddCropType("Grain");
            animal2.AddCropType("Grass");
            animal2.AddCropType("Cucumber plant");
            Animal animal3 = new Animal("Elsie", "Pig");
            animal3.AddCropType("Grain");
            animal3.AddCropType("Grass");
            animal3.AddCropType("Cucumber plant");
            Animal animal4 = new Animal("Hazel", "Pig");
            animal4.AddCropType("Grain");
            animal4.AddCropType("Grass");
            animal4.AddCropType("Cucumber plant");
            Animal animal5 = new Animal("Pär", "Pig");
            animal5.AddCropType("Grain");
            animal5.AddCropType("Grass");
            animal5.AddCropType("Cucumber plant");
            Animal animal6 = new Animal("Olle", "Pig");
            animal6.AddCropType("Grain");
            animal6.AddCropType("Grass");
            animal6.AddCropType("Cucumber plant");
            Animal animal7 = new Animal("Pelle", "Cow");
            animal7.AddCropType("Grain");
            animal7.AddCropType("Grass");
            Animal animal8 = new Animal("Rosie", "Cow");
            animal8.AddCropType("Grain");
            animal8.AddCropType("Grass");
            Animal animal9 = new Animal("Bella", "Cow");
            animal9.AddCropType("Grain");
            animal9.AddCropType("Grass");
            Animal animal10 = new Animal("Daisy", "Cow");
            animal10.AddCropType("Grain");
            animal10.AddCropType("Grass");
            Animal animal11 = new Animal("Bessie", "Cow");
            animal11.AddCropType("Grain");
            animal11.AddCropType("Grass");
            Animal animal12 = new Animal("Kalle", "Chicken");
            animal12.AddCropType("Seed");
            Animal animal13 = new Animal("Rut", "Chicken");
            animal13.AddCropType("Seed");
            Animal animal14 = new Animal("Ragnar", "Chicken");
            animal14.AddCropType("Seed");
            Animal animal15 = new Animal("Danne", "Chicken");
            animal15.AddCropType("Seed");
            Animal animal16 = new Animal("Bo", "Chicken");
            animal16.AddCropType("Seed");
            Animal animal17 = new Animal("Pernilla", "Sheep");
            animal17.AddCropType("Grass");
            animal17.AddCropType("Cucumber plant");
            Animal animal18 = new Animal("Ida", "Sheep");
            animal18.AddCropType("Grass");
            animal18.AddCropType("Cucumber plant");
            Animal animal19 = new Animal("Rosa", "Sheep");
            animal19.AddCropType("Grass");
            animal19.AddCropType("Cucumber plant");
            Animal animal20 = new Animal("Hulda", "Sheep");
            animal20.AddCropType("Grass");
            animal20.AddCropType("Cucumber plant");
            Animal animal21 = new Animal("Eskil", "Sheep");
            animal21.AddCropType("Grass");
            animal21.AddCropType("Cucumber plant");
            Animal animal22 = new Animal("Krull", "Sheep");
            animal22.AddCropType("Grass");
            animal22.AddCropType("Cucumber plant");

            animals.Add(animal1);
            animals.Add(animal2);
            animals.Add(animal3);
            animals.Add(animal4);
            animals.Add(animal5);
            animals.Add(animal6);
            animals.Add(animal7);
            animals.Add(animal8);
            animals.Add(animal9);
            animals.Add(animal10);
            animals.Add(animal11);
            animals.Add(animal12);
            animals.Add(animal13);
            animals.Add(animal14);
            animals.Add(animal15);
            animals.Add(animal16);
            animals.Add(animal17);
            animals.Add(animal18);
            animals.Add(animal19);
            animals.Add(animal20);
            animals.Add(animal21);
            animals.Add(animal22);

        }
        public void AnimalMenu()
        {
            bool animalMenu = true;
            while (animalMenu)
            {
                Console.WriteLine();
                Console.WriteLine("Animal Meny");
                Console.WriteLine("1. View Animals");
                Console.WriteLine("2. Add Animal");
                Console.WriteLine("3. Remove Animal");
                Console.WriteLine("4. Feed Animals");
                Console.WriteLine("9. Quit Menu");
                string input = Console.ReadLine();


                switch (input)
                {
                    case "1":
                        ViewAnimals();
                        break;
                        ;
                    case "2":
                        AddAnimal();
                        break;

                    case "3":
                        ViewAnimals();
                        ChooseAnimalToRemove();
                        break;

                    case "4":
                        string species = ChooseSpecies();
                        Crop crop = manager.Checkcrop();
                        FeedAnimal(species, crop);

                        break; 

                    case "9":
                        animalMenu = false;
                        break;

                }
            }


        }

        private void ChooseAnimalToRemove()
        {
            bool remove = false;
            bool found = false;
            while (remove == false)
            {
                Console.WriteLine("Choose an animal to remove by Id");
                try
                {
                    int id = int.Parse(Console.ReadLine());
                    foreach (Animal animal in animals)
                    {
                        if (id == animal.Id)
                        {
                            RemoveAnimal(id);
                            remove = true;
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        Console.WriteLine("This is not an animal Id");
                    }
                }
                catch { Console.WriteLine("Please chooes an animals Id"); }
            }
        }

        private string ChooseSpecies()
        {
            string species = null;
            Console.WriteLine();

            List<string> speciesList = ListAnimalSpecies();
            bool foundSp = false;
            while (foundSp == false)
            {
                Console.WriteLine("Which species do you want to feed?");
                species = (Console.ReadLine());
                species = species.Substring(0, 1).ToUpper() + species.Substring(1).ToLower();


                if (!speciesList.Contains(species))
                {
                    Console.WriteLine("This species doesn't exist on this farm");
                }
                else { foundSp = true; }
            }
            return species;
        }

        

        private void FeedAnimal(string species, Crop crop)
        {
            Console.WriteLine(crop.GetDescription());
            for (int i = 0; i < animals.Count; i++) 
            {
                if (animals[i].Species == species)
                {
                    List<string> acceptableCropTypes = animals[i].acceptableCropTypes;
                    if (!acceptableCropTypes.Contains(crop.CropType))
                    {
                        Console.WriteLine("This animal cant eat this crop type");
                        break;
                    }
                    Console.WriteLine("How much do you whant to feed each animal");
                    int food = int.Parse(Console.ReadLine());
                    int countOfSpecies = animals.Count(animal => animal.Species == species);
                    
                    int usedCrop = countOfSpecies * food;
                    Console.WriteLine( $"You whant to use {usedCrop} units of {crop.GetName()}");
                    crop.TakeCrop(crop, usedCrop);
                    break;
                }
   
            }
        }


        private bool AddAnimal()
        {
            
            Console.WriteLine("What is the animals name");
            string name = Console.ReadLine();
            name = name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower();

            bool AddSpec = false;
            while (AddSpec == false)
            {
                Console.WriteLine("What species is the animal");
                string species = Console.ReadLine();
                species = species.Substring(0, 1).ToUpper() + species.Substring(1).ToLower();
                
                for (int i = 0; i < animals.Count; i++)
                {
                    if (animals[i].Species == species)
                    {
                        Animal newAnimal = new Animal(name, species);
                        List<string> acceptableCropTypes = animals[i].acceptableCropTypes;
                        foreach (string acceptableType in acceptableCropTypes)
                        {
                            newAnimal.AddCropType(acceptableType);
                        }
                        animals.Add(newAnimal);
                        Console.WriteLine("You have successfully added ");
                        Console.WriteLine(newAnimal.GetDescription());
                        return true;
                        break;
                    } 
                }
                Console.WriteLine($"This farm does not breed choosen species {species}");
            }
            
            return true;
        }

        private void ViewAnimals()
        {
            Console.WriteLine();
            foreach (Animal animals in animals)
            {
                Console.WriteLine(animals.GetDescription());
            }

        }
        private void RemoveAnimal(int id)
        {
            for (int i = 0; i < animals.Count; i++)
            {
                if (animals[i].Id == id)
                {
                    Console.WriteLine($"Animal {animals[i].Id} was succesfully removed.");
                    animals.Remove(animals[i]);
                }
            }

        }
        public List<Animal> GetAnimals()
        {
            return animals;
        }
       
        public List<string> ListAnimalSpecies() 
        { 
            HashSet<string> speciesSet = new HashSet<string>(); 
            foreach (Animal animal in animals) 
            { 
                speciesSet.Add(animal.Species); 
            }
            List<string> speciesList = new List<string>(speciesSet); 
            Console.WriteLine("Species in the list:"); 
            foreach (string species in speciesList) 
            {
                Console.WriteLine(species); 
            } 
            return speciesList;
        }
    }
}
