namespace Devices.Base
{
    public readonly partial record struct DeviceType(int Id, string Name)
    {
        #region Base types
        public static DeviceType Detector => new(0, nameof(Detector));

        public static DeviceType Generator => new(1, nameof(Generator));

        public static DeviceType ControlBlock => new(2, nameof(ControlBlock));

        #endregion
    }
}
