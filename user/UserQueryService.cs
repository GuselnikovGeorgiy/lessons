using user.Models;

namespace user;

public class UserQueryService
{
    public ICollection<Guid> SelectUserIds(ICollection<User>? users, int age)
    {
        if (users == null)
        {
            return [];
        }
        return users.Where(user => user.Age > age).Select(user => user.Id).ToList();
    }

    public ICollection<User> SelectUsers(ICollection<User>? users, int age)
    {
        if (users == null)
        {
            return [];
        }
        
        return users
            .Where(user => user.Age >= age)
            .OrderBy(user => user.Age)
            .ToList();
    }

    public ICollection<User> DescendingAgeUsers(ICollection<User>? users, int age)
    {
        if (users == null)
        {
            return [];
        }
        
        return users
            .Where(user => user.Age > age)
            .OrderByDescending(user => user.Age)
            .ToList();
    }
}