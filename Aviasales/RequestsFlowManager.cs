using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Aviasales
{
    public class RequestsFlowManager // Класс генерации запросов на основе предоставленных маршрутов авиарейсов
    {
        private NormalDistributionGenerator derivationGenerator; // Экземпляр генератора случайных чисел с нормальным распределением
        private Airport localAirport = new Airport("Novosibirsk"); // Локальный аэропорт, установленный в коде как "Novosibirsk"
        private int derivation; // Переменная для хранения значения отклонения

        // TODO: Добавить ограничения на отклонения, установку локального аэропорта.
        public RequestsFlowManager(SimulationConfig config) // Конструктор
        {
            // Устанавливает значение отклонения и создает экземпляр генератора случайных чисел с нормальным распределением
            derivation = config.Derivation;
            derivationGenerator = new NormalDistributionGenerator();
        }

        // Генерирует запросы на основе переданных маршрутов и количества запросов на взлёт/посадку, учитывая отклонения времени отправления и прибытия
        public IEnumerable<AirportRequest> GenerateRequests(List<AirRoute> routes, int requestsCount)
        {
            List<AirportRequest> requests =  new List<AirportRequest>(); // Список запросов на взлёт/посадку
            Random random = new Random(); // Генерация случайных чисел

            while (requests.Count < requestsCount)
            {
                AirRoute route = routes[random.Next(0, routes.Count)];
                AirRoute derivatedRoute = route;
                AirportRequestType requestType; 
                requestType = (route.ArrivePoint.Name == localAirport.Name)? AirportRequestType.Land : AirportRequestType.Takeoff;

                // Генерация отклонения прибытия
                DateTime arriveDeviation = route.ArriveTime.AddMinutes(derivationGenerator.GenerateNumberInRange(-derivation / 2, derivation / 2));
                
                // Генерация отклонения отправления
                DateTime departureDeviation = route.DepartureTime.AddMinutes(derivationGenerator.GenerateNumberInRange(-derivation/2, derivation/ 2));

                derivatedRoute.DepartureTime  = departureDeviation;
                derivatedRoute.ArriveTime = arriveDeviation;
                Console.WriteLine(derivatedRoute.ToString());
                requests.Add(AirportRequestFactory.Create(requestType, derivatedRoute));
            }
            return requests;
        }
    }
}