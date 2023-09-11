namespace src.Domain.Models;

public class PartymapsDataBaseSettings {
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string ChatCollectionName { get; set; } = null!;
}