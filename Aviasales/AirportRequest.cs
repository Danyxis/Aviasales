using System.Diagnostics;

namespace Aviasales
{
    public interface AirportRequest // Интерфейс запросов взлёта/посадок
    {

        AirportRequest Process(); // Обработка запросов

        bool GetStatus(); // Состояние запроса

        AirportRequest Defer(); // Отложенный запрос 
        
        AirRoute GetAirRoute(); // Маршрут

        int GetDefersCount(); // Кол-во отложенных запросов
    }
}