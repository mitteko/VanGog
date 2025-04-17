namespace VanGog.Excel
{
    /// <summary>
    /// Класс для фильтрации отчета по событиям
    /// </summary>
    public partial class EventFilterForm : Form
    {
        public DateTime? StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public string Category { get; private set; }
        public bool IncludeSubscribed { get; private set; }
        public bool IncludeCreated { get; private set; }

        private List<string> _categories;

        public EventFilterForm(List<string> categories)
        {
            InitializeComponent();
            _categories = categories;

            // категории
            categoryComboBox.Items.Add("Все категории");
            foreach (var category in categories)
            {
                categoryComboBox.Items.Add(category);
            }
            categoryComboBox.SelectedIndex = 0;

            // значения по умолчанию
            startDatePicker.Value = DateTime.Now.AddMonths(-1);
            endDatePicker.Value = DateTime.Now;
            subscribedCheckBox.Checked = true;
            createdCheckBox.Checked = true;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            // проверка дат
            if (useDateFilterCheckBox.Checked && startDatePicker.Value > endDatePicker.Value)
            {
                MessageBox.Show("Дата начала не может быть позже даты окончания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (useDateFilterCheckBox.Checked)
            {
                StartDate = startDatePicker.Value;
                EndDate = endDatePicker.Value;
            }
            else
            {
                StartDate = null;
                EndDate = null;
            }

            if (categoryComboBox.SelectedIndex > 0)
            {
                Category = categoryComboBox.SelectedItem.ToString();
            }
            else
            {
                Category = null;
            }

            IncludeSubscribed = subscribedCheckBox.Checked;
            IncludeCreated = createdCheckBox.Checked;

            if (!IncludeSubscribed && !IncludeCreated)
            {
                MessageBox.Show("Выберите хотя бы один тип событий", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void useDateFilterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            startDatePicker.Enabled = useDateFilterCheckBox.Checked;
            endDatePicker.Enabled = useDateFilterCheckBox.Checked;
            startDateLabel.Enabled = useDateFilterCheckBox.Checked;
            endDateLabel.Enabled = useDateFilterCheckBox.Checked;
        }
    }
}
