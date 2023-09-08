namespace Devices.Base
{
    public interface IConnectionState<out TOwnerInfo>
        where TOwnerInfo : IDeviceInfo
    {
        bool IsConnected { get; }

        TOwnerInfo OwnerInfo { get; }
    }
}
