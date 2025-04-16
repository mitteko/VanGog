using VanGog.Storage;
using VanGog.Storage.Core.Entities;

namespace VanGog
{
    public partial class AnketsForm : Form
    {
        // список событий для просмотра
        private List<Event> events;
        private int currentEventIndex = 0;
        private VanGogDbContext _dbContext;
        // Список ID событий, на которые пользователь записался
        private List<int> subscribedEventIds = new List<int>();

        public AnketsForm()
        {
            InitializeComponent();
            _dbContext = new VanGogDbContext();
            LoadEventsFromDatabase();
            DisplayCurrentEvent();
        }


        // загрузка событий из базы данных
        private void LoadEventsFromDatabase()
        {
            try
            {
                _dbContext.Dispose(); // если ты его не переиспользуешь больше
                _dbContext = new VanGogDbContext(); // пересоздаём
                events = _dbContext.Events.ToList();

                // Если в базе нет событий, используем тестовые данные
                if (events.Count == 0)
                {
                    InitializeTestEvents();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке событий из базы данных: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                InitializeTestEvents();
            }
        }

        // инициализация тестовых данных
        private void InitializeTestEvents()
        {
            events = new List<Event>
            {
                new Event
                {
                    EventId = -1, // Отрицательный ID для обозначения тестового события
                    Title = "Нет доступных событий",
                    Description = "В данный момент нет доступных событий. Создайте новое событие в разделе 'Мои события'.",
                    Date = DateTime.UtcNow.AddDays(1),
                    Time = new TimeSpan(19, 0, 0),
                    Category = "Информация",
                    Participants = "",
                    ImagePath = "" // Будет использоваться изображение-заглушка
                }
            };
        }

        // отображение текущего события
        private void DisplayCurrentEvent()
        {
            if (events.Count == 0 || currentEventIndex >= events.Count)
            {
                MessageBox.Show("Больше событий нет.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (currentEventIndex >= events.Count)
            {
                currentEventIndex = 0; // Начинаем сначала
                MessageBox.Show("Вы просмотрели все доступные события. Начинаем сначала.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            var currentEvent = events[currentEventIndex];

            // установка изображения
            try
            {
                if (!string.IsNullOrEmpty(currentEvent.ImagePath) && System.IO.File.Exists(currentEvent.ImagePath))
                {
                    eventPictureBox.Image = Image.FromFile(currentEvent.ImagePath);
                }
                else
                {
                    // Если файл не найден, используем изображение по умолчанию
                    eventPictureBox.Image = Properties.Resources.placeholder;
                }
            }
            catch
            {
                eventPictureBox.Image = Properties.Resources.placeholder;
            }

            // установка текста
            topicLabel.Text = currentEvent.Title;
            descriptionLabel.Text = currentEvent.Description;

            // Отображение даты и времени события
            dateTimeLabel.Text = $"{currentEvent.Date.ToShortDateString()} в {currentEvent.Time.ToString(@"hh\:mm")}";

            // Если это заглушка или пользователь уже записан на это событие, деактивируем кнопку "Записаться"
            signUpButton.Enabled = currentEvent.EventId > 0;
        }

        // Очистка отображения события
        private void ClearEventDisplay()
        {
            eventPictureBox.Image = Properties.Resources.placeholder;
            topicLabel.Text = "Нет доступных событий";
            descriptionLabel.Text = "В данный момент нет доступных событий.";
            dateTimeLabel.Text = "";
            signUpButton.Enabled = false;
        }

        //"Отклонить"
        private void declineButton_Click(object sender, EventArgs e)
        {
            currentEventIndex++;

            if (currentEventIndex >= events.Count)
            {
                MessageBox.Show("Вы просмотрели все доступные события.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                currentEventIndex = 0; // Начинаем сначала
            }

            DisplayCurrentEvent();
        }

        //"Записаться"
        private void signUpButton_Click(object sender, EventArgs e)
        {
            // Проверяем, что текущий индекс в пределах списка и это не заглушка
            if (currentEventIndex < events.Count && events[currentEventIndex].EventId > 0)
            {
                var currentEvent = events[currentEventIndex];

                // Добавляем текущее событие в "Мои события"
                if (currentEventIndex < events.Count)
                {
                    MessageBox.Show("Вы успешно записались на событие!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // Добавляем ID события в список подписанных
                if (!subscribedEventIds.Contains(currentEvent.EventId))
                {
                    subscribedEventIds.Add(currentEvent.EventId);

                    // Сохраняем информацию о подписке в UserSettings или другое хранилище

                    MessageBox.Show($"Вы успешно записались на событие '{currentEvent.Title}'!",
                        "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Деактивируем кнопку "Записаться" для этого события
                    signUpButton.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Вы уже записаны на это событие.",
                        "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        //"Мои события"
        private void myEventsButton_Click(object sender, EventArgs e)
        {
            OpenMyEventsForm();
        }

        private void OpenMyEventsForm()
        {
            // Передаем список ID событий, на которые пользователь подписался
            MyEventsForm nextPage = new MyEventsForm(subscribedEventIds);
            nextPage.Size = this.Size;
            nextPage.WindowState = this.WindowState;
            nextPage.StartPosition = FormStartPosition.Manual;
            nextPage.Location = this.Location;

            // Подписываемся на событие возврата из формы MyEventsForm
            nextPage.ReturnToAnkets += (s, subscribedIds) =>
            {
                // Обновляем список подписанных событий
                subscribedEventIds = subscribedIds;

                // Обновляем список событий из базы данных
                LoadEventsFromDatabase();
                DisplayCurrentEvent();

                // Показываем форму анкет
                this.Show();
            };

            this.Hide();
            nextPage.Show();
        }

        private void AnketsForm_Load(object sender, EventArgs e)
        {

        }

    }
}
