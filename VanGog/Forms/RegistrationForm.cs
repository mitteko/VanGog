using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using VanGog;
using VanGog.Storage;
using VanGog.Storage.Core.Entities;
namespace VanGogRegistration
{
    public partial class RegistrationForm : Form
    {
        private string selectedImagePath = string.Empty;
        private readonly VanGogDbContext dbContext;
        public RegistrationForm()
        {
            InitializeComponent();

            // центрируем кнопку загрузки в панели
            uploadButton.Anchor = AnchorStyles.None;
            CenterControlInPanel(uploadButton, photoPanel);
            dbContext = new VanGogDbContext();
            // обработчик изменения размера панели для центрирования кнопки "выбрать"
            photoPanel.Resize += (s, e) => CenterControlInPanel(uploadButton, photoPanel);
        }

        private void CenterControlInPanel(Control control, Panel panel)
        {
            // центральная позиция относительно панели
            int centerX = (panel.ClientSize.Width - control.Width) / 2;
            int centerY = (panel.ClientSize.Height - control.Height) / 2;

            control.Location = new Point(centerX, centerY);
        }

        private void CenterControl(Control control) //центр оносительно оси x, позже расположу элементы четко по центру
        {
            int centerX = (control.Parent.ClientSize.Width - control.Width) / 2;
            int centerY = (control.Parent.ClientSize.Height - control.Height) / 2;

            control.Location = new Point(centerX, centerY);
        }

        private void UploadPhoto(Panel photoPanel)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.Title = "Select a Photo";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = openFileDialog.FileName;

                    photoPanel.Controls.Clear();

                    PictureBox pictureBox = new PictureBox
                    {
                        Size = photoPanel.Size,
                        Location = new Point(0, 0),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Image = Image.FromFile(selectedImagePath)
                    };

                    photoPanel.Controls.Add(pictureBox);
                }
            }
        }

        private void ContinueRegistration(string name, DateTime birthDate, string photoPath)
        {
            // сохранение данных в базе данных или файл
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            UploadPhoto(photoPanel);
        }

        private void continueButton_Click(object sender, EventArgs e)
        {
            DateTime date = new DateTime(2023, 11, 15);
            if (date.Kind == DateTimeKind.Unspecified)
            {
                date = DateTime.SpecifyKind(date, DateTimeKind.Utc);
            }

            var Event = new Event
            {
                Title = "123",
                Description = "123",
                Date = date,
                Time = new TimeSpan(18, 30, 0), 
                Participants = "Иван, Петр, Мария",
                Category = "IT и технологии",
                ImagePath = "C:/Images/event_image.jpg"
            };
            dbContext.Events.Add(Event);
            dbContext.SaveChanges();
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите ваше имя.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (!nameTextBox.Text.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                MessageBox.Show("Имя должно содержать только буквы.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите ваше имя.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (birthDatePicker.Value > DateTime.Now)
            {
                MessageBox.Show("Пожалуйста, выберите корректную дату рождения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(selectedImagePath))
            {
                MessageBox.Show("Пожалуйста, добавьте фотографию.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ContinueRegistration(nameTextBox.Text, birthDatePicker.Value, selectedImagePath);
            AnketsForm nextPage = new AnketsForm();
            nextPage.Size = this.Size;
            nextPage.WindowState = this.WindowState;
            nextPage.StartPosition = FormStartPosition.Manual;
            nextPage.Location = this.Location;
            this.Hide();

            nextPage.FormClosed += (s, args) => Application.Exit();
            nextPage.Show();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }
    }
}
