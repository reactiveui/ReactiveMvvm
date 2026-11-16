// Copyright (c) 2019-2026 ReactiveUI and Contributors. All rights reserved.
// ReactiveUI and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ReactiveMvvm.Interfaces;

namespace ReactiveMvvm.Terminal.Services;

/// <summary>Completes submissions in the terminal demonstration.</summary>
public sealed class TerminalSender : ISender
{
    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Task Send(string title, string message, int section, bool bug) => Task.CompletedTask;
}
