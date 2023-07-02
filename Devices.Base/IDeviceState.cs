using CSharpFunctionalExtensions;

namespace Devices.Base
{
    public interface IDeviceState
    {
    }

    public interface IDeviceState<out TOwner> : IDeviceState
        where TOwner : IDevice
    {
        TOwner Owner { get; }
    }

    public interface IDeviceState<out TOwner, out TStateValue, out TError> : IDeviceState<TOwner>
        where TOwner : IDevice
    {
        public IResult<TStateValue, TError> Value { get; }
    }
}