namespace VanGog
{
    partial class MyEventsForm
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
        /// </summary>
        private void InitializeComponent()
        {
            titleLabel = new Label();
            sortComboBox = new ComboBox();
            createEventButton = new LinkLabel();
            backToAnketsButton = new Button();
            sortLabel = new Label();
            backgroundPanel = new Panel();
            subscribedEventsPanel = new Panel();
            subscribedTitleLabel = new Label();
            createdEventsPanel = new Panel();
            createdTitleLabel = new Label();
            eventsContainer = new Panel();
            reportButton = new Button();
            backgroundPanel.SuspendLayout();
            subscribedEventsPanel.SuspendLayout();
            createdEventsPanel.SuspendLayout();
            eventsContainer.SuspendLayout();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.Anchor = AnchorStyles.Top;
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            titleLabel.Location = new Point(421, 12);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(172, 32);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Мои события";
            // 
            // sortComboBox
            // 
            sortComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            sortComboBox.Font = new Font("Segoe UI", 10F);
            sortComboBox.FormattingEnabled = true;
            sortComboBox.Items.AddRange(new object[] { "Дате (сначала новые)", "Дате (сначала старые)", "Названию" });
            sortComboBox.Location = new Point(134, 72);
            sortComboBox.Name = "sortComboBox";
            sortComboBox.Size = new Size(200, 25);
            sortComboBox.TabIndex = 2;
            sortComboBox.SelectedIndexChanged += sortComboBox_SelectedIndexChanged;
            // 
            // createEventButton
            // 
            createEventButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            createEventButton.AutoSize = true;
            createEventButton.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            createEventButton.LinkColor = Color.Black;
            createEventButton.Location = new Point(804, 74);
            createEventButton.Name = "createEventButton";
            createEventButton.Size = new Size(175, 20);
            createEventButton.TabIndex = 3;
            createEventButton.TabStop = true;
            createEventButton.Text = "Создать новое событие";
            createEventButton.LinkClicked += createEventButton_LinkClicked;
            // 
            // backToAnketsButton
            // 
            backToAnketsButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            backToAnketsButton.BackColor = Color.FromArgb(169, 106, 132);
            backToAnketsButton.FlatStyle = FlatStyle.Flat;
            backToAnketsButton.Font = new Font("Segoe UI", 12F);
            backToAnketsButton.ForeColor = Color.White;
            backToAnketsButton.Location = new Point(20, 730);
            backToAnketsButton.Name = "backToAnketsButton";
            backToAnketsButton.Size = new Size(200, 40);
            backToAnketsButton.TabIndex = 5;
            backToAnketsButton.Text = "Вернуться к анкетам";
            backToAnketsButton.UseVisualStyleBackColor = false;
            backToAnketsButton.Click += backToAnketsButton_Click;
            // 
            // sortLabel
            // 
            sortLabel.AutoSize = true;
            sortLabel.Font = new Font("Segoe UI", 10F);
            sortLabel.Location = new Point(20, 74);
            sortLabel.Name = "sortLabel";
            sortLabel.Size = new Size(108, 19);
            sortLabel.TabIndex = 1;
            sortLabel.Text = "Сортировка по:";
            // 
            // backgroundPanel
            // 
            backgroundPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            backgroundPanel.BackColor = Color.FromArgb(221, 196, 200);
            backgroundPanel.Controls.Add(titleLabel);
            backgroundPanel.Location = new Point(0, 0);
            backgroundPanel.Name = "backgroundPanel";
            backgroundPanel.Size = new Size(999, 60);
            backgroundPanel.TabIndex = 6;
            // 
            // subscribedEventsPanel
            // 
            subscribedEventsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            subscribedEventsPanel.AutoScroll = true;
            subscribedEventsPanel.BackColor = Color.FromArgb(230, 200, 220);
            subscribedEventsPanel.Controls.Add(subscribedTitleLabel);
            subscribedEventsPanel.Location = new Point(10, 10);
            subscribedEventsPanel.Name = "subscribedEventsPanel";
            subscribedEventsPanel.Size = new Size(470, 580);
            subscribedEventsPanel.TabIndex = 7;
            // 
            // subscribedTitleLabel
            // 
            subscribedTitleLabel.BackColor = Color.FromArgb(221, 196, 200);
            subscribedTitleLabel.Dock = DockStyle.Top;
            subscribedTitleLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            subscribedTitleLabel.Location = new Point(0, 0);
            subscribedTitleLabel.Name = "subscribedTitleLabel";
            subscribedTitleLabel.Size = new Size(470, 38);
            subscribedTitleLabel.TabIndex = 0;
            subscribedTitleLabel.Text = "Добавленные события";
            subscribedTitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // createdEventsPanel
            // 
            createdEventsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            createdEventsPanel.AutoScroll = true;
            createdEventsPanel.BackColor = Color.FromArgb(230, 200, 220);
            createdEventsPanel.Controls.Add(createdTitleLabel);
            createdEventsPanel.Location = new Point(490, 10);
            createdEventsPanel.Name = "createdEventsPanel";
            createdEventsPanel.Size = new Size(470, 580);
            createdEventsPanel.TabIndex = 8;
            // 
            // createdTitleLabel
            // 
            createdTitleLabel.BackColor = Color.FromArgb(221, 196, 200);
            createdTitleLabel.Dock = DockStyle.Top;
            createdTitleLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            createdTitleLabel.Location = new Point(0, 0);
            createdTitleLabel.Name = "createdTitleLabel";
            createdTitleLabel.Size = new Size(470, 38);
            createdTitleLabel.TabIndex = 1;
            createdTitleLabel.Text = "Созданные события";
            createdTitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // eventsContainer
            // 
            eventsContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            eventsContainer.Controls.Add(subscribedEventsPanel);
            eventsContainer.Controls.Add(createdEventsPanel);
            eventsContainer.Location = new Point(20, 110);
            eventsContainer.Name = "eventsContainer";
            eventsContainer.Size = new Size(970, 600);
            eventsContainer.TabIndex = 9;
            // 
            // reportButton
            // 
            reportButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            reportButton.BackColor = Color.FromArgb(169, 106, 132);
            reportButton.FlatStyle = FlatStyle.Flat;
            reportButton.Font = new Font("Segoe UI", 12F);
            reportButton.ForeColor = Color.White;
            reportButton.Location = new Point(780, 730);
            reportButton.Name = "reportButton";
            reportButton.Size = new Size(200, 40);
            reportButton.TabIndex = 10;
            reportButton.Text = "Отчёт";
            reportButton.UseVisualStyleBackColor = false;
            reportButton.Click += reportButton_Click;
            // 
            // MyEventsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(195, 149, 171);
            ClientSize = new Size(999, 786);
            Controls.Add(reportButton);
            Controls.Add(eventsContainer);
            Controls.Add(backgroundPanel);
            Controls.Add(backToAnketsButton);
            Controls.Add(createEventButton);
            Controls.Add(sortComboBox);
            Controls.Add(sortLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MinimumSize = new Size(1015, 825);
            Name = "MyEventsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Мои события";
            backgroundPanel.ResumeLayout(false);
            backgroundPanel.PerformLayout();
            subscribedEventsPanel.ResumeLayout(false);
            createdEventsPanel.ResumeLayout(false);
            eventsContainer.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private Label sortLabel;
        private ComboBox sortComboBox;
        private LinkLabel createEventButton;
        private Button backToAnketsButton;
        private Panel backgroundPanel;
        private Panel subscribedEventsPanel;
        private Label subscribedTitleLabel;
        private Panel createdEventsPanel;
        private Label createdTitleLabel;
        private Panel eventsContainer;
        private Button reportButton;
    }
}