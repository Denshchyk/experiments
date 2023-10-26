namespace ABtesting.Service;

public record ExperimentDTO(Guid Id, string Key, string Value, int ChanceInPercents);