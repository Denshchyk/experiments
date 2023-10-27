using ABtesting.Dall.MainDbRepositories;
using ABtesting.Service;

namespace ABtesting.Bll;

public class DevicesExperimentsManager
{
    private readonly IDevicesExperimentRepository _devicesExperimentRepository;

    public DevicesExperimentsManager(IDevicesExperimentRepository devicesExperimentRepository)
    {
        _devicesExperimentRepository = devicesExperimentRepository;
    }

    public async Task<ExperimentModel> AddRandomExperimentToDeviceAsync(Guid deviceToken, string key)
    {
        var addRandomExperiment = await _devicesExperimentRepository.AddRandomExperimentToDeviceAsync(deviceToken, key);

        if (addRandomExperiment != null)
        {
            return new ExperimentModel(addRandomExperiment.Id, addRandomExperiment.Key, addRandomExperiment.Value,
                addRandomExperiment.ChanceInPercents);
        }
        throw new Exception("Failed to add random experiment to device.");
    }

    public async Task<ExperimentModel?> GetAllExperimentsForDeviceAsync(Guid deviceToken, string key)
    {
        var devicesExperiments = _context.DevicesExperiments.Include(x => x.Experiment)
            .Where(de => de.DeviceToken == deviceToken);
        if (await devicesExperiments.AnyAsync())
        {
            var experimentWithKey = devicesExperiments.FirstOrDefault(x => x.Experiment.Key == key)!.Experiment;
            return new ExperimentModel(experimentWithKey.Id, experimentWithKey.Key, experimentWithKey.Value,
                experimentWithKey.ChanceInPercents);
        }
        return null;
    }

    public Experiment GetRandomExperiment(string key)
    {
        var experiments = _context.Experiments
            .Where(e => e.Key == key)
            .ToList();

        if (experiments.Sum(e => e.ChanceInPercents) != 100m)
        {
            throw new InvalidOperationException("Total chance for experiments with the given name is not 100%.");
        }

        var cumulativeChance = 0m;
        var roll = (decimal)_random.NextDouble() * 100;

        foreach (var experiment in experiments)
        {
            cumulativeChance += experiment.ChanceInPercents;
            if (roll < cumulativeChance)
            {
                return experiment;
            }
        }

        throw new InvalidOperationException("No experiment selected. This should not happen.");
    }
}