namespace VanGog
{
    partial class AnketsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnketsForm));
            mainPanel = new Panel();
            dateTimeTitleLabel = new Label();
            dateTimeLabel = new Label();
            descriptionLabel = new Label();
            descriptionTitleLabel = new Label();
            topicLabel = new Label();
            topicTitleLabel = new Label();
            eventPictureBox = new PictureBox();
            logoBox = new PictureBox();
            myEventsButton = new Button();
            declineButton = new Button();
            signUpButton = new Button();
            mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)eventPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logoBox).BeginInit();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainPanel.BackColor = Color.White;
            mainPanel.Controls.Add(dateTimeTitleLabel);
            mainPanel.Controls.Add(dateTimeLabel);
            mainPanel.Controls.Add(descriptionLabel);
            mainPanel.Controls.Add(descriptionTitleLabel);
            mainPanel.Controls.Add(topicLabel);
            mainPanel.Controls.Add(topicTitleLabel);
            mainPanel.Controls.Add(eventPictureBox);
            mainPanel.Controls.Add(logoBox);
            mainPanel.Location = new Point(247, 56);
            mainPanel.Margin = new Padding(4, 3, 4, 3);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(502, 604);
            mainPanel.TabIndex = 0;
            // 
            // dateTimeTitleLabel
            // 
            dateTimeTitleLabel.AutoSize = true;
            dateTimeTitleLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dateTimeTitleLabel.Location = new Point(28, 508);
            dateTimeTitleLabel.Margin = new Padding(4, 0, 4, 0);
            dateTimeTitleLabel.Name = "dateTimeTitleLabel";
            dateTimeTitleLabel.Size = new Size(96, 19);
            dateTimeTitleLabel.TabIndex = 6;
            dateTimeTitleLabel.Text = "Дата/время:";
            // 
            // dateTimeLabel
            // 
            dateTimeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dateTimeLabel.Font = new Font("Segoe UI", 10F);
            dateTimeLabel.Location = new Point(146, 508);
            dateTimeLabel.Margin = new Padding(4, 0, 4, 0);
            dateTimeLabel.Name = "dateTimeLabel";
            dateTimeLabel.Size = new Size(333, 19);
            dateTimeLabel.TabIndex = 7;
            dateTimeLabel.Text = "01.01.2025 в 19:00";
            // 
            // descriptionLabel
            // 
            descriptionLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            descriptionLabel.Font = new Font("Segoe UI", 10F);
            descriptionLabel.Location = new Point(146, 458);
            descriptionLabel.Margin = new Padding(4, 0, 4, 0);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(333, 50);
            descriptionLabel.TabIndex = 5;
            descriptionLabel.Text = "Описание события будет здесь";
            // 
            // descriptionTitleLabel
            // 
            descriptionTitleLabel.AutoSize = true;
            descriptionTitleLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            descriptionTitleLabel.Location = new Point(41, 458);
            descriptionTitleLabel.Margin = new Padding(4, 0, 4, 0);
            descriptionTitleLabel.Name = "descriptionTitleLabel";
            descriptionTitleLabel.Size = new Size(83, 19);
            descriptionTitleLabel.TabIndex = 4;
            descriptionTitleLabel.Text = "Описание:";
            // 
            // topicLabel
            // 
            topicLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            topicLabel.Font = new Font("Segoe UI", 10F);
            topicLabel.Location = new Point(146, 409);
            topicLabel.Margin = new Padding(4, 0, 4, 0);
            topicLabel.Name = "topicLabel";
            topicLabel.Size = new Size(333, 35);
            topicLabel.TabIndex = 3;
            topicLabel.Text = "Тематика события будет здесь";
            // 
            // topicTitleLabel
            // 
            topicTitleLabel.AutoSize = true;
            topicTitleLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            topicTitleLabel.Location = new Point(46, 409);
            topicTitleLabel.Margin = new Padding(4, 0, 4, 0);
            topicTitleLabel.Name = "topicTitleLabel";
            topicTitleLabel.Size = new Size(78, 19);
            topicTitleLabel.TabIndex = 2;
            topicTitleLabel.Text = "Тематика:";
            // 
            // eventPictureBox
            // 
            eventPictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            eventPictureBox.BackColor = Color.FromArgb(248, 230, 230);
            eventPictureBox.Image = (Image)resources.GetObject("eventPictureBox.Image");
            eventPictureBox.Location = new Point(146, 20);
            eventPictureBox.Margin = new Padding(4, 3, 4, 3);
            eventPictureBox.Name = "eventPictureBox";
            eventPictureBox.Size = new Size(333, 339);
            eventPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            eventPictureBox.TabIndex = 1;
            eventPictureBox.TabStop = false;
            // 
            // logoBox
            // 
            logoBox.Image = (Image)resources.GetObject("logoBox.Image");
            logoBox.Location = new Point(24, 20);
            logoBox.Margin = new Padding(4, 3, 4, 3);
            logoBox.Name = "logoBox";
            logoBox.Size = new Size(100, 100);
            logoBox.SizeMode = PictureBoxSizeMode.Zoom;
            logoBox.TabIndex = 0;
            logoBox.TabStop = false;
            // 
            // myEventsButton
            // 
            myEventsButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            myEventsButton.BackColor = Color.Transparent;
            myEventsButton.FlatAppearance.BorderSize = 0;
            myEventsButton.FlatStyle = FlatStyle.Flat;
            myEventsButton.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 204);
            myEventsButton.Location = new Point(848, 12);
            myEventsButton.Margin = new Padding(4, 3, 4, 3);
            myEventsButton.Name = "myEventsButton";
            myEventsButton.Size = new Size(138, 32);
            myEventsButton.TabIndex = 1;
            myEventsButton.Text = "Мои события";
            myEventsButton.UseVisualStyleBackColor = false;
            myEventsButton.Click += myEventsButton_Click;
            // 
            // declineButton
            // 
            declineButton.Anchor = AnchorStyles.Bottom;
            declineButton.BackColor = Color.Silver;
            declineButton.FlatStyle = FlatStyle.Flat;
            declineButton.Font = new Font("Segoe UI", 12F);
            declineButton.ForeColor = Color.Black;
            declineButton.Location = new Point(247, 694);
            declineButton.Margin = new Padding(4, 3, 4, 3);
            declineButton.Name = "declineButton";
            declineButton.Size = new Size(200, 50);
            declineButton.TabIndex = 2;
            declineButton.Text = "Отклонить";
            declineButton.UseVisualStyleBackColor = false;
            declineButton.Click += declineButton_Click;
            // 
            // signUpButton
            // 
            signUpButton.Anchor = AnchorStyles.Bottom;
            signUpButton.BackColor = Color.FromArgb(169, 106, 132);
            signUpButton.FlatStyle = FlatStyle.Flat;
            signUpButton.Font = new Font("Segoe UI", 12F);
            signUpButton.ForeColor = Color.White;
            signUpButton.Location = new Point(549, 694);
            signUpButton.Margin = new Padding(4, 3, 4, 3);
            signUpButton.Name = "signUpButton";
            signUpButton.Size = new Size(200, 50);
            signUpButton.TabIndex = 3;
            signUpButton.Text = "Записаться";
            signUpButton.UseVisualStyleBackColor = false;
            signUpButton.Click += signUpButton_Click;
            // 
            // AnketsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 176, 176);
            ClientSize = new Size(999, 786);
            Controls.Add(signUpButton);
            Controls.Add(declineButton);
            Controls.Add(myEventsButton);
            Controls.Add(mainPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(1015, 825);
            Name = "AnketsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Анкеты";
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)eventPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)logoBox).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private Panel mainPanel;
        private PictureBox logoBox;
        private PictureBox eventPictureBox;
        private Label topicTitleLabel;
        private Label topicLabel;
        private Label descriptionTitleLabel;
        private Label descriptionLabel;
        private Button myEventsButton;
        private Button declineButton;
        private Button signUpButton;
        private Label dateTimeTitleLabel;
        private Label dateTimeLabel;
    }
}