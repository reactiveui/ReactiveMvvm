// Copyright (c) 2019-2026 ReactiveUI and Contributors. All rights reserved.
// ReactiveUI and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ReactiveMvvm.Interfaces;

namespace ReactiveMvvm.Blazor.Services;

/// <summary>Writes submitted feedback to the application's logger.</summary>
[System.Diagnostics.DebuggerDisplay("LoggingSender: {_logger}")]
public sealed partial class LoggingSender : ISender
{
    /// <summary>Writes submitted feedback to the host log.</summary>
    private readonly ILogger<LoggingSender> _logger;

    /// <summary>Initializes a new instance of the LoggingSender class.</summary>
    /// <param name="logger">The host logger.</param>
    public LoggingSender(ILogger<LoggingSender> logger) => _logger = logger;

    /// <inheritdoc/>
    public Task Send(string title, string message, int section, bool bug)
    {
        LogFeedback(title, message, section, bug);
        return Task.CompletedTask;
    }

    /// <summary>Writes the submitted feedback as structured log fields.</summary>
    /// <param name="title">The feedback title.</param>
    /// <param name="message">The feedback message.</param>
    /// <param name="section">The selected category.</param>
    /// <param name="bug">Whether the feedback describes an issue.</param>
    [LoggerMessage(Level = LogLevel.Information, Message = "Feedback {Title}: {Message}; section {Section}; issue {Bug}")]
    private partial void LogFeedback(string title, string message, int section, bool bug);
}
