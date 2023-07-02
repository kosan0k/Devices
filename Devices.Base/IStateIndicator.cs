namespace Devices.Base
{
    public interface IStateIndicator<out TState> where TState : IDeviceState
    {
        public TState CurrentState { get; }

        public IObservable<TState> StateChanged { get; }
    }
}
