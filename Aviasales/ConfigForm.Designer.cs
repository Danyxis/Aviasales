namespace Aviasales
{
    partial class ConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RunwaysLabel = new System.Windows.Forms.Label();
            this.DerivationLabel = new System.Windows.Forms.Label();
            this.SimulationCoefficientLabel = new System.Windows.Forms.Label();
            this.StartDateTimeLabel = new System.Windows.Forms.Label();
            this.RunwaysCountMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.SimulationCoefficientMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.StartDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.DerivationToMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.RunSimulationButton = new System.Windows.Forms.Button();
            this.RequestsCountLabel = new System.Windows.Forms.Label();
            this.RequestsCountMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.FinishDateTimeLabel = new System.Windows.Forms.Label();
            this.FinishDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // RunwaysLabel
            // 
            this.RunwaysLabel.AutoSize = true;
            this.RunwaysLabel.Location = new System.Drawing.Point(11, 35);
            this.RunwaysLabel.Name = "RunwaysLabel";
            this.RunwaysLabel.Size = new System.Drawing.Size(270, 16);
            this.RunwaysLabel.TabIndex = 0;
            this.RunwaysLabel.Text = "Количество взлётно-посадочных полос:";
            // 
            // DerivationLabel
            // 
            this.DerivationLabel.AutoSize = true;
            this.DerivationLabel.Location = new System.Drawing.Point(11, 68);
            this.DerivationLabel.Name = "DerivationLabel";
            this.DerivationLabel.Size = new System.Drawing.Size(202, 16);
            this.DerivationLabel.TabIndex = 1;
            this.DerivationLabel.Text = "Параметры отклонений (мин):";
            this.DerivationLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // SimulationCoefficientLabel
            // 
            this.SimulationCoefficientLabel.AutoSize = true;
            this.SimulationCoefficientLabel.Location = new System.Drawing.Point(11, 102);
            this.SimulationCoefficientLabel.Name = "SimulationCoefficientLabel";
            this.SimulationCoefficientLabel.Size = new System.Drawing.Size(244, 16);
            this.SimulationCoefficientLabel.TabIndex = 2;
            this.SimulationCoefficientLabel.Text = "Коэффициент шага симуляции (сек):";
            this.SimulationCoefficientLabel.Click += new System.EventHandler(this.label3_Click);
            // 
            // StartDateTimeLabel
            // 
            this.StartDateTimeLabel.AutoSize = true;
            this.StartDateTimeLabel.Location = new System.Drawing.Point(11, 139);
            this.StartDateTimeLabel.Name = "StartDateTimeLabel";
            this.StartDateTimeLabel.Size = new System.Drawing.Size(176, 16);
            this.StartDateTimeLabel.TabIndex = 3;
            this.StartDateTimeLabel.Text = "Время начала симуляции:";
            // 
            // RunwaysCountMaskedTextBox
            // 
            this.RunwaysCountMaskedTextBox.Location = new System.Drawing.Point(303, 32);
            this.RunwaysCountMaskedTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RunwaysCountMaskedTextBox.Mask = "000";
            this.RunwaysCountMaskedTextBox.Name = "RunwaysCountMaskedTextBox";
            this.RunwaysCountMaskedTextBox.Size = new System.Drawing.Size(89, 22);
            this.RunwaysCountMaskedTextBox.TabIndex = 4;
            // 
            // SimulationCoefficientMaskedTextBox
            // 
            this.SimulationCoefficientMaskedTextBox.Location = new System.Drawing.Point(274, 99);
            this.SimulationCoefficientMaskedTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SimulationCoefficientMaskedTextBox.Mask = "0000";
            this.SimulationCoefficientMaskedTextBox.Name = "SimulationCoefficientMaskedTextBox";
            this.SimulationCoefficientMaskedTextBox.Size = new System.Drawing.Size(146, 22);
            this.SimulationCoefficientMaskedTextBox.TabIndex = 5;
            // 
            // StartDateTimePicker
            // 
            this.StartDateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.StartDateTimePicker.Location = new System.Drawing.Point(215, 134);
            this.StartDateTimePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StartDateTimePicker.Name = "StartDateTimePicker";
            this.StartDateTimePicker.Size = new System.Drawing.Size(187, 22);
            this.StartDateTimePicker.TabIndex = 6;
            this.StartDateTimePicker.ValueChanged += new System.EventHandler(this.StartDateTimePicker_ValueChanged);
            // 
            // DerivationToMaskedTextBox
            // 
            this.DerivationToMaskedTextBox.Location = new System.Drawing.Point(226, 65);
            this.DerivationToMaskedTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DerivationToMaskedTextBox.Mask = "000";
            this.DerivationToMaskedTextBox.Name = "DerivationToMaskedTextBox";
            this.DerivationToMaskedTextBox.Size = new System.Drawing.Size(32, 22);
            this.DerivationToMaskedTextBox.TabIndex = 10;
            // 
            // RunSimulationButton
            // 
            this.RunSimulationButton.Location = new System.Drawing.Point(241, 314);
            this.RunSimulationButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RunSimulationButton.Name = "RunSimulationButton";
            this.RunSimulationButton.Size = new System.Drawing.Size(180, 37);
            this.RunSimulationButton.TabIndex = 11;
            this.RunSimulationButton.Text = "Запустить симуляцию";
            this.RunSimulationButton.UseVisualStyleBackColor = true;
            this.RunSimulationButton.Click += new System.EventHandler(this.RunSimulationButton_Click);
            // 
            // RequestsCountLabel
            // 
            this.RequestsCountLabel.AutoSize = true;
            this.RequestsCountLabel.Location = new System.Drawing.Point(12, 211);
            this.RequestsCountLabel.Name = "RequestsCountLabel";
            this.RequestsCountLabel.Size = new System.Drawing.Size(116, 16);
            this.RequestsCountLabel.TabIndex = 12;
            this.RequestsCountLabel.Text = "Число запросов:";
            // 
            // RequestsCountMaskedTextBox
            // 
            this.RequestsCountMaskedTextBox.Location = new System.Drawing.Point(151, 208);
            this.RequestsCountMaskedTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RequestsCountMaskedTextBox.Mask = "0000";
            this.RequestsCountMaskedTextBox.Name = "RequestsCountMaskedTextBox";
            this.RequestsCountMaskedTextBox.Size = new System.Drawing.Size(89, 22);
            this.RequestsCountMaskedTextBox.TabIndex = 13;
            // 
            // FinishDateTimeLabel
            // 
            this.FinishDateTimeLabel.AutoSize = true;
            this.FinishDateTimeLabel.Location = new System.Drawing.Point(11, 175);
            this.FinishDateTimeLabel.Name = "FinishDateTimeLabel";
            this.FinishDateTimeLabel.Size = new System.Drawing.Size(198, 16);
            this.FinishDateTimeLabel.TabIndex = 14;
            this.FinishDateTimeLabel.Text = "Время окончания симуляции:";
            // 
            // FinishDateTimePicker
            // 
            this.FinishDateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.FinishDateTimePicker.Location = new System.Drawing.Point(236, 170);
            this.FinishDateTimePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FinishDateTimePicker.Name = "FinishDateTimePicker";
            this.FinishDateTimePicker.Size = new System.Drawing.Size(166, 22);
            this.FinishDateTimePicker.TabIndex = 15;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 360);
            this.Controls.Add(this.FinishDateTimePicker);
            this.Controls.Add(this.FinishDateTimeLabel);
            this.Controls.Add(this.RequestsCountMaskedTextBox);
            this.Controls.Add(this.RequestsCountLabel);
            this.Controls.Add(this.RunSimulationButton);
            this.Controls.Add(this.DerivationToMaskedTextBox);
            this.Controls.Add(this.StartDateTimePicker);
            this.Controls.Add(this.SimulationCoefficientMaskedTextBox);
            this.Controls.Add(this.RunwaysCountMaskedTextBox);
            this.Controls.Add(this.StartDateTimeLabel);
            this.Controls.Add(this.SimulationCoefficientLabel);
            this.Controls.Add(this.DerivationLabel);
            this.Controls.Add(this.RunwaysLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ConfigForm";
            this.Text = "Настройка параметров моделирования";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label RunwaysLabel;
        private System.Windows.Forms.Label DerivationLabel;
        private System.Windows.Forms.Label SimulationCoefficientLabel;
        private System.Windows.Forms.Label StartDateTimeLabel;
        private System.Windows.Forms.MaskedTextBox RunwaysCountMaskedTextBox;
        private System.Windows.Forms.MaskedTextBox SimulationCoefficientMaskedTextBox;
        private System.Windows.Forms.DateTimePicker StartDateTimePicker;
        private System.Windows.Forms.MaskedTextBox DerivationToMaskedTextBox;
        private System.Windows.Forms.Button RunSimulationButton;
        private System.Windows.Forms.Label RequestsCountLabel;
        private System.Windows.Forms.MaskedTextBox RequestsCountMaskedTextBox;
        private System.Windows.Forms.Label FinishDateTimeLabel;
        private System.Windows.Forms.DateTimePicker FinishDateTimePicker;
    }
}