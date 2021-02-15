using System;
using System.Collections.Generic;
using System.Linq;

namespace CS_Human
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Human bob = new Human("Bob", 10, 2, 9, 200);
            Human james = new Human("James", 4, 10, 8, 100);
            bob.Attack(james);
            Console.WriteLine(james.Name + "'s health is now: " + james.Health);

            var firstNinja = new Ninja();
            var firstBuffet = new Buffet();

            while(firstNinja.IsFull != true)
            {
                var food = firstBuffet.Serve();
                firstNinja.Eat(food);
            }

            firstNinja.Eat(firstBuffet.Serve());
        }
    }
    class Human
    {
        // Fields for Human
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        public int Health;

        // add a public "getter" property to access health
        public int HealthStatus
        {
            get
            {
                return Health;
            }
        }


        // Add a constructor that takes a value to set Name, and set the remaining fields to default values
        public void Stats(string name)
        {
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            Health = 100;
        }

        // Add a constructor to assign custom values to all fields
        // public string setStats(string name, int strength, int intel, int dex, int health)
        public Human(string name, int strength, int intelligence, int dexterity, int health)
        {
            Name = name;
            Strength = strength;
            Intelligence = intelligence;
            Dexterity = dexterity;
            Health = health;
        }

        // Build Attack method
        public void Attack(Human target)
        {
            target.Health -= this.Strength * 5;
        }
    }

    public class Food
    {
        public string Name;
        public int Calories;
        // Foods can be Spicy and/or Sweet
        public bool IsSpicy;
        public bool IsSweet;
        // add a constructor that takes in all four parameters: Name, Calories, IsSpicy, IsSweet
        public Food(string nameParam, int calParam, bool isSpicyParam, bool isSweetParam)
        {
            Name = nameParam;
            Calories = calParam;
            IsSpicy = isSpicyParam;
            IsSweet = isSweetParam;
        }
    }

    public class Buffet
    {
        public List<Food> Menu;

        //constructor
        public Buffet()
        {
            Menu = new List<Food>()
            {
                new Food("Rice", 600, false, false),
                new Food("Beans", 500, false, false),
                new Food("Kimchi", 200, false, true),
                new Food("Nasi Goreng", 1600, true, true),
                new Food("Mi Goreng", 1200, true, true),
                new Food("Cereal", 800, true, false),
                new Food("appl", 100, true, false)
            };
        }

        public Food Serve()
        {
            var rand = new Random();
            int idx = rand.Next(0, Menu.Count);
            Console.WriteLine(Menu[idx]);
            return Menu[idx];
        }
    }

    public class Ninja
    {
        private int calorieIntake;
        public List<Food> FoodHistory;

        // add a constructor
        public Ninja()
        {
            calorieIntake = 0;
            FoodHistory = new List<Food>();
        }

        // add a public "getter" property called "IsFull"
        public bool IsFull {
            get{
                if(calorieIntake > 2000)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        // build out the Eat method
        public void Eat(Food item)
        {
            if(IsFull)
            {
                Console.WriteLine("The ninja is full and can't eat anymore!");
            }
            else
            {
                // adds calorie value to ninja's total calorieIntake
                calorieIntake += item.Calories;
                // adds the randomly selected Food object to ninja's FoodHistory list
                FoodHistory.Add(item);
                // writes the Food's Name - and if it is spicy/sweet to the console
                Console.WriteLine($"The food is {item.Name}; Spicy: {item.IsSpicy}; Sweet: {item.IsSweet}");
            }
        }
    }
}
