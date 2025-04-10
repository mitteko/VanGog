﻿namespace VanGog
{
    partial class AnketsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnketsForm));
            mainPanel = new Panel();
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
            // descriptionLabel
            // 
            descriptionLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            descriptionLabel.Font = new Font("Segoe UI", 10F);
            descriptionLabel.Location = new Point(146, 458);
            descriptionLabel.Margin = new Padding(4, 0, 4, 0);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(333, 69);
            descriptionLabel.TabIndex = 5;
            descriptionLabel.Text = "Описание события будет здесь";
            // 
            // descriptionTitleLabel
            // 
            descriptionTitleLabel.AutoSize = true;
            descriptionTitleLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            descriptionTitleLabel.Location = new Point(37, 458);
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
            topicTitleLabel.Location = new Point(42, 409);
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
            logoBox.Location = new Point(20, 20);
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
            myEventsButton.Font = new Font("Segoe UI", 10F, FontStyle.Underline);
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
            Load += AnketsForm_Load;
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)eventPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)logoBox).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
    private System.Windows.Forms.PictureBox logoBox;
    private System.Windows.Forms.PictureBox eventPictureBox;
    private System.Windows.Forms.Label topicTitleLabel;
    private System.Windows.Forms.Label topicLabel;
    private System.Windows.Forms.Label descriptionTitleLabel;
    private System.Windows.Forms.Label descriptionLabel;
    private System.Windows.Forms.Button myEventsButton;
    private System.Windows.Forms.Button declineButton;
    private System.Windows.Forms.Button signUpButton;
}
}