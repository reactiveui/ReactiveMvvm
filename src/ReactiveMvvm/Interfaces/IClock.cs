// Copyright (c) 2019-2026 ReactiveUI and Contributors. All rights reserved.
// ReactiveUI and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;

namespace ReactiveMvvm.Interfaces;

/// <summary>Provides observable elapsed seconds.</summary>
public interface IClock
{
    /// <summary>Gets the sequential ticks emitted by the clock.</summary>
    IObservable<long> Tick { get; }
}
