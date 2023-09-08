namespace Devices.Base
{
    public interface IDevice<out TInfo, out TState>
        where TInfo : IDeviceInfo
        where TState : IDeviceState<TInfo>
    {
        TInfo Info { get; }

        IObservableState<TState> DeviceStateIndicator { get; }
    }

    public interface IDevice<out TInfo, out TState, out TConnectionState> : IDevice<TInfo, TState>
        where TInfo : IDeviceInfo
        where TState : IDeviceState<TInfo>
        where TConnectionState : IConnectionState<TInfo>
    {
        IObservableState<TConnectionState> ConnectionStateIndicator { get; }
    }
}
