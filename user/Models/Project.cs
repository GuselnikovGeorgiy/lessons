namespace user.Models;

public sealed record Project
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
}