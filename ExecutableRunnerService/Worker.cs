using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace ExecutableRunnerService
{
    public class Worker : BackgroundService
    {
        private Process? _BrainCropService_Process;
        private Process? _UI_Process;

        private readonly IConfiguration _configuration;

        public Worker(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, "sample.bat");

            string executableFilePath = _configuration.GetValue<string>("ExecutableFilePath");

            // Start BrainCrop Service
            _BrainCropService_Process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/k \"" + filePath + "\"", // "/k" to remain open
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };
            _BrainCropService_Process.Start();

            // Wait for 10 seconds
            await Task.Delay(TimeSpan.FromSeconds(10));

            // Start BrainCrop UI
            _UI_Process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = executableFilePath,
                    Arguments = "www.google.com",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };
            _UI_Process.Start();

            // Wait for the second process to complete

            // Wait for both processes to complete
            await Task.WhenAll(_BrainCropService_Process.WaitForExitAsync(stoppingToken), _UI_Process.WaitForExitAsync(stoppingToken));
        }

        public override void Dispose()
        {
            if (!_BrainCropService_Process.HasExited)
            {
                _BrainCropService_Process.Kill();
            }

            if (!_UI_Process.HasExited)
            {
                _UI_Process.Kill();
            }

            base.Dispose();
        }
    }
}