using System.Data;
using VanGog.Storage.Core.Entities;
using VanGog.Storage;

namespace VanGog
{
    public partial class MyEventsForm : Form
    {
        private readonly VanGogDbContext _dbContext;
        private List<Event> _allEvents; // все события из БД
        private List<Event> _subscribedEvents; // события, на которые пользователь подписан
        private List<Event> _createdEvents; // события, созданные пользователем
        private List<int> _subscribedEventIds; // ID событий, на которые пользователь подписан
        private ContextMenuStrip _subscribedContextMenu; // контекстное меню для подписанных событий
        private ContextMenuStrip _createdContextMenu; // контекстное меню для созданных событий
        private Event _selectedEvent;
        private Panel _activePanel; // текущая активная панель (для определения контекста)

        public event EventHandler<List<int>> ReturnToAnkets; // событие для возврата к форме анкет (чтоб синхронизировать события)

        public MyEventsForm(List<int> subscribedEventIds = null)
        {
            InitializeComponent();
            _dbContext = new VanGogDbContext();
            if (subscribedEventIds != null)
            {
                _subscribedEventIds = subscribedEventIds;
            }
            else
            {
                _subscribedEventIds = new List<int>();
            }
            LoadEvents();
            SetupContextMenus();
        }

        private void LoadEvents()
        {
            try
            {
                // загружаем все события из БД
                _allEvents = _dbContext.Events.ToList();

                // фильтруем события, на которые пользователь подписан
                _subscribedEvents = _allEvents.Where(e => _subscribedEventIds.Contains(e.EventId)).ToList();

                // фильтруем события, созданные пользователем
                _createdEvents = _allEvents.Where(e => !string.IsNullOrEmpty(e.CreatorId) && e.CreatorId == Environment.MachineName).ToList();

                DisplaySubscribedEvents();
                DisplayCreatedEvents();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке событий: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupContextMenus()
        {
            // меню для подписанных событий (только удаление из списка)
            _subscribedContextMenu = new ContextMenuStrip();
            _subscribedContextMenu.Items.Add("Удалить из списка", null, RemoveSubscribedEvent_Click);

            // меню для созданных событий (изменение и удаление)
            _createdContextMenu = new ContextMenuStrip();
            _createdContextMenu.Items.Add("Изменить", null, EditCreatedEvent_Click);
            _createdContextMenu.Items.Add("Удалить", null, DeleteCreatedEvent_Click);
        }

        private void DisplaySubscribedEvents()
        {
            subscribedEventsPanel.Controls.Clear();

            if (_subscribedEvents.Count == 0)
            {
                Label noEventsLabel = new Label
                {
                    Text = "У вас пока нет добавленных событий",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10),
                    ForeColor = Color.Gray,
                    Location = new Point(20, 20)
                };
                subscribedEventsPanel.Controls.Add(noEventsLabel);
                return;
            }

            int yPos = 10;
            foreach (var eventItem in _subscribedEvents)
            {
                Panel eventPanel = CreateEventPanel(eventItem, subscribedEventsPanel.Width - 20);
                eventPanel.Location = new Point(10, yPos);
                eventPanel.Tag = eventItem;
                eventPanel.Click += (s, e) => EventPanel_Click(s, e, subscribedEventsPanel);
                eventPanel.MouseDown += (s, e) => EventPanel_MouseDown(s, e, _subscribedContextMenu);

                subscribedEventsPanel.Controls.Add(eventPanel);
                yPos += 60;
            }
        }

        private void DisplayCreatedEvents()
        {
            createdEventsPanel.Controls.Clear();

            if (_createdEvents.Count == 0)
            {
                Label noEventsLabel = new Label
                {
                    Text = "У вас пока нет созданных событий",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10),
                    ForeColor = Color.Gray,
                    Location = new Point(20, 20)
                };
                createdEventsPanel.Controls.Add(noEventsLabel);
                return;
            }

            int yPos = 10;
            foreach (var eventItem in _createdEvents)
            {
                Panel eventPanel = CreateEventPanel(eventItem, createdEventsPanel.Width - 20);
                eventPanel.Location = new Point(10, yPos);
                eventPanel.Tag = eventItem;
                eventPanel.Click += (s, e) => EventPanel_Click(s, e, createdEventsPanel);
                eventPanel.MouseDown += (s, e) => EventPanel_MouseDown(s, e, _createdContextMenu);

                createdEventsPanel.Controls.Add(eventPanel);
                yPos += 60;
            }
        }

        private Panel CreateEventPanel(Event eventItem, int width)
        {
            Panel eventPanel = new Panel
            {
                Width = width,
                Height = 50,
                BackColor = Color.FromArgb(220, 180, 200),
                Cursor = Cursors.Hand
            };

            Label eventLabel = new Label
            {
                Text = $"• {eventItem.Date.ToShortDateString()} {eventItem.Time.ToString(@"hh\:mm")} ({eventItem.Title})",
                AutoSize = true,
                Font = new Font("Segoe UI", 10),
                Location = new Point(10, 15)
            };

            eventPanel.Controls.Add(eventLabel);
            return eventPanel;
        }

        // ЛКМ
        private void EventPanel_Click(object sender, EventArgs e, Panel parentPanel)
        {
            Panel panel = (Panel)sender;
            _selectedEvent = (Event)panel.Tag;
            _activePanel = parentPanel;
        }

        // ПКМ
        private void EventPanel_MouseDown(object sender, MouseEventArgs e, ContextMenuStrip contextMenu)
        {
            if (e.Button == MouseButtons.Right)
            {
                Panel panel = (Panel)sender;
                _selectedEvent = (Event)panel.Tag;
                contextMenu.Show(panel, e.Location);
            }
        }

        // удаление события из списка подписанных
        private void RemoveSubscribedEvent_Click(object sender, EventArgs e)
        {
            if (_selectedEvent != null)
            {
                var result = MessageBox.Show("Вы уверены, что хотите удалить это событие из списка добавленных?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Удаляем только из списка подписок, не из БД
                        _subscribedEventIds.Remove(_selectedEvent.EventId);
                        _subscribedEvents.Remove(_selectedEvent);
                        DisplaySubscribedEvents();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении события: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // редактирование созданного события
        private void EditCreatedEvent_Click(object sender, EventArgs e)
        {
            if (_selectedEvent != null)
            {
                CreateEventForm editForm = new CreateEventForm(_selectedEvent);
                editForm.EventSaved += (s, args) =>
                {
                    LoadEvents();
                };
                editForm.ShowDialog();
            }
        }

        // удаление созданного события
        private void DeleteCreatedEvent_Click(object sender, EventArgs e)
        {
            if (_selectedEvent != null)
            {
                var result = MessageBox.Show("Вы уверены, что хотите удалить это событие? Это действие нельзя отменить.", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // удаляем из БД
                        _dbContext.Events.Remove(_selectedEvent);
                        _dbContext.SaveChanges();

                        // удаляем из списка подписок, если оно там есть
                        if (_subscribedEventIds.Contains(_selectedEvent.EventId))
                        {
                            _subscribedEventIds.Remove(_selectedEvent.EventId);
                        }

                        LoadEvents();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении события: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // "Создать событие"
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

        // "Вернуться к анкетам"
        private void backToAnketsButton_Click(object sender, EventArgs e)
        {
            // вызов события возврата к форме анкет. передача списка подписанных событий
            ReturnToAnkets?.Invoke(this, _subscribedEventIds);
            this.Hide();
        }

        // сортировка событий
        private void sortComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (sortComboBox.SelectedIndex)
            {
                case 0: // по дате (сначала новые)
                    _subscribedEvents = _subscribedEvents.OrderByDescending(ev => ev.Date).ThenBy(ev => ev.Time).ToList();
                    _createdEvents = _createdEvents.OrderByDescending(ev => ev.Date).ThenBy(ev => ev.Time).ToList();
                    break;
                case 1: // по дате (сначала старые)
                    _subscribedEvents = _subscribedEvents.OrderBy(ev => ev.Date).ThenBy(ev => ev.Time).ToList();
                    _createdEvents = _createdEvents.OrderBy(ev => ev.Date).ThenBy(ev => ev.Time).ToList();
                    break;
                case 2: // по названию
                    _subscribedEvents = _subscribedEvents.OrderBy(ev => ev.Title).ToList();
                    _createdEvents = _createdEvents.OrderBy(ev => ev.Title).ToList();
                    break;
            }

            DisplaySubscribedEvents();
            DisplayCreatedEvents();
        }

        // переопределение крестика(закрытие)
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            // если форма закрывается через крестик вызываем событие ReturnToAnkets
            if (ReturnToAnkets != null && this.Visible)
            {
                ReturnToAnkets(this, _subscribedEventIds);
            }
        }
    }
}
