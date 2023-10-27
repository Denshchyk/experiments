using ABtesting.Service;

namespace ABtesting.Bll;

public interface IDevicesManager
{
    Task AddDeviceAsync(Device addDevice);
    Task<Device?> GetByDeviceTokenAsync(Guid deviceToken);
    Task<IEnumerable<DeviceModel>> GetAllDevices();
}