using System;



namespace Decorator {
    
    public interface IBeverage {
        public string GetDescription();

        public int GetCost();
    }

    public class HouseBlend : IBeverage {
        public string GetDescription() { return "It`s House Blend"; }
        public int GetCost() { return 250; }
    }

    public class DarkRoast : IBeverage {
        public string GetDescription() { return "It's DarkRoast"; }
        public int GetCost() { return 250; }
    }

    public class Decaf : IBeverage {
        public string GetDescription() { return "It's Decaf"; }
        public int GetCost() { return 300; }
    }

    public class Espresso : IBeverage {
        public string GetDescription() { return "It's Espresso"; }
        public int GetCost()  { return 300; }
    }
    public interface ICondiment : IBeverage { }


    public class Milk : ICondiment {
        IBeverage beverage;
        public Milk(IBeverage beverage) {
            this.beverage = beverage;
        }
        public string GetDescription() { return beverage.GetDescription() + " with milk"; }
        public int GetCost() { return beverage.GetCost() + 20; }
    }

    public class Mocha : ICondiment {
        IBeverage beverage;
        public Mocha(IBeverage beverage) {
            this.beverage = beverage;
        }
        public string GetDescription() {return beverage.GetDescription() + " with mocha"; }
        public int GetCost() { return beverage.GetCost() + 30; }
    }


    public class Soy : ICondiment {
        IBeverage beverage;
        public Soy(IBeverage beverage) {
            this.beverage = beverage;
        }
        public string GetDescription() { return beverage.GetDescription() + " with soy"; }
        public int GetCost() {return beverage.GetCost() + 10; }
    }


    public class Whip : ICondiment {
        IBeverage beverage;
        public Whip(IBeverage beverage) {
            this.beverage = beverage;
        }
        public string GetDescription() { return beverage.GetDescription() + " with whip"; }
        public int GetCost() { return beverage.GetCost() + 40; }
    }


    class Program {
        public static void Main() {
            IBeverage beverage = new Soy(new Milk(new Espresso()));

            Console.WriteLine(beverage.GetDescription());
            Console.WriteLine(beverage.GetCost());
        }
    }
}