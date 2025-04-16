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

        // Конструктор для создания нового события
        public CreateEventForm()
        {
            InitializeComponent();
            _dbContext = new VanGogDbContext();

            // Центрируем кнопку загрузки в панели
            uploadButton.Anchor = AnchorStyles.None;
            CenterControlInPanel(uploadButton, photoPanel);

            // Обработчик изменения размера панели для центрирования кнопки
            photoPanel.Resize += (s, e) => CenterControlInPanel(uploadButton, photoPanel);

            // Заполняем комбобокс категорий
            categoryComboBox.Items.AddRange(new object[] {
                "Свидание",
                "Вечеринка",
                "Культурное мероприятие",
                "Спортивное мероприятие",
                "Образовательное мероприятие",
                "Другое"
            });
            categoryComboBox.SelectedIndex = 0;

            // Устанавливаем текущую дату и время
            datePicker.Value = DateTime.Now;
            timePicker.Value = DateTime.Today.AddHours(19); // 19:00 по умолчанию
        }

        // Конструктор для редактирования существующего события
        public CreateEventForm(Event eventToEdit) : this()
        {
            _eventToEdit = eventToEdit;
            titleTextBox.Text = eventToEdit.Title;
            descriptionTextBox.Text = eventToEdit.Description;

            // Устанавливаем дату и время из события
            if (eventToEdit.Date != DateTime.MinValue)
            {
                datePicker.Value = eventToEdit.Date.ToLocalTime();
            }

            if (eventToEdit.Time != TimeSpan.Zero)
            {
                timePicker.Value = DateTime.Today.Add(eventToEdit.Time);
            }

            // Выбираем категорию из списка или устанавливаем "Другое"
            int categoryIndex = categoryComboBox.Items.IndexOf(eventToEdit.Category);
            categoryComboBox.SelectedIndex = categoryIndex >= 0 ? categoryIndex : categoryComboBox.Items.Count - 1;

            // Загружаем изображение, если путь существует
            if (!string.IsNullOrEmpty(eventToEdit.ImagePath) && File.Exists(eventToEdit.ImagePath))
            {
                _selectedImagePath = eventToEdit.ImagePath;
                DisplayImage(_selectedImagePath);
            }

            // Меняем заголовок и текст кнопки
            this.Text = "Редактирование события";
            titleLabel.Text = "Редактирование события";
            saveButton.Text = "Сохранить изменения";
        }

        private void CenterControlInPanel(Control control, Panel panel)
        {
            // Центральная позиция относительно панели
            int centerX = (panel.ClientSize.Width - control.Width) / 2;
            int centerY = (panel.ClientSize.Height - control.Height) / 2;

            control.Location = new Point(centerX, centerY);
        }

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

        private void DisplayImage(string imagePath)
        {
            photoPanel.Controls.Clear();

            PictureBox pictureBox = new PictureBox
            {
                Size = photoPanel.Size,
                Location = new Point(0, 0),
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = Image.FromFile(imagePath)
            };

            photoPanel.Controls.Add(pictureBox);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // Проверка заполнения обязательных полей
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
                // Создаем или обновляем событие
                Event eventItem;

                if (_eventToEdit == null)
                {
                    // Создаем новое событие
                    eventItem = new Event();
                }
                else
                {
                    // Обновляем существующее событие
                    eventItem = _eventToEdit;
                }

                // Заполняем данные события
                eventItem.Title = titleTextBox.Text;
                eventItem.Description = descriptionTextBox.Text;
                eventItem.Date = DateTime.SpecifyKind(datePicker.Value.Date, DateTimeKind.Utc);
                eventItem.Time = timePicker.Value.TimeOfDay;
                eventItem.Category = categoryComboBox.SelectedItem.ToString();
                eventItem.ImagePath = _selectedImagePath;
                eventItem.Participants = ""; // Можно добавить поле для участников в форму

                if (_eventToEdit == null)
                {
                    // Добавляем новое событие в базу данных
                    _dbContext.Events.Add(eventItem);
                }

                // Сохраняем изменения в базе данных
                _dbContext.SaveChanges();

                // Вызываем событие о сохранении
                EventSaved?.Invoke(this, EventArgs.Empty);

                // Закрываем форму
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
