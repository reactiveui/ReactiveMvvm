// Copyright (c) 2019-2026 ReactiveUI and Contributors. All rights reserved.
// ReactiveUI and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Threading.Tasks;
using System.Windows;
using ReactiveMvvm.Interfaces;

namespace ReactiveMvvm.Wpf.Services;

/// <summary>Displays submitted feedback in a WPF message box.</summary>
public sealed class WpfSender : ISender
{
    /// <inheritdoc/>
    public Task Send(string title, string message, int section, bool bug)
    {
        var content = $"{message}, Bug: {bug}, Section: {section}";
        _ = MessageBox.Show(content, title);
        return Task.CompletedTask;
    }
}
