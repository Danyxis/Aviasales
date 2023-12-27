using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Aviasales
{
    public partial class ConfigForm : Form // Форма пользовательского интерфейса, позволяющая пользователю задавать параметры конфигурации для моделирования работы аэропорта
    {
        public ConfigForm() // Инициализирует компоненты формы и пытается загрузить конфигурацию из файла при создании экземпляра этой формы
        {
            InitializeComponent();
            TryLoadConfing();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void RunSimulationButton_Click(object sender, EventArgs e) // Запуск моделирования работы аэропорта
        {
            SimulationConfig config = new SimulationConfig();
            try
            {
                config.SimulationCoefficient = Int32.Parse(this.SimulationCoefficientMaskedTextBox.Text);
                config.Derivation = Int32.Parse(this.DerivationToMaskedTextBox.Text);
                config.RunwaysCount = Int32.Parse(this.RunwaysCountMaskedTextBox.Text);
                config.RequestsCount = Int32.Parse(this.RequestsCountMaskedTextBox.Text);
                config.StartDateTime = this.StartDateTimePicker.Value;
                config.FinishDateTime = this.FinishDateTimePicker.Value;
                // Сериализация объекта в JSON строку
                string json = JsonConvert.SerializeObject(config, Formatting.Indented);

                // Сохранение JSON строки в файл
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, json);
                    MessageBox.Show("Конфигурация сохранена в файл!");
                }
            }
            catch (Exception ex)
            {
                // Задаём значения по умолчанию
                this.DerivationToMaskedTextBox.Text = config.Derivation.ToString();
                this.RequestsCountMaskedTextBox.Text = config.RequestsCount.ToString();
                this.RunwaysCountMaskedTextBox.Text = config.RunwaysCount.ToString();
                this.SimulationCoefficientMaskedTextBox.Text = config.SimulationCoefficient.ToString();
                this.StartDateTimePicker.Value = config.StartDateTime;
                this.FinishDateTimePicker.Value = config.FinishDateTime;
            }

            SimulationMainForm form = new SimulationMainForm(config);
            form.ShowDialog();
            Close();
        }

        private SimulationConfig DeserializeConfigFromFile(string filePath) // Считывание содержимого JSON файла, его десериализация
        {
            try
            {
                // Чтение JSON из файла
                string json = File.ReadAllText(filePath);

                // Десериализация JSON в объект
                SimulationConfig deserializedConfig = JsonConvert.DeserializeObject<SimulationConfig>(json);

                return deserializedConfig;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при десериализации: {ex.Message}");
                return null;
            }
        }

        private void TryLoadConfing() // Метод попытки загрузки конфигурации моделирования (симуляции) работы аэропорта из выбранного файла
        {
            // Загрузка конфигурации через OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SimulationConfig loadedConfig = DeserializeConfigFromFile(openFileDialog.FileName);

                if (loadedConfig != null)
                {
                    this.DerivationToMaskedTextBox.Text = loadedConfig.Derivation.ToString();
                    this.RequestsCountMaskedTextBox.Text = loadedConfig.RequestsCount.ToString();
                    this.RunwaysCountMaskedTextBox.Text = loadedConfig.RunwaysCount.ToString();
                    this.SimulationCoefficientMaskedTextBox.Text = loadedConfig.SimulationCoefficient.ToString();
                    this.StartDateTimePicker.Value = loadedConfig.StartDateTime;
                    this.FinishDateTimePicker.Value = loadedConfig.FinishDateTime;
                }
            }
        }

        private void StartDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {

        }
    }

    public class SimulationConfig // Класс хранения конфигурационных данных для симуляции
    {
        public SimulationConfig() 
        {
            RequestsCount = 100; // Количество запросов
            SimulationCoefficient = 300; // Коэффициент симуляции 
            StartDateTime = DateTime.Now; // Начальная и конечная даты симуляции 
            FinishDateTime = DateTime.Now.AddDays(5);
            Derivation = 30; // Временное отклонение
            RunwaysCount = 10; // Количество полос
        }
        public int RequestsCount { get; set; } // Свойства полей
        public int SimulationCoefficient { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime FinishDateTime { get; set; }
        public int Derivation { get; set; }
        public int RunwaysCount { get; set; }
    }
}