using System;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using Terminal.Gui;

namespace ReactiveMvvm;

public sealed class TerminalScheduler(IApplication application) : LocalScheduler
{

    public override IDisposable Schedule<TState> (
        TState state,
        TimeSpan dueTime,
        Func<IScheduler, TState, IDisposable> action
    )
    {
        IDisposable PostOnMainLoop ()
        {
            var composite = new CompositeDisposable (2);
            var cancellation = new CancellationDisposable ();

            application.Invoke (
                                () =>
                                {
                                    if (!cancellation.Token.IsCancellationRequested)
                                    {
                                        composite.Add (action (this, state));
                                    }
                                }
                               );
            composite.Add (cancellation);

            return composite;
        }

        IDisposable PostOnMainLoopAsTimeout ()
        {
            var composite = new CompositeDisposable (2);

            object timeout = application.AddTimeout (
                                                     dueTime,
                                                     () =>
                                                     {
                                                         composite.Add (action (this, state));

                                                         return false;
                                                     }
                                                    );
            composite.Add (Disposable.Create (() => application.RemoveTimeout (timeout)));

            return composite;
        }

        return dueTime == TimeSpan.Zero
                   ? PostOnMainLoop ()
                   : PostOnMainLoopAsTimeout ();
    }
}
