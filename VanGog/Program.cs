using VanGogRegistration;

namespace VanGog
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // инициализация приложения и применение миграций
                var initializer = new ApplicationInitializer();
                initializer.StartApplication();

                Application.Run(new RegistrationForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при запуске приложения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}