using System.Reactive.Disposables;
using System.Reactive.Subjects;

namespace Devices.Base
{
    public interface IObservableState<out TState> : IObservable<TState>
    {
        public TState CurrentState { get; }
    }

    public class ObservableState<TState> : IObservableState<TState>
    {
        private readonly Subject<TState> _subject = new();

        public TState CurrentState { get; private set; }

        public ObservableState(TState currentState)
        {
            CurrentState = currentState;
        }

        public void NotifyStateChanged(TState newState)
        {
            if (CurrentState?.Equals(newState) ?? true)
                return;

            CurrentState = newState;
            _subject.OnNext(CurrentState);
        }

        public IDisposable Subscribe(IObserver<TState> observer) => _subject.Subscribe(observer);
    }
}
