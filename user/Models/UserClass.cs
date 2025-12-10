namespace user.Models;

public class UserClass
{
    public required Guid Id { get; init; }
    public required int Age { get; init; }
    public required string Name { get; init; }
}