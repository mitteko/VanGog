using VanGog.Storage;
using VanGog.Storage.Core.Entities;

namespace VanGog
{
    /// <summary>
    /// Класс для просмотра анкет
    /// </summary>
    public partial class AnketsForm : Form
    {
        // список событий для просмотра
        private List<Event> events;
        private int currentEventIndex = 0;
        private VanGogDbContext _dbContext;
        // список ID событий, на которые пользователь записался
        private List<int> subscribedEventIds = new List<int>();

        public AnketsForm()
        {
            InitializeComponent();
            _dbContext = new VanGogDbContext();
            LoadEventsFromDatabase();
            DisplayCurrentEvent();
        }

        // загрузка событий из бд
        private void LoadEventsFromDatabase()
        {
            try
            {
                events = _dbContext.Events.ToList();

                if (events.Count == 0)
                {
                    InitializeTestEvents();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке событий из базы данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                InitializeTestEvents();
            }
        }

        // инициализация текущего события
        private void RenderEvent(Event ev)
        {
            // установка изображения
            try
            {
                if (!string.IsNullOrEmpty(ev.ImagePath) && File.Exists(ev.ImagePath))
                {
                    eventPictureBox.Image = Image.FromFile(ev.ImagePath);
                }
                else
                {
                    eventPictureBox.Image = Properties.Resources.placeholder;
                }
            }
            catch
            {
                eventPictureBox.Image = Properties.Resources.placeholder;
            }

            // установка текста
            topicLabel.Text = ev.Title;
            descriptionLabel.Text = ev.Description;
            dateTimeLabel.Text = $"{ev.Date.ToShortDateString()} в {ev.Time.ToString(@"hh\:mm")}";
            
            // активация кнопки "Записаться" (если это не заглушка)
            signUpButton.Enabled = ev.EventId > 0;
        }

        // отображение текущего события
        private void DisplayCurrentEvent()
        {
            if (events.Count == 0)
            {
                MessageBox.Show("Ближайших событий нет.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (currentEventIndex >= events.Count)
            {
                currentEventIndex = 0; // начинаем сначала
                MessageBox.Show("Вы просмотрели все доступные события..", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            RenderEvent(events[currentEventIndex]);
        }

        // инициализация события если в базе данных нет событий
        private void InitializeTestEvents()
        {
            events = new List<Event>
            {
                new Event
                {
                    EventId = -1,
                    Title = "Нет доступных событий",
                    Description = "В данный момент нет доступных событий. Создайте новое событие в разделе 'Мои события'.",
                    Date = DateTime.UtcNow.AddDays(1),
                    Time = new TimeSpan(19, 0, 0),
                    Category = "Информация",
                    ImagePath = string.Empty
                }
            };

            RenderEvent(events[0]); // заглушка
        }

        // "Отклонить"
        private void declineButton_Click(object sender, EventArgs e)
        {
            currentEventIndex++;

            if (currentEventIndex >= events.Count)
            {
                MessageBox.Show("Вы просмотрели все доступные события.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                currentEventIndex = 0; // начинаем сначала
            }

            DisplayCurrentEvent();
        }

        // "Записаться"
        private void signUpButton_Click(object sender, EventArgs e)
        {
            // проверяем, что текущий индекс в пределах списка и это не заглушка
            if (currentEventIndex < events.Count && events[currentEventIndex].EventId > 0)
            {
                var currentEvent = events[currentEventIndex];

                // добавляем ID события в список подписанных
                if (!subscribedEventIds.Contains(currentEvent.EventId))
                {
                    subscribedEventIds.Add(currentEvent.EventId);

                    MessageBox.Show($"Вы успешно записались на событие '{currentEvent.Title}'!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    currentEventIndex++;
                    if (currentEventIndex >= events.Count)
                    {
                        MessageBox.Show("Вы просмотрели все доступные события.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        currentEventIndex = 0;
                    }
                    DisplayCurrentEvent();
                }
                else
                {
                    MessageBox.Show("Вы уже записаны на это событие.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // "Мои события"
        private void myEventsButton_Click(object sender, EventArgs e)
        {
            OpenMyEventsForm();
        }

        private void OpenMyEventsForm()
        {
            // передаем список ID событий, на которые пользователь подписался
            var nextPage = new MyEventsForm(subscribedEventIds);
            nextPage.Size = this.Size;
            nextPage.WindowState = this.WindowState;
            nextPage.StartPosition = FormStartPosition.Manual;
            nextPage.Location = this.Location;

            // подписываемся на событие возврата из формы MyEventsForm
            nextPage.ReturnToAnkets += (s, subscribedIds) =>
            {
                // обновляем список подписанных событий
                subscribedEventIds = subscribedIds;

                // обновляем список событий из базы данных
                LoadEventsFromDatabase();
                DisplayCurrentEvent();

                // показываем форму анкет
                this.Show();
            };

            this.Hide();
            nextPage.Show();
        }
    }
}
