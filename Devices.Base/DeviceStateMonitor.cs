using System.Reactive.Subjects;

namespace Devices.Base
{
    public class DeviceStateMonitor
    {
        private readonly Subject<IDeviceState<IDevice>> _stateChangeSubject = new();

        public IObservable<IDeviceState<IDevice>> SomeDeviceStateChanged => _stateChangeSubject;

        public void RegisterDevice<TDeviceInfo, TDeviceState>(IDevice<TDeviceInfo, TDeviceState> device)
            where TDeviceInfo : IDeviceInfo
            where TDeviceState : IDeviceState<IDevice<TDeviceInfo, TDeviceState>>
        {
            device.StateIndicator.StateChanged
                .Subscribe(state => _stateChangeSubject.OnNext(state));
        }


    }
}
