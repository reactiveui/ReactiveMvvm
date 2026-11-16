// Copyright (c) 2019-2026 ReactiveUI and Contributors. All rights reserved.
// ReactiveUI and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Runtime.CompilerServices;

namespace ReactiveMvvm.Terminal;

/// <summary>Arranges terminal controls in a vertical feedback form.</summary>
public static class Extensions
{
    /// <summary>Adds a control below the previous control.</summary>
    /// <typeparam name="TOwner">The parent view type.</typeparam>
    /// <typeparam name="TOld">The previous control type.</typeparam>
    /// <param name="owner">The previous control and its parent view.</param>
    extension<TOwner, TOld>(MemoizedElement<TOwner, TOld> owner)
        where TOwner : View
        where TOld : View
    {
        /// <summary>Adds a control on the next row.</summary>
        /// <typeparam name="TNew">The new control type.</typeparam>
        /// <param name="control">The control to add.</param>
        /// <returns>The added control and its parent view.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MemoizedElement<TOwner, TNew> Append<TNew>(TNew control)
            where TNew : View => owner.Append(control, 1);

        /// <summary>Adds a control at the specified vertical offset.</summary>
        /// <typeparam name="TNew">The new control type.</typeparam>
        /// <param name="control">The control to add.</param>
        /// <param name="height">The offset from the previous control.</param>
        /// <returns>The added control and its parent view.</returns>
        public MemoizedElement<TOwner, TNew> Append<TNew>(TNew control, int height)
            where TNew : View
        {
            control.X = Pos.Left(owner.Control);
            control.Y = Pos.Top(owner.Control) + height;
            return new(owner.View, control);
        }
    }

    /// <summary>Starts a vertical layout within a parent view.</summary>
    /// <typeparam name="TOwner">The parent view type.</typeparam>
    /// <param name="owner">The parent view.</param>
    extension<TOwner>(TOwner owner)
        where TOwner : View
    {
        /// <summary>Adds the first control to the layout.</summary>
        /// <typeparam name="TNew">The new control type.</typeparam>
        /// <param name="control">The control to add.</param>
        /// <returns>The added control and its parent view.</returns>
        public MemoizedElement<TOwner, TNew> StackPanel<TNew>(TNew control)
            where TNew : View => new(owner, control);
    }

    /// <summary>Retains the parent view and most recently added control.</summary>
    /// <typeparam name="TOwner">The parent view type.</typeparam>
    /// <typeparam name="TControl">The child control type.</typeparam>
    [System.Diagnostics.DebuggerDisplay("{Control}")]
    public sealed class MemoizedElement<TOwner, TControl>
        where TOwner : View
        where TControl : View
    {
        /// <summary>Initializes a new instance of the MemoizedElement class.</summary>
        /// <param name="owner">The parent view.</param>
        /// <param name="control">The control to add.</param>
        public MemoizedElement(TOwner owner, TControl control)
        {
            View = owner;
            Control = control;
            _ = View.Add(control);
        }

        /// <summary>Gets the parent view.</summary>
        public TOwner View { get; }

        /// <summary>Gets the most recently added control.</summary>
        public TControl Control { get; }
    }
}
