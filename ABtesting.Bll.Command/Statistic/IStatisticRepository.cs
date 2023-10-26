namespace ABtesting.Service;

public interface IStatisticRepository
{
    Task<List<DistributionModel>> DistributionByKeyAndValueAsync();
    int GetAllDevices();
    Task<IEnumerable<ExperimentModel>> GetAllExperiments();
}