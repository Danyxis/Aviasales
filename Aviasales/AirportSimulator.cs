using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Aviasales
{
    public class AirportSimulator // Класс моделирования работы аэропорта
    {
        private DateTime startSimulationTime; // Начальное время симуляции
        private DateTime currentSimulationTime; // Текущее время симуляции

        public List<RunwayData> runwaysData = new List<RunwayData>(); // Список данных о полосах взлёта и посадки

        private RequestsFlowManager requestsFlowManager; // Управление потоком запросов

        private Dispatcher dispatcher; // Диспетчер

        private RoutesSchedule routesSchedule; // Расписание маршрутов авиарейсов
        
        private List<AirportRequest> requests = new List<AirportRequest>(); // Список запросов

        public List<AirRoute> routes = new List<AirRoute>(); // Список маршрутов авиарейсов

        public List<AirRequestData> requestsData = new List<AirRequestData> { }; // Список данных о запросах
        public DateTime CurrentSimulationTime { get => currentSimulationTime; set => currentSimulationTime = value; } // Свойство текущего времени симуляции

        public AirportSimulator(SimulationConfig config) // Конструктор
        {
            // Инициализирует компоненты симуляции
            requestsFlowManager = new RequestsFlowManager(config); 

            CurrentSimulationTime = startSimulationTime = config.StartDateTime;
            dispatcher = new Dispatcher(startSimulationTime, config.RunwaysCount);
            routesSchedule = new RoutesSchedule(config.RequestsCount, startSimulationTime, config.FinishDateTime);

            // Генерирует новые запросы и добавляет их к текущим
            requests.AddRange(requestsFlowManager.GenerateRequests(routesSchedule.GetRoutes(), config.RequestsCount));
            routes = new List<AirRoute>();
            foreach (var r in routesSchedule.GetRoutes())
            {
                routes.Add(r);
            }
        }

        public void SimulateStep(TimeSpan delta) // Моделирует шаг симуляции
        {
            // Переводим запросы в объекты представления данных
            requestsData = requests.Select(requests => new AirRequestData(requests)).ToList();
            requestsData = requestsData.OrderByDescending(r => r.Status).ToList();

            runwaysData = runwayToData(dispatcher.runways);
            
            CurrentSimulationTime += delta;
            dispatcher.UpdateTime(delta);

            // Обрабатывает запросы и обновляет их
            dispatcher.Dispatch(requests);
        }

        private List<RunwayData> runwayToData(List<Runway> runways) // Список данных для отображения/анализа состояния полос взлёта и посадки в системе симуляции аэропорта
        {
            List<RunwayData> runwaysData = new List<RunwayData>();

            foreach (Runway runway in runways)
            {
                RunwayData data = new RunwayData();
                data.Id = runway.Id;
                data.Route =  (runway.Route != null) ? runway.Route.ToString() : "";
                data.Status = runway.IsRunwayAvailable() ? "Доступна" : "Занята";
                
                double takeoffsAndLandsCount = (runway.GetTakeoffRequestsCount() + runway.GetLandRequestsCount());
                double landPercentageDouble = (double)runway.GetLandRequestsCount() / takeoffsAndLandsCount;
                data.LandPercentage = landPercentageDouble.ToString();
                double TakeOffPercentageDouble = (double)runway.GetTakeoffRequestsCount() / takeoffsAndLandsCount;
                data.TakeOffPercentage = TakeOffPercentageDouble.ToString();

                runwaysData.Add(data);
            }

            return runwaysData;
        }

        public AirStat GetStats() // Возвращает статистику о состоянии полос и запросов
        {
            return new AirStat(dispatcher.runways, requests);
        }
    }
}