using System;
using System.Collections.Generic;
using System.Linq;

namespace Aviasales
{
    internal class RoutesAndAirportsGenerator // Класс генерирования аэропортов и маршрутов авиарейсов
    {
        static List<Airport> GenerateAirports()
        {
            List<Airport> airports = new List<Airport> // Список аэропортов
            {
                new Airport("Novosibirsk"),
                new Airport("Heathrow"),
                new Airport("JFK"),
                new Airport("Changi"),
                new Airport("LAX"),
                new Airport("O'Hare"),
                new Airport("Hartsfield-Jackson"),
                new Airport("Dubai International"),
                new Airport("Incheon International"),
                new Airport("Frankfurt Airport"),
                new Airport("Schwechat"),
                new Airport("Sydney Airport"),
                new Airport("Narita International"),
                new Airport("Denver International"),
                new Airport("Hong Kong International"),
                new Airport("Toronto Pearson"),
                new Airport("Beijing Capital International"),
                new Airport("Singapore Changi"),
                new Airport("Amsterdam Schiphol"),
                new Airport("Munich Airport"),
                new Airport("Zurich Airport")
            };
            return airports;
        }

        public static List<AirRoute> GenerateFlights(int flightsCount, DateTime start, DateTime finish) // Генерирует случайные маршруты авиарейсов
        {
            List<Airport> airports = GenerateAirports(); // Список аэропортов
            List<AirRoute> flights = new List<AirRoute>(); // Список маршрутов

            Random random = new Random();

            Airport novosibirskAirport = airports.Find(a => a.Name == "Novosibirsk");

            TimeSpan interval = finish.Subtract(start); // Вычисляет временной интервал между start и finish
            while (flights.Count < flightsCount) // Цикл генерации
            {
                Airport airport = airports[random.Next(0, airports.Count)];
                DateTime departureDateTime = start.AddHours(random.Next(1, (int)interval.TotalHours));
                DateTime arrivalDateTime = departureDateTime.AddHours(random.Next(1, 14));

                if (airport != novosibirskAirport)
                {
                    if (random.Next(2) % 2 == 0)
                    {
                        AirRoute flight = new AirRoute(novosibirskAirport, airport, departureDateTime, arrivalDateTime);
                        flights.Add(flight);
                    }
                    else 
                    {
                        AirRoute flight = new AirRoute(airport, novosibirskAirport, departureDateTime, arrivalDateTime);
                        flights.Add(flight);
                    }
                }
            }
            return flights = flights.OrderBy(f => f.DepartureTime).ToList(); // Список сгенерированных маршрутов, отсортированных по времени отправления в порядке возрастания
        }
    }

    public class RoutesSchedule // Класс расписания авиарейсов 
    {
        private DateTime start; // Временные границы симуляции
        private DateTime finish;
        List<AirRoute> routes; // Список маршрутов авиарейсов
        public RoutesSchedule(int flightsCount, DateTime StartSimulationDateTime, DateTime FinishSimulationDateTime) // Конструктор
        {
            start = StartSimulationDateTime; // Время начала симуляции
            finish = FinishSimulationDateTime; // Время конца симуляции
            routes = new List<AirRoute>(); // Список маршрутов

            foreach (var route in RoutesAndAirportsGenerator.GenerateFlights(flightsCount, start, finish)) // Генерирует маршруты авиарейсов на основе заданных параметров
            { 
                routes.Add(route);
            }
        }

        public List<AirRoute> GetRoutes() // Возвращает список сгенерированных маршрутов авиарейсов
        {
            return routes;
        }
    }
}