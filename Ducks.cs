using System;
namespace CurrentTask {
    interface IQuackStrategy {

        void quack() {
            Console.WriteLine("Hi!");
        }

    }


    class NormalQuack : IQuackStrategy {
        public void quack() {
            Console.WriteLine("Quack!");
        }
    }
    class CuteQuack : IQuackStrategy {
        public void quack() {
            Console.WriteLine("Cute Quack!~");
        }
    }

    class SilentQuack : IQuackStrategy {
        public void quack() {

        }
    }

    interface ISwimStrategy {
        void swim();
    }

    class NormalSwim : ISwimStrategy {
        public void swim() {
            Console.WriteLine("Some swimming..");
        }
    }

    class CuteSwim : ISwimStrategy {
        public void swim() {
            Console.WriteLine("Some cute swimming..");
        }
    }

    class NoSwim : ISwimStrategy {
        public void swim() {

        }
    }

    interface IFlyStrategy {
        void fly();
    }

    class NormalFly : IFlyStrategy {
        public void fly() {
            Console.WriteLine("Some duck flying~");
        }
    }

    class NoFly : IFlyStrategy {
        public void fly() {

        }
    }

    interface IDisplayStrategy {
        void display();
    }

    class NormalDisplay : IDisplayStrategy {
        public void display() {
            Console.WriteLine("Some duck display");
        }
    }

    class Duck {
        private IQuackStrategy quackStrategy;
        private ISwimStrategy swimStrategy;
        private IFlyStrategy flyStrategy;
        private IDisplayStrategy displayStrategy;


        public Duck(IQuackStrategy quackStrategy, ISwimStrategy swimStrategy, IFlyStrategy flyStrategy, IDisplayStrategy displayStrategy) {
            this.quackStrategy = quackStrategy;
            this.swimStrategy = swimStrategy;
            this.flyStrategy = flyStrategy;
            this.displayStrategy = displayStrategy;
        }
        public void Quack() {
            quackStrategy.quack();
        }

        public void Swim() {
            swimStrategy.swim();
        }

        public void Fly() {
            flyStrategy.fly();
        }

        public void Display() {
            displayStrategy.display();
        }
    }

    class Program {

        //static int a = 50;

        static void TestDuck(Duck duck) {
            Console.WriteLine("***Begin Testing***");
            duck.Quack();
            duck.Swim();
            duck.Fly();
            duck.Display();
            Console.WriteLine("---Duck Test success---");
            Console.WriteLine();
        }






        static void Main() {

            TestDuck(new Duck(new NormalQuack(), new NoSwim(), new NormalFly(), new NormalDisplay()));


        }
    }
}