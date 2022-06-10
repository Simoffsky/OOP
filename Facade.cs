namespace Facade {

    public class Amplifier {
        int volume = 0;
        bool state;
        public void On() {
            Console.WriteLine("Turn on the amplifier");
            state = false;
        }

        public void Off() {
            Console.WriteLine("Turn off the amplifier");
            state = true;
        }

        public void SetVolume(int volume) {
            this.volume = volume;
        }
    }

    public class DvdPlayer {
       public void On() {
            Console.WriteLine("Turn on the DVD...");
            Thread.Sleep(120);
        }

        public void Off() {
            Console.WriteLine("Turn of the DVD...");
            Thread.Sleep(120);
        }

        public void Play(string name) {
            Console.WriteLine($"Turning on the {name}");
        }
    }

    public class PopcornPopper {

        public void On() {
            Console.WriteLine("Turn on the popcorn machine...");
            Thread.Sleep(120);
        }

        public void Off() {
            Console.WriteLine("Turn off the popcorn machine...");
            Thread.Sleep(120);
        }
        
        public void Pop() {
            Console.WriteLine("Popcorn is popping...");
            Thread.Sleep(120);
        }
    }

    public class Lights {
        public void On() {
            Console.WriteLine("Turn on the light...");
        }

        public void Off() {
            Console.WriteLine("Turn off the light...");
        }
    }



    public class HomeCinemaFacade {
        Amplifier amplifier;
        DvdPlayer dvdPlayer;
        PopcornPopper popcornPopper;
        Lights lights;

        public HomeCinemaFacade(Amplifier amplifier, DvdPlayer dvdPlayer, PopcornPopper popcornPopper, Lights lights) {
            this.amplifier = amplifier;
            this.dvdPlayer = dvdPlayer;
            this.popcornPopper = popcornPopper;
            this.lights = lights;
        }

        public void WatchMovie(string name) {
            this.amplifier.On();
            this.dvdPlayer.On();
            this.popcornPopper.On();
            this.popcornPopper.Pop();
            this.lights.On();

            this.amplifier.SetVolume(100);
            this.dvdPlayer.Play(name);
        }
    }


    class Facade {
        static void Main() {
            Amplifier amplifier = new Amplifier();
            DvdPlayer dvdPlayer = new DvdPlayer();
            PopcornPopper popcornPopper = new PopcornPopper();
            Lights lights = new Lights();
            HomeCinemaFacade theatre = new HomeCinemaFacade(amplifier, dvdPlayer, popcornPopper, lights);

            theatre.WatchMovie("Dune");
        }
    }
}