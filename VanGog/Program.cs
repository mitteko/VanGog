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

            // ��������� DI � ��������
            var services = ConfigureServices();
            using (var serviceProvider = services.BuildServiceProvider())
            {
                try
                {
                    var initializer = serviceProvider.GetRequiredService<ApplicationInitializer>();
                    initializer.StartApplication(serviceProvider);

                    var registrationForm = serviceProvider.GetRequiredService<RegistrationForm>();
                    Application.Run(registrationForm);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"������ ��� ������� ����������: {ex.Message}",
                        "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();

            // ���������� ��������� ���� ������
            string connectionString = "Host=localhost;Port=5432;Database=vangog-db;User ID=postgres;Password=902692A2006UN951967;"; 
            services.AddDbContextPool<VanGogDbContext>(options =>
            {
                options.UseNpgsql(connectionString,
                    opt => opt.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(15),
                        errorCodesToAdd: null)
                    .UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery));
            },50);

            // ���������� �������
            services.AddLogging(logging =>
            {
                logging.AddConsole(); // ���� � �������
                logging.SetMinimumLevel(LogLevel.Information); // ������� �����������
            });

            // ����������� ����� � ��������������
            services.AddTransient<RegistrationForm>();
            services.AddTransient<ApplicationInitializer>();

            return services;
        }
    }
}