using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM_1
{
    // Abstract product class
    abstract class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public abstract string Examine();
        public abstract string Use();
    }

    // Product types
    class Drink : Product
    {
        public string Flavor { get; set; }

        public override string Examine()
        {
            return $"ID: {Id}, Name: {Name}, Cost: {Price} kr, Flavor: {Flavor}";
        }

        public override string Use()
        {
            return $"Did you hear about diabetes? Enjoy your {Name} drink!";
        }
    }

    class Snack : Product
    {
        public string Description { get; set; }

        public override string Examine()
        {
            return $"ID: {Id}, Name: {Name}, Cost: {Price} kr, Description: {Description}";
        }

        public override string Use()
        {
            return $"Enjoy your {Description}!";
        }
    }

    class Chocolate : Product
    {
        public string Type { get; set; }

        public override string Examine()
        {
            return $"ID: {Id}, Name: {Name}, Cost: {Price} kr, Type: {Type}";
        }

        public override string Use()
        {
            return $"You'd have to run 100 meters for each {Name} you eat!";
        }
    }
}
