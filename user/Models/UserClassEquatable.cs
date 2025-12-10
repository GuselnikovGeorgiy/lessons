namespace user.Models;

public class UserClassEquatable : IEquatable<UserClassEquatable>
{
    public required Guid Id { get; init; }
    public required int Age { get; init; }
    public required string Name { get; init; }
    
    public bool Equals(UserClassEquatable? other)
    {
        if (other is null)
        {
            return false;
        }
        
        return Age == other.Age && Name == other.Name;
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(Age, Name);
    }
}