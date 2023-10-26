namespace ABtesting.Service;

public record DistributionDTO(string ExperimentKey, string ExperimentValue, int NumberOfDevices);