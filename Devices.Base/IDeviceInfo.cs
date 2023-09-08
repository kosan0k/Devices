namespace Devices.Base
{
    public interface IDeviceInfo
    {
        string Identifier { get; }

        string Alias { get; }

        string Manufacturer { get; }

        DeviceType Type { get; }
    }
}
