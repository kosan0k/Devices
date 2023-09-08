using System.Reactive.Subjects;

namespace Devices.Base
{
    public class DeviceGroup
    {
        private readonly List<IDevice<IDeviceInfo, IDeviceState<IDeviceInfo>>> _registeredDevices = new();

        private readonly Subject<IDeviceState<IDeviceInfo>> _stateChangeSubject = new();
        private readonly Subject<IConnectionState<IDeviceInfo>> _connectionChangedSubject = new();

        public int Id { get; }

        public string Name { get; }

        public IReadOnlyList<IDevice<IDeviceInfo, IDeviceState<IDeviceInfo>>> Devices => _registeredDevices;

        public IObservable<IDeviceState<IDeviceInfo>> SomeDeviceStateChanged => _stateChangeSubject;
        public IObservable<IConnectionState<IDeviceInfo>> SomeDeviceConnectionChanged => _connectionChangedSubject;

        public DeviceGroup(
            int id,
            string name,
            IEnumerable<IDevice<IDeviceInfo, IDeviceState<IDeviceInfo>>> devices)
        {
            Id = id;
            Name = name;

            foreach (var device in devices)
                RegisterDevice(device);
        }

        private void RegisterDevice<TDeviceInfo, TDeviceState>(IDevice<TDeviceInfo, TDeviceState> device)
            where TDeviceInfo : IDeviceInfo
            where TDeviceState : IDeviceState<TDeviceInfo>
        {
            device.DeviceStateIndicator
                .Subscribe(state => _stateChangeSubject.OnNext((IDeviceState<IDeviceInfo>)state));

            if (device is IObservableState<IConnectionState<TDeviceInfo>> connectionObservable)
            {
                connectionObservable
                    .Subscribe(connection => _connectionChangedSubject.OnNext((IConnectionState<IDeviceInfo>)connection));
            }

            _registeredDevices.Add((IDevice<IDeviceInfo, IDeviceState<IDeviceInfo>>)device);
        }
    }
}
