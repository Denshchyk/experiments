namespace ABtesting.Service;

public interface IDevicesRepository
{
    Task AddDeviceAsync(Device addDevice);
    Task<Device?> GetByDeviceTokenAsync(Guid deviceToken);
    Task<IEnumerable<DeviceModel>> GetAllDevices();
}