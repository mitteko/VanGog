using System.Data;
using VanGog.Storage.Core.Entities;
using VanGog.Storage;

namespace VanGog
{
    public partial class MyEventsForm : Form
    {
        private readonly VanGogDbContext _dbContext;
        private List<Event> _myEvents; // События
        private List<int> _subscribedEventIds; // ID событий
        private ContextMenuStrip _contextMenu;
        private Event _selectedEvent;

        // Событие для возврата к форме анкет
        public event EventHandler<List<int>> ReturnToAnkets;

        public MyEventsForm(List<int> subscribedEventIds = null)
        {
            InitializeComponent();
            _dbContext = new VanGogDbContext();
            LoadEvents();
            SetupContextMenu();
        }

        private void LoadEvents()
        {
            try
            {
                _myEvents = _dbContext.Events.ToList();
                DisplayEvents();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке событий: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayEvents()
        {
            eventsListPanel.Controls.Clear();

            if (_myEvents.Count == 0)
            {
                Label noEventsLabel = new Label
                {
                    Text = "У вас пока нет событий",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 12),
                    ForeColor = Color.Gray,
                    Location = new Point(20, 20)
                };
                eventsListPanel.Controls.Add(noEventsLabel);
                return;
            }

            int yPos = 10;
            foreach (var eventItem in _myEvents)
            {
                Panel eventPanel = new Panel
                {
                    Width = eventsListPanel.Width - 40,
                    Height = 50,
                    BackColor = Color.FromArgb(220, 180, 200),
                    Location = new Point(10, yPos)
                };

                Label eventLabel = new Label
                {
                    Text = $"• {eventItem.Date.ToShortDateString()} {eventItem.Time.ToString(@"hh\:mm")} ({eventItem.Title})",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10),
                    Location = new Point(10, 15)
                };

                eventPanel.Controls.Add(eventLabel);
                eventPanel.Tag = eventItem;
                eventPanel.Click += EventPanel_Click;
                eventPanel.MouseDown += EventPanel_MouseDown;

                eventsListPanel.Controls.Add(eventPanel);
                yPos += 60;
            }
        }

        private void SetupContextMenu()
        {
            _contextMenu = new ContextMenuStrip();
            _contextMenu.Items.Add("Изменить", null, EditEvent_Click);
            _contextMenu.Items.Add("Удалить", null, DeleteEvent_Click);
        }

        private void EventPanel_Click(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            _selectedEvent = (Event)panel.Tag;
        }

        private void EventPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Panel panel = (Panel)sender;
                _selectedEvent = (Event)panel.Tag;
                _contextMenu.Show(panel, e.Location);
            }
        }

        private void EditEvent_Click(object sender, EventArgs e)
        {
            if (_selectedEvent != null)
            {
                CreateEventForm editForm = new CreateEventForm(_selectedEvent);
                editForm.EventSaved += (s, args) =>
                {
                    LoadEvents();
                    ReturnToAnkets?.Invoke(this, _subscribedEventIds); // Обновление анкеты
                };
                editForm.ShowDialog();
            }
        }

        private void DeleteEvent_Click(object sender, EventArgs e)
        {
            if (_selectedEvent != null)
            {
                var result = MessageBox.Show("Вы уверены, что хотите удалить это событие?",
                    "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Удаление только из списка подписок, а не из базы данных (??? нужно ли из бд)
                        _subscribedEventIds.Remove(_selectedEvent.EventId);
                        _myEvents.Remove(_selectedEvent);
                        DisplayEvents();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении события: {ex.Message}",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void createEventButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            createEventButton_Click(sender, e);
        }

        private void createEventButton_Click(object sender, EventArgs e)
        {
            CreateEventForm createForm = new CreateEventForm();
            createForm.EventSaved += (s, args) =>
            {
                LoadEvents();
            };
            createForm.ShowDialog();
        }

        private void backToAnketsButton_Click(object sender, EventArgs e)
        {
            // Вызываем событие возврата к форме анкет и передаем список подписанных событий
            ReturnToAnkets?.Invoke(this, _subscribedEventIds);

            // Скрываем текущую форму (не закрываем, чтобы не вызвать Application.Exit())
            this.Hide();
        }

        private void sortComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (sortComboBox.SelectedIndex)
            {
                case 0: // По дате (сначала новые)
                    _myEvents = _myEvents.OrderByDescending(ev => ev.Date).ThenBy(ev => ev.Time).ToList();
                    break;
                case 1: // По дате (сначала старые)
                    _myEvents = _myEvents.OrderBy(ev => ev.Date).ThenBy(ev => ev.Time).ToList();
                    break;
                case 2: // По названию
                    _myEvents = _myEvents.OrderBy(ev => ev.Title).ToList();
                    break;
            }
            DisplayEvents();
        }

        // Переопределяем метод FormClosed, чтобы не вызывать Application.Exit()
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            // Если форма закрывается, но не через кнопку "Вернуться к анкетам",
            // вызываем событие ReturnToAnkets
            if (ReturnToAnkets != null && this.Visible)
            {
                ReturnToAnkets(this, _subscribedEventIds);
            }
        }
    }
}
