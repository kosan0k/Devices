namespace Devices.Base
{
    public interface IDevice
    {
    }

    public interface IDevice<out TInfo, out TState> : IDevice
        where TInfo : IDeviceInfo
        where TState : IDeviceState
    {
        TInfo Info { get; }

        IStateIndicator<TState> StateIndicator { get; }
    }
}
