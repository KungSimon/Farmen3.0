using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmen2._0
{
    internal class AnimalManager
    {
        List<Animal> animals = new List<Animal>();
        public AnimalManager()
        {
            //AnimalManager animalManager = new AnimalManager();
            Animal animal1 = new Animal("Olle", "Pig");
            animal1.AddCropType("Grain");
            animal1.AddCropType("Grass");
            animal1.AddCropType("Cucumber plant");
            Animal animal2 = new Animal("Olle", "Pig");
            animal2.AddCropType("Grain");
            animal2.AddCropType("Grass");
            animal2.AddCropType("Cucumber plant");
            Animal animal3 = new Animal("Olle", "Pig");
            animal3.AddCropType("Grain");
            animal3.AddCropType("Grass");
            animal3.AddCropType("Cucumber plant");
            Animal animal4 = new Animal("Olle", "Pig");
            animal4.AddCropType("Grain");
            animal4.AddCropType("Grass");
            animal4.AddCropType("Cucumber plant");
            Animal animal5 = new Animal("Olle", "Pig");
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
            Animal animal8 = new Animal("Pelle", "Cow");
            animal8.AddCropType("Grain");
            animal8.AddCropType("Grass");
            Animal animal9 = new Animal("Pelle", "Cow");
            animal9.AddCropType("Grain");
            animal9.AddCropType("Grass");
            Animal animal10 = new Animal("Pelle", "Cow");
            animal10.AddCropType("Grain");
            animal10.AddCropType("Grass");
            Animal animal11 = new Animal("Pelle", "Cow");
            animal11.AddCropType("Grain");
            animal11.AddCropType("Grass");
            Animal animal12 = new Animal("Rut", "Chicken");
            animal12.AddCropType("Seed");
            Animal animal13 = new Animal("Rut", "Chicken");
            animal13.AddCropType("Seed");
            Animal animal14 = new Animal("Rut", "Chicken");
            animal14.AddCropType("Seed");
            Animal animal15 = new Animal("Rut", "Chicken");
            animal15.AddCropType("Seed");
            Animal animal16 = new Animal("Rut", "Chicken");
            animal16.AddCropType("Seed");
            Animal animal17 = new Animal("Pernilla", "Sheep");
            animal17.AddCropType("Grass");
            animal17.AddCropType("Cucumber plant");
            Animal animal18 = new Animal("Pernilla", "Sheep");
            animal18.AddCropType("Grass");
            animal18.AddCropType("Cucumber plant");
            Animal animal19 = new Animal("Pernilla", "Sheep");
            animal19.AddCropType("Grass");
            animal19.AddCropType("Cucumber plant");
            Animal animal20 = new Animal("Pernilla", "Sheep");
            animal20.AddCropType("Grass");
            animal20.AddCropType("Cucumber plant");
            Animal animal21 = new Animal("Pernilla", "Sheep");
            animal21.AddCropType("Grass");
            animal21.AddCropType("Cucumber plant");
            Animal animal22 = new Animal("Pernilla", "Sheep");
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
                     
                        break;

                    case "3":
                        Console.WriteLine("Choose an animal to remove by Id");
                        int id = int.Parse(Console.ReadLine());
                        RemoveAnimal(id);
                        break;

                    case "4":
                        Console.WriteLine("Choose an animal to feed by Id");
                        int animalId = int.Parse(Console.ReadLine());

                        Console.WriteLine("Choose a crop by Id to feed with:");
                        CropManager cropManager = new CropManager();
                        List<Crop> crops = cropManager.GetCrops();

                        for (int i = 0; i < crops.Count; i++)
                        {
                            Console.WriteLine(crops[i].GetDescription());
                        }

                        int cropId = int.Parse(Console.ReadLine());

                        Animal selectedAnimal = animals.FirstOrDefault(animal => animal.Id == animalId);

                        if (selectedAnimal != null)
                        {
                            Crop selectedCrop = crops.FirstOrDefault(crop => crop.Id == cropId);

                            if (selectedCrop != null)
                            {
                                Console.WriteLine("How much " + selectedCrop.CropType + " do you want to use?");
                                int quantity = int.Parse(Console.ReadLine());
                                FeedAnimal(selectedAnimal, selectedCrop, quantity);
                            }
                            else
                            {
                                Console.WriteLine("Invalid crop ID. Please select a valid crop.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid animal ID. Please select a valid animal.");
                        }
                        break;

                    case "9":
                        animalMenu = false;
                        break;

                }
            }


        }

        private void FeedAnimal(Animal animal, Crop crop, int quantity)
        {
            animal.Feed(crop, quantity);


            /*if (quantity > 0)
            {
                if (quantity <= crop.Quantity)
                {
                    crop.Quantity -= quantity;
                    animal.Feed(crop, quantity);

                    Console.WriteLine($"{animal.Species} has been fed with {quantity} units of {crop.CropType}.");
                }
                else
                {
                    Console.WriteLine($"Not enough {crop.CropType} available. Available quantity: {crop.Quantity}");
                }
            }
            else if (quantity == 0)
            {
                Console.WriteLine("Request canceled.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please select a valid quantity.");
            }*/
        }

        private bool AddAnimal()
        {
            
            Console.WriteLine("What is the animals name");
            string name = Console.ReadLine();
            Console.WriteLine("What species is the animal");
            string species = Console.ReadLine();
            /*Console.WriteLine("What does the animal eat?");
            bool AddSpec = true;
            while (AddSpec)
            {
                Console.WriteLine("What does the animal eat?");
                string input = Console.ReadLine();
                if (input == "")
                {
                    Console.WriteLine("Add a speciality.");
                    string speciality = Console.ReadLine();

                    worker.Specialties.Add(speciality);
                }
                else if (input == "N")
                {
                    AddSpec = false;
                }
                else if (input != "Y" || input != "N")
                {
                    Console.WriteLine("Invalid Input. You need to choose Y or N");
                }

            }
            workers.Add(worker);
            string acceptableCropTypes = Console.ReadLine();*/
            Animal animalToAdd = new Animal(name, species);
            //AddAnimal();
            return true;
        }

        private void ViewAnimals()
        {
            Console.WriteLine();
            foreach (Animal animals in animals)
            {

                animals.GetDescription();
            }

        }
        private void RemoveAnimal(int id)
        {
            for (int i = 0; i < animals.Count; i++)
            {
                if (animals[i].Id == id)
                {
                    Console.WriteLine($"Animal {animals[i].Id} succesfully removed.");
                    animals.Remove(animals[i]);
                }
            }

        }
        public List<Animal> GetAnimals()
        {
            return animals;
        }
    }
}
