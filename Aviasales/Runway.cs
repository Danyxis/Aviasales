using System;

namespace Aviasales
{
    public class Runway // Класс взлётно-посадочной полосы
    {
        private DateTime startTime; // Начальное время
        private DateTime currentTime; // Текущее время
        private TimeSpan occupyTime; // Время, в течение которого полоса остается занятой (в случае, если она занята)
        private AirRoute route; // Маршрут, который использует полосу в данный момент времени
        public void UpdateTime(TimeSpan delta) // Обновляет состояние времени для взлетно-посадочной полосы
        {
            currentTime += delta;
            if (!IsAvailable) // Проверяет, занята ли взлетно-посадочная полоса
            {
                // Обновляем состояние полосы и снимаем блокировку с неё, если время ожидания вышло
                // TODO: добавить время на сами взлёт и посадку
                Console.WriteLine("Взлётно-посадочная полоса " + Id + " занята на " + occupyTime); // Полоса с идентификатором Id занята,
                                                                                                     // сколько времени еще она будет занята (occupyTime)
                occupyTime -= delta; // Уменьшает оставшееся время занятости полосы
                if (occupyTime < TimeSpan.FromMinutes(0)) // Проверяет, истекло ли время занятости полосы
                {
                    Console.WriteLine("Взлётно-посадочная полоса " + Id + " обрабатывает маршрут и доступна уже сейчас"); 
                    // Полоса с идентификатором Id освободилась, теперь доступна для использования
                    occupyTime = TimeSpan.FromMinutes(0);
                    route = null;
                    IsAvailable = true;
                }
            }
        }
        public int Id { get; set; } // Свойство Id
        private bool IsAvailable { get; set; } // Свойство для обозначения доступности взлетно-посадочной полосы
        private int LandRequestCount { get; set; } // Свойство для подсчета количества запросов на посадку на данной полосе
        private int TakeoffRequestCount { get; set; } // Свойство для подсчета количества запросов на взлет с данной полосы
        public AirRoute Route { get => route; set => route = value; } // Свойство, содержащее маршрут, связанный с данной взлетно-посадочной полосой

        private static int idStatic = 0; // Статическая переменная для генерации уникального идентификатора полосы
        public Runway(DateTime start) // Конструктор
        {
            currentTime = startTime = start;
            Id = idStatic++;
            IsAvailable = true;
            LandRequestCount = 0;
            TakeoffRequestCount = 0;
        }
        public bool IsRunwayAvailable() // Возвращает текущее состояние доступности полосы
        {
            return IsAvailable;
        }

        public int GetLandRequestsCount() // Возвращает количество запросов на посадку, которые были обработаны или запланированы для данной полосы
        { 
            return LandRequestCount;
        }

        public int GetTakeoffRequestsCount() // Возвращает количество запросов на взлет, которые были обработаны или запланированы для данной полосы 
        {
            return TakeoffRequestCount;
        }

        public void Occupy(AirportRequest req) // Занимает взлетно-посадочную полосу определенным запросом
        { 
            if (!IsAvailable) // Проверяет, доступна ли взлетно-посадочная полоса
            {
                return;
            }

            Route = req.GetAirRoute(); // Устанавливает маршрут (Route) в соответствии с маршрутом запроса
            Console.WriteLine("Взлётно-посадочная полоса " + Id + " занята воздушным маршрутом " + req.GetAirRoute().ToString());
            IsAvailable = false; // Помечает полосу как занятую
            if (req is TakeoffRequest) 
            {
                // Вычисляет время блокировки для запроса на взлёт (разница между текущим временем и временем отправления в маршруте)
                occupyTime = req.GetAirRoute().DepartureTime.Subtract(currentTime);
                TakeoffRequestCount++; // Увеличивает счётчик запросов на взлёт
            } else if (req is LandRequest) 
            {
                // Вычисляеn время блокировки для запроса на посадку (разница между текущим временем и временем прибытия в маршруте)
                occupyTime = req.GetAirRoute().ArriveTime.Subtract(currentTime);
                LandRequestCount++; // Увеличивает счётчик запросов на посадку
            }
        }        
    }
}