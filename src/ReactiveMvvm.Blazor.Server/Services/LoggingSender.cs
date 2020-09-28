using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ReactiveMvvm.Interfaces;

namespace ReactiveMvvm.Blazor.Server.Services
{
    public class LoggingSender : ISender
    {
        private readonly ILogger<LoggingSender> _logger;

        public LoggingSender(ILogger<LoggingSender> logger) => _logger = logger;

        public Task Send(string title, string message, int section, bool bug)
        {
            _logger.LogInformation($"Title: {title}");
            _logger.LogInformation($"Message: {message}");
            _logger.LogInformation($"Metadata: {section} {bug}");
            return Task.CompletedTask;
        }
    }
}