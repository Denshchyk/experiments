using ABtesting.Dall.MainDbRepositories;
using ABtesting.Experiments;
using ABtesting.Service;
using Microsoft.AspNetCore.Mvc;
using IDevicesExperimentRepository = ABtesting.DevicesExperiments.IDevicesExperimentRepository;

namespace Testing.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExperimentController : ControllerBase
{
    private readonly IExperimentRepository _experimentRepository;
    private readonly IDevicesRepository _devicesRepository;
    private readonly IDevicesExperimentRepository _devicesExperimentRepository;

    public ExperimentController(IExperimentRepository experimentRepository, IDevicesRepository devicesRepository,
        IDevicesExperimentRepository devicesExperimentRepository)
    {
        _experimentRepository = experimentRepository;
        _devicesRepository = devicesRepository;
        _devicesExperimentRepository = devicesExperimentRepository;
    }
    
    [HttpGet("{key}")]
    public async Task<ActionResult<ExperimentModel>> GetExperiment(string key, [FromQuery]Guid deviceToken)
    {
        var device = await _devicesRepository.GetByDeviceTokenAsync(deviceToken);

        if (device is null)
        {
            var addDevice = new Device { DeviceToken = deviceToken, Type = "device.Type"};
            await _devicesRepository.AddDeviceAsync(addDevice);

            var randomExperiment = await _devicesExperimentRepository.AddRandomExperimentToDeviceAsync(addDevice.DeviceToken, key);
            return Created(nameof(GetExperiment), randomExperiment);
        }

        var devicesExperiments = await _devicesExperimentRepository.GetAllExperimentsForDeviceAsync(deviceToken, key);
        
        if (devicesExperiments is not null)
        {
            return devicesExperiments;
        }
        return NoContent();
    }
    
    [HttpPost]
    public async Task AddExperiment(string key, string value, int chanceInPrecents)
    {
        if (chanceInPrecents > 100)
        {
            BadRequest("The total ChanceInPercents for experiments would exceed 100.");
        }
        var addExperiment = new Experiment { Key = key, Value = value, ChanceInPercents = chanceInPrecents};
        await _experimentRepository.AddExperimentAsync(addExperiment);
    }
}