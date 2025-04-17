using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using VanGog.Storage;
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
                // ������������� ���������� � ���������� ��������
                var initializer = new ApplicationInitializer();
                initializer.StartApplication();

                Application.Run(new RegistrationForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� ������� ����������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}