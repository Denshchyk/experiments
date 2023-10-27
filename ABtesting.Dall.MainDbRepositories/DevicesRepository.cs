using ABtesting.Service;
using Microsoft.EntityFrameworkCore;

namespace ABtesting.Dall.MainDbRepositories;

public class DevicesRepository : IDevicesRepository
{
    private ApplicationContext _context;

    public DevicesRepository(ApplicationContext context)
    {
        _context = context;
    }
    /// <summary>
    /// Adds a new device asynchronously to the database.
    /// </summary>
    /// <param name="addDevice">The device to be added.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task AddDeviceAsync(Device addDevice)
    {
        await _context.Devices.AddAsync(addDevice);
        await _context.SaveChangesAsync();
    }
    
    /// <summary>
    /// Retrieves a device by its unique device token asynchronously.
    /// </summary>
    /// <param name="deviceToken">The unique identifier of the device to retrieve.</param>
    /// <returns>
    /// The <see cref="Device"/> object representing the device with the specified token if found;
    /// otherwise, returns <c>null</c>.
    /// </returns>
    public async Task<Device?> GetByDeviceTokenAsync(Guid deviceToken)
    {
        var device = await _context.Devices.FirstOrDefaultAsync(device => device.DeviceToken == deviceToken);
        return device;
    }

    /// <summary>
    /// Retrieves a list of all devices and their associated information asynchronously.
    /// </summary>
    /// <returns>An <see cref="IEnumerable{DeviceModel}"/> representing all devices and their details.</returns>
    public async Task<IEnumerable<Device>> GetAllDevices()
    {
        return await _context.Devices
            .Include(x => x.DevicesExperiments)
            .ToListAsync();
    }
}