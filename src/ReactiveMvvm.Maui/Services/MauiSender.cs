// Copyright (c) 2019-2026 ReactiveUI and Contributors. All rights reserved.
// ReactiveUI and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using ReactiveMvvm.Interfaces;

namespace ReactiveMvvm.Maui.Services;

/// <summary>Displays submitted feedback in a MAUI alert.</summary>
/// <param name="view">The page that displays feedback alerts.</param>
public sealed class MauiSender(Page view) : ISender
{
    /// <inheritdoc/>
    public async Task Send(string title, string message, int section, bool bug)
    {
        var content = $"{message}, Bug: {bug}, Section: {section}";
        await view.DisplayAlertAsync(title, content, "Ok");
    }
}
