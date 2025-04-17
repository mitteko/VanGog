using VanGog;
using VanGog.Storage;
namespace VanGogRegistration
{
    /// <summary>
    /// Класс формы регистрации
    /// </summary>
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

        private void uploadButton_Click(object sender, EventArgs e)
        {
            UploadPhoto(photoPanel);
        }

        private void continueButton_Click(object sender, EventArgs e)
        {
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

            AnketsForm nextPage = new AnketsForm();
            nextPage.Size = this.Size;
            nextPage.WindowState = this.WindowState;
            nextPage.StartPosition = FormStartPosition.Manual;
            nextPage.Location = this.Location;
            this.Hide();

            nextPage.FormClosed += (s, args) => Application.Exit();
            nextPage.Show();
        }
    }
}
