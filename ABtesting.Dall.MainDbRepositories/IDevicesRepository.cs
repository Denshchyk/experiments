using ABtesting.Service;

namespace ABtesting.Dall.MainDbRepositories;

public interface IDevicesRepository
{
    /// <summary>
    /// Adds a new device asynchronously to the database.
    /// </summary>
    /// <param name="addDevice">The device to be added.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task AddDeviceAsync(Device addDevice);

    /// <summary>
    /// Retrieves a device by its unique device token asynchronously.
    /// </summary>
    /// <param name="deviceToken">The unique identifier of the device to retrieve.</param>
    /// <returns>
    /// The <see cref="Device"/> object representing the device with the specified token if found;
    /// otherwise, returns <c>null</c>.
    /// </returns>
    Task<Device?> GetByDeviceTokenAsync(Guid deviceToken);

    /// <summary>
    /// Retrieves a list of all devices and their associated information asynchronously.
    /// </summary>
    /// <returns>An <see cref="IEnumerable{DeviceModel}"/> representing all devices and their details.</returns>
    Task<IEnumerable<Device>> GetAllDevices();
}