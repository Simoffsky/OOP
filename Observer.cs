using System;
using System.Collections.Generic;
namespace Weather {

    interface ISubject {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }



    class WeatherData : ISubject {
        private List<IObserver> observers = new List<IObserver>();
        public void RegisterObserver(IObserver observer) {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer) {
            observers.Remove(observer);
        }

        public void NotifyObservers() {
            foreach (var observer in observers) {
                observer.Update(GetTemperature(), GetHumidity(), GetPressure());
            }
        }

        private Random rnd = new Random();
        public double GetTemperature() {
            return rnd.NextDouble();
        }

        public double GetHumidity() {
            return rnd.NextDouble();
        }

        public double GetPressure() {
            return rnd.NextDouble();
        }

        public void MeasurementsChanged() {
            NotifyObservers();
        }
    }


    interface IObserver {
        void Update(double temperature, double humidity, double pressure);
        void Display();

    }


    class CurrentConditionsDisplay : IObserver {
        private double _temperature;
        private double _humidity;
        private double _pressure;


        public CurrentConditionsDisplay(ISubject subject) {
            subject.RegisterObserver(this);
        }

        public void Update(double temperature, double humidity, double pressure) {
            _temperature = temperature;
            _humidity = humidity;
            _pressure = pressure;
            Display();
        }

        public void Display() {
            Console.WriteLine("**********");
            Console.WriteLine($"Temperature is about: {_temperature}");
            Console.WriteLine($"Humidity is about: {_humidity}");
            Console.WriteLine($"Pressure is about : {_pressure}");
            Console.WriteLine("**********");
        }
    }

    class StatisticsDisplay : IObserver {
        private double _temperature;
        private double _humidity;
        private double _pressure;

        public StatisticsDisplay(ISubject subject) {
            subject.RegisterObserver(this);

        }
        public void Update(double temperature, double humidity, double pressure) {

            _temperature = temperature;
            _humidity = humidity;
            _pressure = pressure;
            Display();
        }

        private Random rnd = new Random();
        public void Display() {
            Console.WriteLine("**********");
            Console.WriteLine($"Temperature has {rnd.Next(0, 50)}% of change!");
            Console.WriteLine($"Humidity has {rnd.Next(0, 50)}% of change!");
            Console.WriteLine($"Pressure has {rnd.Next(0, 50)}% of change!");
            Console.WriteLine("**********");
        }
    }


    class ForecastDisplay : IObserver {
        private double _temperature;
        private double _humidity;
        private double _pressure;
        public ForecastDisplay(ISubject subject) {
            subject.RegisterObserver(this);
        }
        public void Update(double temperature, double humidity, double pressure) {
            _temperature = temperature;
            _humidity = humidity;
            _pressure = pressure;
            Display();
        }

        private Random rnd = new Random();
        public void Display() {
            Console.WriteLine("**********");
            Console.WriteLine($"Temperature will be about: {_temperature + rnd.NextDouble() }");
            Console.WriteLine($"Humidity is will be about: {_humidity + rnd.NextDouble()}");
            Console.WriteLine($"Pressure is will be about : {_pressure + rnd.NextDouble()}");
            Console.WriteLine("**********");

        }
    }
    internal class Program {

        static void Main(string[] args) {

            var weatherData = new WeatherData();
            var currentConditionsDisplay = new CurrentConditionsDisplay(weatherData);
            var statisticsDisplay = new StatisticsDisplay(weatherData);
            var forecastDisplay = new ForecastDisplay(weatherData);
            weatherData.MeasurementsChanged();
        }
    }
}
