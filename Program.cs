using System;

namespace CS_Human
{
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
            get{
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
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Human bob = new Human("Bob", 10, 2, 9, 200);
            Human james = new Human("James", 4, 10, 8, 100);
            bob.Attack(james);
            Console.WriteLine(james.Name + "'s health is now: " + james.Health);
        }
    }
}
