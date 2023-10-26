using ABtesting.Service;
using Microsoft.AspNetCore.Mvc;

namespace Testing.Controllers;
[ApiController]
[Route("api/[controller]")]
public class DeviceController : ControllerBase
{
    private readonly IDevicesRepository _devicesRepository;

    public DeviceController(IDevicesRepository devicesRepository)
    {
        _devicesRepository = devicesRepository;
    }
    
    [HttpPost("{type}")]
    public async Task AddDevice(string type)
    {
        var addDevice = new Device { Type = type};
        await _devicesRepository.AddDeviceAsync(addDevice);
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DeviceDTO>>> GetAllDevices()
    {
        var deviceModels = await _devicesRepository.GetAllDevices();
        return Ok(deviceModels);
    }
}
