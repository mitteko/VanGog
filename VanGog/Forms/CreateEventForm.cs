using VanGog.Storage.Core.Entities;
using VanGog.Storage;

namespace VanGog
{
    public partial class CreateEventForm : Form
    {
        private readonly VanGogDbContext _dbContext;
        private string _selectedImagePath = string.Empty;
        private Event _eventToEdit;
        public event EventHandler EventSaved;

        // конструктор 1 для создания нового события
        public CreateEventForm()
        {
            InitializeComponent();
            _dbContext = new VanGogDbContext();

            uploadButton.Anchor = AnchorStyles.None;
            photoPanel.Resize += (s, e) => CenterControlInPanel(uploadButton, photoPanel);

            // категории (?)
            categoryComboBox.Items.AddRange(new object[] {
                "Свидание",
                "Вечеринка",
                "Культурное мероприятие",
                "Спортивное мероприятие",
                "Образовательное мероприятие",
                "Другое"
            });
            categoryComboBox.SelectedIndex = 0;

            // текущая дата и время
            datePicker.Value = DateTime.Now;
            timePicker.Value = DateTime.Today.AddHours(19);
        }

        // конструктор 2 для редактирования существующего события (но что то не то... не работает) ???
        public CreateEventForm(Event eventToEdit) : this()
        {
            _eventToEdit = eventToEdit;
            titleTextBox.Text = eventToEdit.Title;
            descriptionTextBox.Text = eventToEdit.Description;
            
            // установка даты и времени
            if (eventToEdit.Date != DateTime.MinValue)
            {
                datePicker.Value = eventToEdit.Date.ToLocalTime();
            }
            if (eventToEdit.Time != TimeSpan.Zero)
            {
                timePicker.Value = DateTime.Today.Add(eventToEdit.Time);
            }

            // категория из списка или "Другое"
            int categoryIndex = categoryComboBox.Items.IndexOf(eventToEdit.Category);
            categoryComboBox.SelectedIndex = categoryIndex >= 0 ? categoryIndex : categoryComboBox.Items.Count - 1;

            // !!! надо будет добавить кнопку удалить фотку, чтоб можно было поменять 
            if (!string.IsNullOrEmpty(eventToEdit.ImagePath) && File.Exists(eventToEdit.ImagePath))
            {
                _selectedImagePath = eventToEdit.ImagePath;
                DisplayImage(_selectedImagePath);
            }

            this.Text = "Редактирование события";
            titleLabel.Text = "Редактирование события";
        }

        private void CenterControlInPanel(Control control, Panel panel)
        {
            int centerX = (panel.ClientSize.Width - control.Width) / 2;
            int centerY = (panel.ClientSize.Height - control.Height) / 2;

            control.Location = new Point(centerX, centerY);
        }

        private void DisplayImage(string imagePath)
        {
            photoPanel.Controls.Clear();

            PictureBox pictureBox = new PictureBox
            {
                Dock = DockStyle.Fill, // зум картинки на весь пикчр бокс
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = Image.FromFile(imagePath)
            };

            photoPanel.Controls.Add(pictureBox);
        }

        // "Выбрать изображение"
        private void uploadButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.Title = "Выберите изображение";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _selectedImagePath = openFileDialog.FileName;
                    DisplayImage(_selectedImagePath);
                }
            }
        }

        // сохр-е события
        private void saveButton_Click(object sender, EventArgs e)
        {
            // проверка заполнения обязательных полей
            if (string.IsNullOrWhiteSpace(titleTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите тематику свидания.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(descriptionTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите описание свидания.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(_selectedImagePath))
            {
                MessageBox.Show("Пожалуйста, добавьте фотографию.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Event eventItem;

                if (_eventToEdit == null)
                {
                    eventItem = new Event();
                }
                else
                {
                    eventItem = _eventToEdit;
                }

                eventItem.Title = titleTextBox.Text;
                eventItem.Description = descriptionTextBox.Text;
                eventItem.Date = DateTime.SpecifyKind(datePicker.Value.Date, DateTimeKind.Utc);
                eventItem.Time = timePicker.Value.TimeOfDay;
                eventItem.Category = categoryComboBox.SelectedItem.ToString();
                eventItem.ImagePath = _selectedImagePath;

                if (_eventToEdit == null)
                {
                    _dbContext.Events.Add(eventItem); // добавляем новое событие в бд
                }

                _dbContext.SaveChanges();
                EventSaved?.Invoke(this, EventArgs.Empty); // вызываем событие о сохранении

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении события: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
