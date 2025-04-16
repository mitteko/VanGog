using System.Data;
using VanGog.Storage.Core.Entities;
using VanGog.Storage;

namespace VanGog
{
    public partial class MyEventsForm : Form
    {
        private readonly VanGogDbContext _dbContext;
        private List<Event> _myEvents; // события
        private List<int> _subscribedEventIds; // ID событий
        private ContextMenuStrip _contextMenu;
        private Event _selectedEvent;
        
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

        // щелчок ЛКМ
        private void EventPanel_Click(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            _selectedEvent = (Event)panel.Tag;
        }

        // щелчок ПКМ
        private void EventPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Panel panel = (Panel)sender;
                _selectedEvent = (Event)panel.Tag;
                _contextMenu.Show(panel, e.Location);
            }
        }

        // "Изменить" событие
        private void EditEvent_Click(object sender, EventArgs e)
        {
            if (_selectedEvent != null)
            {
                CreateEventForm editForm = new CreateEventForm(_selectedEvent);
                editForm.EventSaved += (s, args) =>
                {
                    LoadEvents();
                    ReturnToAnkets?.Invoke(this, _subscribedEventIds); // обновление анкеты (не обновляется нифига)
                };
                editForm.ShowDialog();
            }
        }

        // "Удалить" событие
        private void DeleteEvent_Click(object sender, EventArgs e)
        {
            if (_selectedEvent != null)
            {
                var result = MessageBox.Show("Вы уверены, что хотите удалить это событие?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // удаление только из списка подписок, а не из базы данных (??? нужно ли из бд)
                        _subscribedEventIds.Remove(_selectedEvent.EventId);
                        _myEvents.Remove(_selectedEvent);
                        DisplayEvents();
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
                    _myEvents = _myEvents.OrderByDescending(ev => ev.Date).ThenBy(ev => ev.Time).ToList();
                    break;
                case 1: // по дате (сначала старые)
                    _myEvents = _myEvents.OrderBy(ev => ev.Date).ThenBy(ev => ev.Time).ToList();
                    break;
                case 2: // по названию
                    _myEvents = _myEvents.OrderBy(ev => ev.Title).ToList();
                    break;
            }
            DisplayEvents();
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
