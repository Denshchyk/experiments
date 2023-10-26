using ABtesting.Service;

namespace ABtesting.Bll;

public class DevicesManager
{
    private readonly IDevicesRepository _devicesRepository;

    public DevicesManager(IDevicesRepository devicesRepository)
    {
        _devicesRepository = devicesRepository;
    }
    public async Task AddDeviceAsync(Device addDevice)
    {
        await _devicesRepository.AddDeviceAsync(addDevice);
    }
    public async Task<Device?> GetByDeviceTokenAsync(Guid deviceToken)
    {
        var device = await _devicesRepository.GetByDeviceTokenAsync(deviceToken);
        return device;
    }
    public async Task<IEnumerable<DeviceModel>> GetAllDevices()
    {
        var devices = _devicesRepository.GetAllDevices();
        return devices.Select(x => new DeviceModel(x.DeviceToken, x.Type));
    }
}