namespace VanGog
{
    partial class CreateEventForm
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
            titleLabel = new Label();
            topicLabel = new Label();
            titleTextBox = new TextBox();
            descriptionLabel = new Label();
            descriptionTextBox = new TextBox();
            dateTimeLabel = new Label();
            datePicker = new DateTimePicker();
            timePicker = new DateTimePicker();
            photoLabel = new Label();
            photoPanel = new Panel();
            uploadButton = new Button();
            cancelButton = new Button();
            saveButton = new Button();
            categoryLabel = new Label();
            categoryComboBox = new ComboBox();
            photoPanel.SuspendLayout();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            titleLabel.Location = new Point(83, 22);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(327, 25);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Пожалуйста, введите все данные";
            // 
            // topicLabel
            // 
            topicLabel.AutoSize = true;
            topicLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            topicLabel.Location = new Point(12, 73);
            topicLabel.Name = "topicLabel";
            topicLabel.Size = new Size(149, 19);
            topicLabel.TabIndex = 1;
            topicLabel.Text = "Тематика свидания:";
            // 
            // titleTextBox
            // 
            titleTextBox.Font = new Font("Segoe UI", 10F);
            titleTextBox.Location = new Point(184, 70);
            titleTextBox.Name = "titleTextBox";
            titleTextBox.Size = new Size(296, 25);
            titleTextBox.TabIndex = 2;
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            descriptionLabel.Location = new Point(12, 130);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(142, 19);
            descriptionLabel.TabIndex = 3;
            descriptionLabel.Text = "Краткое описание:";
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.Font = new Font("Segoe UI", 10F);
            descriptionTextBox.Location = new Point(184, 110);
            descriptionTextBox.Multiline = true;
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.Size = new Size(296, 60);
            descriptionTextBox.TabIndex = 4;
            // 
            // dateTimeLabel
            // 
            dateTimeLabel.AutoSize = true;
            dateTimeLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dateTimeLabel.Location = new Point(12, 227);
            dateTimeLabel.Name = "dateTimeLabel";
            dateTimeLabel.Size = new Size(166, 19);
            dateTimeLabel.TabIndex = 7;
            dateTimeLabel.Text = "Введите дату и время:";
            // 
            // datePicker
            // 
            datePicker.Font = new Font("Segoe UI", 10F);
            datePicker.Format = DateTimePickerFormat.Short;
            datePicker.Location = new Point(184, 225);
            datePicker.Name = "datePicker";
            datePicker.Size = new Size(136, 25);
            datePicker.TabIndex = 8;
            // 
            // timePicker
            // 
            timePicker.Font = new Font("Segoe UI", 10F);
            timePicker.Format = DateTimePickerFormat.Time;
            timePicker.Location = new Point(340, 225);
            timePicker.Name = "timePicker";
            timePicker.ShowUpDown = true;
            timePicker.Size = new Size(140, 25);
            timePicker.TabIndex = 9;
            // 
            // photoLabel
            // 
            photoLabel.AutoSize = true;
            photoLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            photoLabel.Location = new Point(12, 347);
            photoLabel.Name = "photoLabel";
            photoLabel.Size = new Size(136, 38);
            photoLabel.TabIndex = 10;
            photoLabel.Text = "Добавьте фото\r\nафиши или места:";
            // 
            // photoPanel
            // 
            photoPanel.BackColor = Color.White;
            photoPanel.BorderStyle = BorderStyle.FixedSingle;
            photoPanel.Controls.Add(uploadButton);
            photoPanel.Location = new Point(184, 270);
            photoPanel.Name = "photoPanel";
            photoPanel.Size = new Size(296, 200);
            photoPanel.TabIndex = 11;
            // 
            // uploadButton
            // 
            uploadButton.BackColor = Color.Gray;
            uploadButton.FlatAppearance.BorderSize = 0;
            uploadButton.FlatStyle = FlatStyle.Flat;
            uploadButton.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            uploadButton.ForeColor = Color.White;
            uploadButton.Location = new Point(75, 75);
            uploadButton.Name = "uploadButton";
            uploadButton.Size = new Size(150, 40);
            uploadButton.TabIndex = 12;
            uploadButton.Text = "Выбрать фото";
            uploadButton.UseVisualStyleBackColor = false;
            uploadButton.Click += uploadButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.BackColor = Color.Silver;
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.Font = new Font("Segoe UI", 10F);
            cancelButton.Location = new Point(184, 490);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(136, 40);
            cancelButton.TabIndex = 13;
            cancelButton.Text = "Отменить";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += cancelButton_Click;
            // 
            // saveButton
            // 
            saveButton.BackColor = Color.FromArgb(169, 106, 132);
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.Font = new Font("Segoe UI", 10F);
            saveButton.ForeColor = Color.White;
            saveButton.Location = new Point(340, 490);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(140, 40);
            saveButton.TabIndex = 14;
            saveButton.Text = "Сохранить";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += saveButton_Click;
            // 
            // categoryLabel
            // 
            categoryLabel.AutoSize = true;
            categoryLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            categoryLabel.Location = new Point(12, 188);
            categoryLabel.Name = "categoryLabel";
            categoryLabel.Size = new Size(85, 19);
            categoryLabel.TabIndex = 5;
            categoryLabel.Text = "Категория:";
            // 
            // categoryComboBox
            // 
            categoryComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            categoryComboBox.Font = new Font("Segoe UI", 10F);
            categoryComboBox.FormattingEnabled = true;
            categoryComboBox.Location = new Point(184, 185);
            categoryComboBox.Name = "categoryComboBox";
            categoryComboBox.Size = new Size(296, 25);
            categoryComboBox.TabIndex = 6;
            // 
            // CreateEventForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 230, 230);
            ClientSize = new Size(500, 550);
            Controls.Add(saveButton);
            Controls.Add(cancelButton);
            Controls.Add(photoPanel);
            Controls.Add(photoLabel);
            Controls.Add(timePicker);
            Controls.Add(datePicker);
            Controls.Add(dateTimeLabel);
            Controls.Add(categoryComboBox);
            Controls.Add(categoryLabel);
            Controls.Add(descriptionTextBox);
            Controls.Add(descriptionLabel);
            Controls.Add(titleTextBox);
            Controls.Add(topicLabel);
            Controls.Add(titleLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CreateEventForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Создание события";
            photoPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private Label topicLabel;
        private TextBox titleTextBox;
        private Label descriptionLabel;
        private TextBox descriptionTextBox;
        private Label categoryLabel;
        private ComboBox categoryComboBox;
        private Label dateTimeLabel;
        private DateTimePicker datePicker;
        private DateTimePicker timePicker;
        private Label photoLabel;
        private Panel photoPanel;
        private Button uploadButton;
        private Button cancelButton;
        private Button saveButton;

    }
}