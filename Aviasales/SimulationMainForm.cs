using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Aviasales
{
    public class SimulationMainForm : Form // Представляет главное окно моделирования (симуляции) работы аэропорта
    {
        private Timer timer = new Timer();
        private double timeScale;
        private AirportSimulator airportSimulator;
        private TabControl TabControl;
        private TabPage RunwaysPage;
        private TabPage Schedule;
        private TabPage Requests;
        private DataGridView RunwaysDataGridView;

        private System.ComponentModel.IContainer components;
        private BindingSource runwayDataBindingSource;
        private Label TimeHeaderLabel;
        private Label TimeLabel;
        private DataGridView ScheduleDataGridView;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn routeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn takeOffPercentageDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn landPercentageDataGridViewTextBoxColumn;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn departureTimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn arriveTimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn departurePointDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn arrivePointDataGridViewTextBoxColumn;
        private BindingSource airRouteBindingSource;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn defersDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn statusDataGridViewCheckBoxColumn;
        private BindingSource airRequestDataBindingSource;
        private Button StartStopButton;
        private Button FinishButton;

        public SimulationMainForm(SimulationConfig config) // Конструктор инициализирует главное окно симуляции работы аэропорта с параметрами и таймером
        {
            timeScale = config.SimulationCoefficient;
            InitializeComponent();
            // Инициализация симулятора аэропорта
            airportSimulator = new AirportSimulator(config);

            airRouteBindingSource.DataSource = airportSimulator.routes;

            timer.Interval = 1000; // Интервал в миллисекундах, умноженный на timeScale
            timer.Tick += Timer_Tick;

            timer.Start(); // Запуск таймера
        }

        private void Timer_Tick(object sender, EventArgs e) // Метод, обрабатывающий событие таймера и обновляющий информацию в интерфейсе
        {
            TimeLabel.Text = airportSimulator.CurrentSimulationTime.ToString();
            runwayDataBindingSource.DataSource = airportSimulator.runwaysData;
            airRequestDataBindingSource.DataSource = airportSimulator.requestsData;
            // Останавливаем секундомер и измеряем прошедшее время с предыдущего тика
            double elapsedTime = 1;

            // Вызываем метод симуляции и передаем изменение времени
            airportSimulator.SimulateStep(TimeSpan.FromSeconds(elapsedTime * timeScale));
        }

        private void InitializeComponent() // Метод, инициализирующий компоненты формы для визуального представления данных в симуляции работы аэропорта
        {
            this.components = new System.ComponentModel.Container();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.RunwaysPage = new System.Windows.Forms.TabPage();
            this.RunwaysDataGridView = new System.Windows.Forms.DataGridView();
            this.Schedule = new System.Windows.Forms.TabPage();
            this.ScheduleDataGridView = new System.Windows.Forms.DataGridView();
            this.Requests = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.TimeHeaderLabel = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.StartStopButton = new System.Windows.Forms.Button();
            this.FinishButton = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.landPercentageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.runwayDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.departureTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.arriveTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departurePointDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.arrivePointDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.airRouteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.defersDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.airRequestDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TabControl.SuspendLayout();
            this.RunwaysPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RunwaysDataGridView)).BeginInit();
            this.Schedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScheduleDataGridView)).BeginInit();
            this.Requests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.runwayDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.airRouteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.airRequestDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControl (Управление вкладками)
            // 
            this.TabControl.Controls.Add(this.RunwaysPage);
            this.TabControl.Controls.Add(this.Schedule);
            this.TabControl.Controls.Add(this.Requests);
            this.TabControl.Location = new System.Drawing.Point(-3, 42);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(784, 702);
            this.TabControl.TabIndex = 0;
            // 
            // RunwaysPage (Страница взлётно-посадочных полос)
            // 
            this.RunwaysPage.Controls.Add(this.RunwaysDataGridView);
            this.RunwaysPage.Location = new System.Drawing.Point(4, 25);
            this.RunwaysPage.Name = "RunwaysPage";
            this.RunwaysPage.Padding = new System.Windows.Forms.Padding(3);
            this.RunwaysPage.Size = new System.Drawing.Size(776, 673);
            this.RunwaysPage.TabIndex = 0;
            this.RunwaysPage.Text = "Полосы";
            this.RunwaysPage.UseVisualStyleBackColor = true;
            // 
            // RunwaysDataGridView (Представление в виде сетки данных о взлётно-посадочных полосах)
            // 
            this.RunwaysDataGridView.AllowUserToOrderColumns = true;
            this.RunwaysDataGridView.AutoGenerateColumns = false;
            this.RunwaysDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.RunwaysDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RunwaysDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.landPercentageDataGridViewTextBoxColumn});
            this.RunwaysDataGridView.DataSource = this.runwayDataBindingSource;
            this.RunwaysDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RunwaysDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.RunwaysDataGridView.Location = new System.Drawing.Point(3, 3);
            this.RunwaysDataGridView.Name = "RunwaysDataGridView";
            this.RunwaysDataGridView.RowHeadersWidth = 62;
            this.RunwaysDataGridView.RowTemplate.Height = 28;
            this.RunwaysDataGridView.Size = new System.Drawing.Size(770, 667);
            this.RunwaysDataGridView.TabIndex = 0;
            // 
            // Schedule (Расписание)
            // 
            this.Schedule.Controls.Add(this.ScheduleDataGridView);
            this.Schedule.Location = new System.Drawing.Point(4, 25);
            this.Schedule.Name = "Schedule";
            this.Schedule.Padding = new System.Windows.Forms.Padding(3);
            this.Schedule.Size = new System.Drawing.Size(776, 673);
            this.Schedule.TabIndex = 1;
            this.Schedule.Text = "Расписание";
            this.Schedule.UseVisualStyleBackColor = true;
            // 
            // ScheduleDataGridView (Представление таблицы данных расписания)
            // 
            this.ScheduleDataGridView.AllowUserToOrderColumns = true;
            this.ScheduleDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScheduleDataGridView.AutoGenerateColumns = false;
            this.ScheduleDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ScheduleDataGridView.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ScheduleDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ScheduleDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.departureTimeDataGridViewTextBoxColumn,
            this.arriveTimeDataGridViewTextBoxColumn,
            this.departurePointDataGridViewTextBoxColumn,
            this.arrivePointDataGridViewTextBoxColumn});
            this.ScheduleDataGridView.DataSource = this.airRouteBindingSource;
            this.ScheduleDataGridView.Location = new System.Drawing.Point(0, 0);
            this.ScheduleDataGridView.Name = "ScheduleDataGridView";
            this.ScheduleDataGridView.RowHeadersWidth = 62;
            this.ScheduleDataGridView.RowTemplate.Height = 28;
            this.ScheduleDataGridView.Size = new System.Drawing.Size(776, 677);
            this.ScheduleDataGridView.TabIndex = 0;
            // 
            // Requests (Запросы)
            // 
            this.Requests.Controls.Add(this.dataGridView2);
            this.Requests.Location = new System.Drawing.Point(4, 25);
            this.Requests.Name = "Requests";
            this.Requests.Size = new System.Drawing.Size(776, 673);
            this.Requests.TabIndex = 2;
            this.Requests.Text = "Заявки";
            this.Requests.UseVisualStyleBackColor = true;
            // 
            // dataGridView2 (Представление сетки данных)
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.defersDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.statusDataGridViewCheckBoxColumn});
            this.dataGridView2.DataSource = this.airRequestDataBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(0, 3);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 62;
            this.dataGridView2.RowTemplate.Height = 28;
            this.dataGridView2.Size = new System.Drawing.Size(776, 666);
            this.dataGridView2.TabIndex = 0;
            // 
            // TimeHeaderLabel (Метка заголовка времени)
            // 
            this.TimeHeaderLabel.AutoSize = true;
            this.TimeHeaderLabel.Location = new System.Drawing.Point(12, 9);
            this.TimeHeaderLabel.Name = "TimeHeaderLabel";
            this.TimeHeaderLabel.Size = new System.Drawing.Size(136, 16);
            this.TimeHeaderLabel.TabIndex = 1;
            this.TimeHeaderLabel.Text = "Время в симуляции:";
            // 
            // TimeLabel (Временная метка)
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Location = new System.Drawing.Point(188, 9);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(55, 16);
            this.TimeLabel.TabIndex = 2;
            this.TimeLabel.Text = "00:00:00";
            // 
            // StartStopButton (Кнопка «старт-стоп»)
            // 
            this.StartStopButton.Location = new System.Drawing.Point(322, 9);
            this.StartStopButton.Name = "StartStopButton";
            this.StartStopButton.Size = new System.Drawing.Size(165, 52);
            this.StartStopButton.TabIndex = 3;
            this.StartStopButton.Text = "Старт/стоп";
            this.StartStopButton.UseVisualStyleBackColor = true;
            this.StartStopButton.Click += new System.EventHandler(this.StartStopButton_Click);
            // 
            // FinishButton (Кнопка завершения)
            // 
            this.FinishButton.Location = new System.Drawing.Point(493, 9);
            this.FinishButton.Name = "FinishButton";
            this.FinishButton.Size = new System.Drawing.Size(144, 52);
            this.FinishButton.TabIndex = 4;
            this.FinishButton.Text = "Завершить";
            this.FinishButton.UseVisualStyleBackColor = true;
            this.FinishButton.Click += new System.EventHandler(this.FinishButton_Click);
            // 
            // dataGridViewTextBoxColumn1 (Текстовое поле представления сетки данных - Столбец 1)
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 47;
            // 
            // dataGridViewTextBoxColumn2 (Текстовое поле представления сетки данных - Столбец 2)
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Status";
            this.dataGridViewTextBoxColumn2.HeaderText = "Статус";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 82;
            // 
            // dataGridViewTextBoxColumn3 (Текстовое поле представления сетки данных - Столбец 3)
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Route";
            this.dataGridViewTextBoxColumn3.HeaderText = "Маршрут";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4 (Текстовое поле представления сетки данных - Столбец 4)
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "TakeOffPercentage";
            this.dataGridViewTextBoxColumn4.HeaderText = "Процент взлётов";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 138;
            // 
            // landPercentageDataGridViewTextBoxColumn (Столбец текстового поля в виде сетки данных о процентах посадок)
            // 
            this.landPercentageDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.landPercentageDataGridViewTextBoxColumn.DataPropertyName = "LandPercentage";
            this.landPercentageDataGridViewTextBoxColumn.HeaderText = "Процент посадок";
            this.landPercentageDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.landPercentageDataGridViewTextBoxColumn.Name = "landPercentageDataGridViewTextBoxColumn";
            this.landPercentageDataGridViewTextBoxColumn.ReadOnly = true;
            this.landPercentageDataGridViewTextBoxColumn.Width = 137;
            // 
            // runwayDataBindingSource (Источник привязки данных о взлётно-посадочной полосе)
            // 
            this.runwayDataBindingSource.DataSource = typeof(Aviasales.RunwayData);
            // 
            // departureTimeDataGridViewTextBoxColumn (Столбец текстового поля в виде таблицы данных о времени отправления)
            // 
            this.departureTimeDataGridViewTextBoxColumn.DataPropertyName = "DepartureTime";
            this.departureTimeDataGridViewTextBoxColumn.HeaderText = "Время отправления";
            this.departureTimeDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.departureTimeDataGridViewTextBoxColumn.Name = "departureTimeDataGridViewTextBoxColumn";
            this.departureTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // arriveTimeDataGridViewTextBoxColumn (Столбец текстового поля в виде сетки данных о времени прибытия)
            // 
            this.arriveTimeDataGridViewTextBoxColumn.DataPropertyName = "ArriveTime";
            this.arriveTimeDataGridViewTextBoxColumn.HeaderText = "Время прибытия";
            this.arriveTimeDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.arriveTimeDataGridViewTextBoxColumn.Name = "arriveTimeDataGridViewTextBoxColumn";
            this.arriveTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // departurePointDataGridViewTextBoxColumn (Столбец текстового поля в виде сетки данных точки отправления)
            // 
            this.departurePointDataGridViewTextBoxColumn.DataPropertyName = "DeparturePoint";
            this.departurePointDataGridViewTextBoxColumn.HeaderText = "Пункт отправления";
            this.departurePointDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.departurePointDataGridViewTextBoxColumn.Name = "departurePointDataGridViewTextBoxColumn";
            this.departurePointDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // arrivePointDataGridViewTextBoxColumn (Столбец текстового поля в виде таблицы данных точки прибытия)
            // 
            this.arrivePointDataGridViewTextBoxColumn.DataPropertyName = "ArrivePoint";
            this.arrivePointDataGridViewTextBoxColumn.HeaderText = "Пункт прибытия";
            this.arrivePointDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.arrivePointDataGridViewTextBoxColumn.Name = "arrivePointDataGridViewTextBoxColumn";
            this.arrivePointDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // airRouteBindingSource (Источник привязки воздушного маршрута)
            // 
            this.airRouteBindingSource.DataSource = typeof(Aviasales.AirRoute);
            // 
            // dataGridViewTextBoxColumn5 (Текстовое поле представления сетки данных - Столбец 5)
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Route";
            this.dataGridViewTextBoxColumn5.HeaderText = "Маршрут";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // defersDataGridViewTextBoxColumn (Столбец текстового поля представления сетки данных отложенных запросов)
            // 
            this.defersDataGridViewTextBoxColumn.DataPropertyName = "Defers";
            this.defersDataGridViewTextBoxColumn.HeaderText = "Отложенный";
            this.defersDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.defersDataGridViewTextBoxColumn.Name = "defersDataGridViewTextBoxColumn";
            // 
            // typeDataGridViewTextBoxColumn (Столбец текстового поля представления сетки данных типа запроса)
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "Тип";
            this.typeDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            // 
            // statusDataGridViewCheckBoxColumn (Столбец текстового поля представления сетки данных статуса запроса)
            // 
            this.statusDataGridViewCheckBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewCheckBoxColumn.HeaderText = "Статус";
            this.statusDataGridViewCheckBoxColumn.MinimumWidth = 8;
            this.statusDataGridViewCheckBoxColumn.Name = "statusDataGridViewCheckBoxColumn";
            // 
            // airRequestDataBindingSource (Источник привязки данных запроса)
            // 
            this.airRequestDataBindingSource.DataSource = typeof(Aviasales.AirRequestData);
            // 
            // SimulationMainForm (Основная форма моделирования)
            // 
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(782, 753);
            this.Controls.Add(this.FinishButton);
            this.Controls.Add(this.StartStopButton);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.TimeHeaderLabel);
            this.Controls.Add(this.TabControl);
            this.MaximumSize = new System.Drawing.Size(800, 800);
            this.MinimumSize = new System.Drawing.Size(800, 800);
            this.Name = "SimulationMainForm";
            this.Text = "Моделирование работы аэропорта";
            this.TabControl.ResumeLayout(false);
            this.RunwaysPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RunwaysDataGridView)).EndInit();
            this.Schedule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ScheduleDataGridView)).EndInit();
            this.Requests.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.runwayDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.airRouteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.airRequestDataBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void StartStopButton_Click(object sender, EventArgs e) // Метод переключает состояние таймера между запущенным и остановленным при каждом нажатии кнопки "Старт/стоп"
        {
            if (timer.Enabled)
            {
                timer.Stop();
            }
            else
            {
                timer.Start();
            }
        }

        // Файл для сериализации/десериализации
        string filePath = "airStat.json";
        static void SerializeToJson(AirStat airStat, string filePath) // Метод преобразует объект в формат JSON с отступами и записывает результат в файл
        {
            string json = JsonConvert.SerializeObject(airStat, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, json);
            Console.WriteLine($"Объект сериализован в {filePath}");
        }
        private void FinishButton_Click(object sender, EventArgs e) // Метод создаёт объект, сериализует его в формат JSON и сохраняет в файл, а затем закрывает текущую форму
        {
            AirStat airStat = airportSimulator.GetStats();
            ShowCustomMessageBox(airStat);
            // Log stats
            // Сохраняем объект в файл
            SerializeToJson(airStat, filePath);
            this.Close();            
        }

        static void ShowCustomMessageBox(AirStat airStat) // Метод формирует пользовательское окно со статистикой работы аэропорта
        {
            StringBuilder message = new StringBuilder();
            message.AppendLine($"Обработанные запросы: {airStat.HandledRequests}");
            message.AppendLine($"Максимальная задержка: {airStat.MaxDefer}");
            message.AppendLine($"Средняя задержка: {airStat.AvgDefer}");

            message.AppendLine("\nСтатистика взлётно-посадочной полосы:");
            foreach (var runwayStat in airStat.RunwayStats)
            {
                message.AppendLine($"Взлётно-посадочная полоса {runwayStat.Id}:");
                message.AppendLine($"  Количество взлётов: {runwayStat.TakeoffCount}");
                message.AppendLine($"  Количество посадок: {runwayStat.LandCount}");
                message.AppendLine($"  Процент взлётов: {runwayStat.TakeoffPercentage:P2}");
                message.AppendLine($"  Процент посадок: {runwayStat.LandPercentage:P2}");
            }

            using (Form customMessageBox = new Form())
            {
                customMessageBox.Text = "Статистика аэропорта";
                customMessageBox.Width = 600;
                customMessageBox.Height = 400;

                Panel panel = new Panel
                {
                    Dock = DockStyle.Fill
                };

                TextBox textBox = new TextBox
                {
                    Multiline = true,
                    ReadOnly = true,
                    Dock = DockStyle.Fill,
                    ScrollBars = ScrollBars.Vertical,
                    Text = message.ToString()
                };

                panel.Controls.Add(textBox);
                customMessageBox.Controls.Add(panel);

                customMessageBox.ShowDialog();
            }
        }
    }
}