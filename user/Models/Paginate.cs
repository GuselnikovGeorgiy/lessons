namespace user.Models;

public sealed record Paginate<T>
{
    public required ICollection<T> CurrentUsersPage { get; init; }
    public required int TotalCount { get; init; }
}