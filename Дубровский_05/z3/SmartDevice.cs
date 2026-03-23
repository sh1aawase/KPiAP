namespace SmartDevicesApp
{
    public abstract class SmartDevice
    {
        public string Model { get; protected set; }

        protected SmartDevice(string model)
        {
            Model = model;
        }
    }
}