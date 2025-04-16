using System.Drawing;
using System.Windows.Forms;
using System;

namespace VanGogRegistration
{
    partial class RegistrationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationForm));
            titleLabel = new Label();
            nameTextBox = new TextBox();
            birthDatePicker = new DateTimePicker();
            photoLabel = new Label();
            photoPanel = new Panel();
            uploadButton = new Button();
            continueButton = new Button();
            logoBox = new PictureBox();
            photoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoBox).BeginInit();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            titleLabel.Font = new Font("Segoe UI", 14F);
            titleLabel.ForeColor = Color.Black;
            titleLabel.Location = new Point(277, 175);
            titleLabel.Margin = new Padding(4, 0, 4, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(463, 59);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Введите своё имя и дату рождения для\nрегистрации на платформе \"Van Gog\"";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // nameTextBox
            // 
            nameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            nameTextBox.BorderStyle = BorderStyle.None;
            nameTextBox.Font = new Font("Segoe UI", 12F);
            nameTextBox.Location = new Point(385, 246);
            nameTextBox.Margin = new Padding(4, 3, 4, 3);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(245, 22);
            nameTextBox.TabIndex = 2;
            // 
            // birthDatePicker
            // 
            birthDatePicker.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            birthDatePicker.Font = new Font("Segoe UI", 12F);
            birthDatePicker.Format = DateTimePickerFormat.Short;
            birthDatePicker.Location = new Point(385, 274);
            birthDatePicker.Margin = new Padding(4, 3, 4, 3);
            birthDatePicker.Name = "birthDatePicker";
            birthDatePicker.Size = new Size(245, 29);
            birthDatePicker.TabIndex = 3;
            // 
            // photoLabel
            // 
            photoLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            photoLabel.Font = new Font("Segoe UI", 14F);
            photoLabel.ForeColor = Color.Black;
            photoLabel.Location = new Point(349, 316);
            photoLabel.Margin = new Padding(4, 0, 4, 0);
            photoLabel.Name = "photoLabel";
            photoLabel.Size = new Size(319, 30);
            photoLabel.TabIndex = 4;
            photoLabel.Text = "Добавьте свою фотографию";
            photoLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // photoPanel
            // 
            photoPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            photoPanel.AutoSize = true;
            photoPanel.BackColor = Color.White;
            photoPanel.BorderStyle = BorderStyle.FixedSingle;
            photoPanel.Controls.Add(uploadButton);
            photoPanel.Location = new Point(349, 364);
            photoPanel.Margin = new Padding(4, 3, 4, 3);
            photoPanel.Name = "photoPanel";
            photoPanel.Size = new Size(319, 319);
            photoPanel.TabIndex = 5;
            // 
            // uploadButton
            // 
            uploadButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            uploadButton.BackColor = Color.Gray;
            uploadButton.FlatAppearance.BorderSize = 0;
            uploadButton.FlatStyle = FlatStyle.Flat;
            uploadButton.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            uploadButton.ForeColor = Color.White;
            uploadButton.Location = new Point(81, 135);
            uploadButton.Margin = new Padding(4, 3, 4, 3);
            uploadButton.Name = "uploadButton";
            uploadButton.Size = new Size(151, 44);
            uploadButton.TabIndex = 0;
            uploadButton.Text = "Выбрать фото";
            uploadButton.UseVisualStyleBackColor = false;
            uploadButton.Click += uploadButton_Click;
            // 
            // continueButton
            // 
            continueButton.Anchor = AnchorStyles.Bottom;
            continueButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            continueButton.BackColor = Color.FromArgb(169, 106, 132);
            continueButton.Cursor = Cursors.Hand;
            continueButton.FlatStyle = FlatStyle.Flat;
            continueButton.Font = new Font("Segoe UI", 12F);
            continueButton.ForeColor = Color.White;
            continueButton.Location = new Point(415, 714);
            continueButton.Margin = new Padding(4, 3, 4, 3);
            continueButton.Name = "continueButton";
            continueButton.Size = new Size(190, 44);
            continueButton.TabIndex = 6;
            continueButton.Text = "Продолжить";
            continueButton.TextImageRelation = TextImageRelation.TextAboveImage;
            continueButton.UseVisualStyleBackColor = false;
            continueButton.Click += continueButton_Click;
            // 
            // logoBox
            // 
            logoBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            logoBox.BackColor = Color.Transparent;
            logoBox.Image = (Image)resources.GetObject("logoBox.Image");
            logoBox.Location = new Point(431, 12);
            logoBox.Margin = new Padding(4, 3, 4, 3);
            logoBox.Name = "logoBox";
            logoBox.Size = new Size(151, 152);
            logoBox.SizeMode = PictureBoxSizeMode.Zoom;
            logoBox.TabIndex = 0;
            logoBox.TabStop = false;
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 176, 176);
            ClientSize = new Size(999, 786);
            Controls.Add(logoBox);
            Controls.Add(titleLabel);
            Controls.Add(nameTextBox);
            Controls.Add(birthDatePicker);
            Controls.Add(photoLabel);
            Controls.Add(photoPanel);
            Controls.Add(continueButton);
            Cursor = Cursors.Hand;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(1015, 825);
            Name = "RegistrationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Регистрация";
            photoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)logoBox).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private PictureBox logoBox;
        private Label titleLabel;
        private TextBox nameTextBox;
        private DateTimePicker birthDatePicker;
        private Label photoLabel;
        private Panel photoPanel;
        private Button uploadButton;
        private Button continueButton;
    }
}