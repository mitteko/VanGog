using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using VanGog.Properties;

namespace VanGog
{
    public partial class AnketsForm : Form
    {
        // список событий для просмотра
        private List<EventItem> events;
        private int currentEventIndex = 0;

        public AnketsForm()
        {
            InitializeComponent();
            InitializeEvents();
            DisplayCurrentEvent();
        }


        // инициализация тестовых данных
        private void InitializeEvents()
        {
            events = new List<EventItem>
            {
                new EventItem
                {
                    ImagePath = @"Images\date1.png",
                    Topic = "Свидание в темноте",
                    Description = "60 минут на ужин в полной темноте."
                },
                new EventItem
                {
                    ImagePath = @"Images\date2.png",
                    Topic = "Свидание на воздушном шаре",
                    Description = "Уникальное свидание на высоте, участники могут насладиться панорамными видами, а затем обсудить свои впечатления."
                },
                new EventItem
                {
                    ImagePath = @"Images\date3.png",
                    Topic = "Свидание на крыше",
                    Description = "Свидание на крыше ресторана с отличным видом на город."
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

            var currentEvent = events[currentEventIndex];

            // установка изображения
            switch (currentEvent.Topic)
            {
                case "Свидание в темноте":
                    eventPictureBox.Image = Properties.Resources.date1;
                    break;
                case "Свидание на воздушном шаре":
                    eventPictureBox.Image = Properties.Resources.date2;
                    break;
                case "Свидание на крыше":
                    eventPictureBox.Image = Properties.Resources.date3;
                    break;
                default:
                    //если нет подходящего изображения
                    eventPictureBox.Image = Properties.Resources.placeholder;
                    break;
            }

            // установка текста
            topicLabel.Text = currentEvent.Topic;
            descriptionLabel.Text = currentEvent.Description;
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
            // Добавляем текущее событие в "Мои события"
            if (currentEventIndex < events.Count)
            {
                // Переход на форму "Мои события"
                OpenMyEventsForm();
            }
        }

        //"Мои события"
        private void myEventsButton_Click(object sender, EventArgs e)
        {
            OpenMyEventsForm();
        }

        private void OpenMyEventsForm()
        {
            MyEventsForm nextPage = new MyEventsForm();
            nextPage.Size = this.Size;
            nextPage.WindowState = this.WindowState;
            nextPage.StartPosition = FormStartPosition.Manual;
            nextPage.Location = this.Location;
            this.Hide();

            nextPage.FormClosed += (s, args) => Application.Exit();
            nextPage.Show();
        }

        private void AnketsForm_Load(object sender, EventArgs e)
        {

        }
    }

    // класс для хранения информации о событии (на будущее для аккаунта)
    public class EventItem
    {
        public string ImagePath { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
    }
}
