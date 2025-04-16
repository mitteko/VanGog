namespace VanGog
{
    partial class MyEventsForm
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
            sortComboBox = new ComboBox();
            createEventButton = new LinkLabel();
            eventsListPanel = new Panel();
            backToAnketsButton = new Button();
            sortLabel = new Label();
            backgroundPanel = new Panel();
            backgroundPanel.SuspendLayout();
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
            // eventsListPanel
            // 
            eventsListPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            eventsListPanel.AutoScroll = true;
            eventsListPanel.BackColor = Color.FromArgb(230, 200, 220);
            eventsListPanel.Location = new Point(20, 110);
            eventsListPanel.Name = "eventsListPanel";
            eventsListPanel.Size = new Size(959, 600);
            eventsListPanel.TabIndex = 4;
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
            // MyEventsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(195, 149, 171);
            ClientSize = new Size(999, 786);
            Controls.Add(backgroundPanel);
            Controls.Add(backToAnketsButton);
            Controls.Add(eventsListPanel);
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
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private Label sortLabel;
        private ComboBox sortComboBox;
        private LinkLabel createEventButton;
        private Panel eventsListPanel;
        private Button backToAnketsButton;
        private Panel backgroundPanel;
    }
}