using ABtesting.Dall.MainDbRepositories;
using ABtesting.Service;

namespace ABtesting.Bll;

public class DevicesManager : IDevicesManager
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
        var devices = await _devicesRepository.GetAllDevices();
        return devices.Select(device => new DeviceModel( { DeviceToken = device.DeviceToken, Type = device.Type }).ToList();
    }
}