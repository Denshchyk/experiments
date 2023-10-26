using ABtesting.Service;

namespace ABtesting.Experiments;

public interface IExperimentRepository
{
    Task AddExperimentAsync(Experiment addExperiment);
    Task<Experiment?> GetByKeyAsync(string key);
}