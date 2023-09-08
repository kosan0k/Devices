using CSharpFunctionalExtensions;

namespace Devices.Base
{
    public interface IDeviceState<out TOwnerInfo>
        where TOwnerInfo : IDeviceInfo
    {
        bool IsReady { get; }

        TOwnerInfo OwnerInfo { get; }
    }

    public interface IDeviceState<out TOwnerInfo, out TStateValue> : IDeviceState<TOwnerInfo>
        where TOwnerInfo : IDeviceInfo
    {
        public TStateValue Value { get; }
    }

    public interface IDeviceState<out TOwnerInfo, out TStateValue, out TError> : IDeviceState<TOwnerInfo>
        where TOwnerInfo : IDeviceInfo
    {
        public IResult<TStateValue, TError> Value { get; }
    }
}