// Copyright (c) 2019-2026 ReactiveUI and Contributors. All rights reserved.
// ReactiveUI and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Threading.Tasks;

namespace ReactiveMvvm.Interfaces;

/// <summary>Submits feedback through a platform service.</summary>
public interface ISender
{
    /// <summary>Sends the entered feedback.</summary>
    /// <param name = "title">The feedback title.</param>
    /// <param name = "message">The feedback message.</param>
    /// <param name = "section">The selected category.</param>
    /// <param name = "bug">Whether the feedback describes an issue.</param>
    /// <returns>A task that completes when the feedback is sent.</returns>
    Task Send(string title, string message, int section, bool bug);
}
