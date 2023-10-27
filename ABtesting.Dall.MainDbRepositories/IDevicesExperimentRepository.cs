using ABtesting.Service;

namespace ABtesting.Dall.MainDbRepositories;

public interface IDevicesExperimentRepository
{
    /// <summary>
    /// Adds a random experiment to a device asynchronously.
    /// </summary>
    /// <param name="deviceToken">The unique identifier of the device.</param>
    /// <param name="key">The key associated with the experiment.</param>
    /// <returns>An <see cref="ExperimentModel"/> representing the added experiment.</returns>
    Task<Experiment> AddRandomExperimentToDeviceAsync(Guid deviceToken, string key);

    /// <summary>
    /// Retrieves all experiments associated with a specific device and a given key asynchronously.
    /// </summary>
    /// <param name="deviceToken">The unique identifier of the device.</param>
    /// <param name="key">The key associated with the experiments to retrieve.</param>
    /// <returns>
    /// An <see cref="ExperimentModel"/> representing the experiment with the specified key if found;
    /// otherwise, returns <c>null</c>.
    /// </returns>
    Task<Experiment?> GetAllExperimentsForDeviceAsync(Guid deviceToken, string key);

    /// <summary>
    /// Retrieves a random experiment based on its ChanceInPercents property.
    /// </summary>
    /// <param name="Key">The name of the experiment group to select from.</param>
    /// <returns>A randomly selected experiment based on the weighted ChanceInPercents.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the total chance for experiments with the given name is not 100% or if no experiment is selected.</exception>
    Experiment GetRandomExperiment(string key);
}