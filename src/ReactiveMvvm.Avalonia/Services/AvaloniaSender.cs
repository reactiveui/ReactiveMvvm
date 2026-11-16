// Copyright (c) 2019-2026 ReactiveUI and Contributors. All rights reserved.
// ReactiveUI and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Media;
using ReactiveMvvm.Interfaces;

namespace ReactiveMvvm.Avalonia.Services;

/// <summary>Displays submitted feedback in an Avalonia dialog.</summary>
[System.Diagnostics.DebuggerDisplay("AvaloniaSender: {_window}")]
public sealed class AvaloniaSender : ISender
{
    /// <summary>The feedback dialog's width and height in logical pixels.</summary>
    private const int DialogSize = 200;

    /// <summary>The padding around the feedback text.</summary>
    private const int ContentPadding = 10;

    /// <summary>Owns the modal feedback dialog.</summary>
    private readonly Window _window;

    /// <summary>Initializes a new instance of the AvaloniaSender class.</summary>
    /// <param name="window">The owner of the feedback dialog.</param>
    public AvaloniaSender(Window window) => _window = window;

    /// <inheritdoc/>
    public async Task Send(string title, string message, int section, bool bug)
    {
        var classification = bug ? "issue" : "idea";
        var dialog = new Window
        {
            Width = DialogSize,
            Height = DialogSize,
            Content = new StackPanel { Margin = new(ContentPadding), Children = { new TextBlock { Text = $"[{classification}] {title}: {message}", TextWrapping = TextWrapping.Wrap } } },
        };
        await dialog.ShowDialog(_window);
    }
}
