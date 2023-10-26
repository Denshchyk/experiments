using ABtesting.Service;
using Microsoft.AspNetCore.Mvc;

namespace Testing.Controllers;

[ApiController]
[Route("api/[controller]")]

public class StatisticController : ControllerBase
{
    private readonly IStatisticRepository _statisticRepository;

    public StatisticController(IStatisticRepository statisticRepository)
    {
        _statisticRepository = statisticRepository;
    }
    
    [HttpGet("numberOfDevices")]
    public ActionResult<int> GetNumberOfDevices()
    {
        var numberOfDevices = _statisticRepository.GetAllDevices();
        return Ok(numberOfDevices);
    }
    
    [HttpGet("experiments")]
    public async Task<ActionResult<IEnumerable<ExperimentDTO>>> GetExperiments()
    {
        var experimentModels = await _statisticRepository.GetAllExperiments();
        return Ok(experimentModels);
    }
    
    [HttpGet("distribution")]
    public async Task<ActionResult<List<DistributionDTO>>> DistributionByKeyAndValue()
    {
        var distribution = await _statisticRepository.DistributionByKeyAndValueAsync();
        return Ok(distribution);
    }
}