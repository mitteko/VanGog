namespace VanGog.Excel
{
    partial class EventFilterForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>h the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            titleLabel = new Label();
            useDateFilterCheckBox = new CheckBox();
            startDateLabel = new Label();
            startDatePicker = new DateTimePicker();
            endDateLabel = new Label();
            endDatePicker = new DateTimePicker();
            categoryLabel = new Label();
            categoryComboBox = new ComboBox();
            eventsTypeGroupBox = new GroupBox();
            createdCheckBox = new CheckBox();
            subscribedCheckBox = new CheckBox();
            applyButton = new Button();
            cancelButton = new Button();
            eventsTypeGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            titleLabel.Location = new Point(51, 9);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(228, 30);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Фильтр для отчёта";
            // 
            // useDateFilterCheckBox
            // 
            useDateFilterCheckBox.AutoSize = true;
            useDateFilterCheckBox.Checked = true;
            useDateFilterCheckBox.CheckState = CheckState.Checked;
            useDateFilterCheckBox.Location = new Point(12, 50);
            useDateFilterCheckBox.Name = "useDateFilterCheckBox";
            useDateFilterCheckBox.Size = new Size(149, 19);
            useDateFilterCheckBox.TabIndex = 1;
            useDateFilterCheckBox.Text = "Фильтровать по датам";
            useDateFilterCheckBox.UseVisualStyleBackColor = true;
            useDateFilterCheckBox.CheckedChanged += useDateFilterCheckBox_CheckedChanged;
            // 
            // startDateLabel
            // 
            startDateLabel.AutoSize = true;
            startDateLabel.Location = new Point(32, 80);
            startDateLabel.Name = "startDateLabel";
            startDateLabel.Size = new Size(77, 15);
            startDateLabel.TabIndex = 2;
            startDateLabel.Text = "Дата начала:";
            // 
            // startDatePicker
            // 
            startDatePicker.Format = DateTimePickerFormat.Short;
            startDatePicker.Location = new Point(122, 76);
            startDatePicker.Name = "startDatePicker";
            startDatePicker.Size = new Size(200, 23);
            startDatePicker.TabIndex = 3;
            // 
            // endDateLabel
            // 
            endDateLabel.AutoSize = true;
            endDateLabel.Location = new Point(32, 110);
            endDateLabel.Name = "endDateLabel";
            endDateLabel.Size = new Size(71, 15);
            endDateLabel.TabIndex = 4;
            endDateLabel.Text = "Дата конца:";
            // 
            // endDatePicker
            // 
            endDatePicker.Format = DateTimePickerFormat.Short;
            endDatePicker.Location = new Point(122, 106);
            endDatePicker.Name = "endDatePicker";
            endDatePicker.Size = new Size(200, 23);
            endDatePicker.TabIndex = 5;
            // 
            // categoryLabel
            // 
            categoryLabel.AutoSize = true;
            categoryLabel.Location = new Point(12, 150);
            categoryLabel.Name = "categoryLabel";
            categoryLabel.Size = new Size(66, 15);
            categoryLabel.TabIndex = 6;
            categoryLabel.Text = "Категория:";
            // 
            // categoryComboBox
            // 
            categoryComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            categoryComboBox.FormattingEnabled = true;
            categoryComboBox.Location = new Point(122, 147);
            categoryComboBox.Name = "categoryComboBox";
            categoryComboBox.Size = new Size(200, 23);
            categoryComboBox.TabIndex = 7;
            // 
            // eventsTypeGroupBox
            // 
            eventsTypeGroupBox.Controls.Add(createdCheckBox);
            eventsTypeGroupBox.Controls.Add(subscribedCheckBox);
            eventsTypeGroupBox.Location = new Point(12, 190);
            eventsTypeGroupBox.Name = "eventsTypeGroupBox";
            eventsTypeGroupBox.Size = new Size(310, 80);
            eventsTypeGroupBox.TabIndex = 8;
            eventsTypeGroupBox.TabStop = false;
            eventsTypeGroupBox.Text = "Типы событий";
            // 
            // createdCheckBox
            // 
            createdCheckBox.AutoSize = true;
            createdCheckBox.Location = new Point(20, 47);
            createdCheckBox.Name = "createdCheckBox";
            createdCheckBox.Size = new Size(137, 19);
            createdCheckBox.TabIndex = 1;
            createdCheckBox.Text = "Созданные события";
            createdCheckBox.UseVisualStyleBackColor = true;
            // 
            // subscribedCheckBox
            // 
            subscribedCheckBox.AutoSize = true;
            subscribedCheckBox.Location = new Point(20, 22);
            subscribedCheckBox.Name = "subscribedCheckBox";
            subscribedCheckBox.Size = new Size(152, 19);
            subscribedCheckBox.TabIndex = 0;
            subscribedCheckBox.Text = "Добавленные события";
            subscribedCheckBox.UseVisualStyleBackColor = true;
            // 
            // applyButton
            // 
            applyButton.BackColor = Color.FromArgb(169, 106, 132);
            applyButton.FlatStyle = FlatStyle.Flat;
            applyButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            applyButton.ForeColor = Color.White;
            applyButton.Location = new Point(12, 290);
            applyButton.Name = "applyButton";
            applyButton.Size = new Size(150, 30);
            applyButton.TabIndex = 9;
            applyButton.Text = "Применить";
            applyButton.UseVisualStyleBackColor = false;
            applyButton.Click += applyButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(172, 290);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(150, 30);
            cancelButton.TabIndex = 10;
            cancelButton.Text = "Отмена";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // EventFilterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 230, 230);
            ClientSize = new Size(334, 341);
            Controls.Add(cancelButton);
            Controls.Add(applyButton);
            Controls.Add(eventsTypeGroupBox);
            Controls.Add(categoryComboBox);
            Controls.Add(categoryLabel);
            Controls.Add(endDatePicker);
            Controls.Add(endDateLabel);
            Controls.Add(startDatePicker);
            Controls.Add(startDateLabel);
            Controls.Add(useDateFilterCheckBox);
            Controls.Add(titleLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EventFilterForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Фильтр для отчёта";
            eventsTypeGroupBox.ResumeLayout(false);
            eventsTypeGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private CheckBox useDateFilterCheckBox;
        private Label startDateLabel;
        private DateTimePicker startDatePicker;
        private Label endDateLabel;
        private DateTimePicker endDatePicker;
        private Label categoryLabel;
        private ComboBox categoryComboBox;
        private GroupBox eventsTypeGroupBox;
        private CheckBox createdCheckBox;
        private CheckBox subscribedCheckBox;
        private Button applyButton;
        private Button cancelButton;
    }
}