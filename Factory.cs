namespace Factory {

    public interface IIngredientFactory {
        public string GetDough();
        public string GetSause();
        public string GetMeat();
        public string GetTomatoes();
        public string GetVegetable();

        public string GetCheese();

    }


    public class NYIngredientFactory : IIngredientFactory {

        public string GetDough() {
            return "Doughy dough";
        }

        public string GetSause() {
            return "Tasty sause";
        }

        public string GetMeat() {
            return "Medium rare meat";
        }

        public string GetTomatoes() {
            return "Big tomato";
        }

        public string GetVegetable() {
            return "Cucumber";
        }

        public string GetCheese() {
            return "Sweet cheese";
        }
    }

    public class LAIngredientFactory : IIngredientFactory {

        public string GetDough() {
            return "Crisy dough";
        }

        public string GetSause() {
            return "Spicy sause";
        }

        public string GetMeat() {
            return "Sausage";
        }

        public string GetTomatoes() {
            return "Little cherry's";
        }

        public string GetVegetable() {
            return "Onion";
        }

        public string GetCheese() {
            return "Sticky cheese";
        }
    }

    public abstract class Pizza {
        public IIngredientFactory ingredientFactory;
        public string name;

        public string dough;
        public string sause;
        public string meat;
        public string tomatoes;
        public string vegetable;
        public string cheese;

        public abstract void Preparing();

        public void Baking() {
            Console.WriteLine("Baking pizza...");
            Thread.Sleep(100);
            Console.WriteLine("Done baking");
        }

        public void Cuting() {
            Console.WriteLine("Cutting pizza...");
            Thread.Sleep(100);
            Console.WriteLine("Done cutting");
        }

        public void Boxing() {
            Console.WriteLine("Boxing pizza...");
            Thread.Sleep(100);
            Console.WriteLine("Done boxing");
        }

    }

    public class CheesePizza : Pizza {

        public CheesePizza(IIngredientFactory ingredientFactory) {
            this.ingredientFactory = ingredientFactory;
            name = "Cheese Pizza";
        }

        public override void Preparing() {
            Console.WriteLine("Preparing cheese pizza...");
            Thread.Sleep(100);
            dough = ingredientFactory.GetDough();
            sause = ingredientFactory.GetSause();
            meat = ingredientFactory.GetMeat();
            tomatoes = ingredientFactory.GetTomatoes();
            vegetable = ingredientFactory.GetVegetable();
            Console.WriteLine("Done preparing cheese pizza");
        }
    }

    public class PeperoniPizza : Pizza {

        public PeperoniPizza(IIngredientFactory ingredientFactory) {
            this.ingredientFactory = ingredientFactory;
            name = "Peperoni pizza";
        }

        public override void Preparing() {
            Console.WriteLine("Preparing some peperoni...");
            Thread.Sleep(100);
            dough = ingredientFactory.GetDough();
            sause = ingredientFactory.GetSause();
            meat = ingredientFactory.GetMeat();
            tomatoes = ingredientFactory.GetTomatoes();
            vegetable = ingredientFactory.GetVegetable();
            Console.WriteLine("Done preparing peperoni");
        }

    }


    public class GreekPizza : Pizza {

        public GreekPizza(IIngredientFactory ingredientFactory) {
            this.ingredientFactory = ingredientFactory;
            name = "Greek Pizza";
        }

        public override void Preparing() {
            Console.WriteLine("Preparing some greek...");
            Thread.Sleep(100);
            dough = ingredientFactory.GetDough();
            sause = ingredientFactory.GetSause();
            meat = ingredientFactory.GetMeat();
            tomatoes = ingredientFactory.GetTomatoes();
            vegetable = ingredientFactory.GetVegetable();
            Console.WriteLine("Done greek 0_o");
        }


    }


    public abstract class PizzaStore {
        public abstract Pizza OrderPizza(string type);
    }


    public class NYPizzaStore : PizzaStore {

        IIngredientFactory ingredientFactory = new NYIngredientFactory();

        public override Pizza OrderPizza(string type) {
            Pizza pizza;

            if (type == "Cheese pizza")
                pizza = new CheesePizza(ingredientFactory);
            else if (type == "Peperoni pizza")
                pizza = new PeperoniPizza(ingredientFactory);
            else
                pizza = new GreekPizza(ingredientFactory);


            Console.WriteLine("New York is baking pizza for you!");
            pizza.Preparing();
            pizza.Cuting();
            pizza.Boxing();
            Console.WriteLine("Have a good day!");
            return pizza;
        }

    }

    public class LAPizzaStore : PizzaStore {

        IIngredientFactory ingredientFactory = new LAIngredientFactory();

        public override Pizza OrderPizza(string type) {
            Pizza pizza;

            if (type == "Cheese pizza")
                pizza = new CheesePizza(ingredientFactory);
            else if (type == "Peperoni pizza")
                pizza = new PeperoniPizza(ingredientFactory);
            else
                pizza = new GreekPizza(ingredientFactory);


            Console.WriteLine("Los Angeles is baking pizza for you!");
            pizza.Preparing();
            pizza.Cuting();
            pizza.Boxing();
            Console.WriteLine("Have a good day!");
            return pizza;
        }

    }


    class Factory {
        static void Main() {
            PizzaStore NYStore = new NYPizzaStore();
            PizzaStore LAStore = new LAPizzaStore();

            NYStore.OrderPizza("Cheese pizza");

            NYStore.OrderPizza("Peperoni pizza");

            LAStore.OrderPizza("Greek pizza");
        }
    }

}

