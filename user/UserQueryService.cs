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

    public ICollection<Project> SelectUserProjects(ICollection<User>? users, int age)
    {
        if (users == null)
        {
            return [];
        }

        return users
            .Where(user => user.Age > age)
            .Where(user => user.Projects != null)
            .SelectMany(user => user.Projects!)
            .ToList();
    }

    public Paginate<User> GetPaginateUsers(ICollection<User>? users, int? skip, int? take)
    {
        if (users == null)
        {
            return new Paginate<User>
            {
                CurrentUsersPage = new List<User>(),
                TotalCount = 0
            };
        }

        if (take <= 0)
        {
            return new Paginate<User>
            {
                CurrentUsersPage = new List<User>(),
                TotalCount = users.Count
            };
        }

        var query = users.AsEnumerable();

        if (skip != null && skip.Value > 0)
        {
            query = query.Skip(skip.Value);
        }

        if (take != null && take.Value > 0)
        {
            query = query.Take(take.Value);
        }

        var currentPage = query.ToList();

        return new Paginate<User>
        {
            CurrentUsersPage = currentPage,
            TotalCount = users.Count
        };
    }

    public ICollection<int> ReverseUserIds(ICollection<int>? userIds)
    {
        if (userIds == null)
        {
            return [];
        }

        return userIds.Reverse().ToList();
    }

    public bool AllAdultUsers(ICollection<User>? users)
    {
        if (users == null)
        {
            return false;
        }

        return users
            .All(user => user.Age > 17);
    }

    public bool AnyAdultUser(ICollection<User>? users)
    {
        return users?.Any(user => user.Age > 17) ?? false;
    }

    public bool ContainsAdultUser(ICollection<User>? users)
    {
        if (users == null)
        {
            return false;
        }

        return users
            .Select(user => user.Age)
            .Contains(18);
    }

    public Dictionary<int, List<User>> GroupUsersByAge(ICollection<User> users)
    {
        return users
            .GroupBy(u => u.Age)
            .ToDictionary(
                g => g.Key,
                g => g.ToList());
    }

    public ICollection<User> DistinctByIdUsers(ICollection<User> users)
    {
        return users
            .DistinctBy(x => x.Id)
            .ToList();
    }

    public ICollection<User> FindUsersWithSameName(ICollection<User> firstGroup, ICollection<User> secondGroup)
    {
        return firstGroup
            .IntersectBy(secondGroup
                    .Select(x => x.Name),
                x => x.Name)
            .ToList();
    }

    /// <summary>
    /// Группирует пользователей по возрасту, используя ToDictionary.
    /// Ключ - возраст (Age), значение - первый пользователь с таким возрастом.
    /// </summary>
    public Dictionary<int, User> GroupByAgeUsingDictionary(ICollection<User> users)
    {
        return users
            .DistinctBy(x => x.Age)
            .ToDictionary(
                x => x.Age,
                x => x);
    }

    /// <summary>
    /// Группирует пользователей по возрасту, используя ToLookup.
    /// Ключ - возраст (Age), значение - последовательность всех пользователей этого возраста.
    /// </summary>
    public ILookup<int, User> GroupByAgeUsingLookup(ICollection<User> users)
    {
        return users.ToLookup(
            x => x.Age,
            x => x);
    }

public HashSet<User> UniqueUsersUsingRecord(ICollection<User> users)
{
    return new HashSet<User>(users);
}
    
public HashSet<UserClass> UniqueUsersUsingClass(ICollection<UserClass> users)
{
    return users
        .DistinctBy(x => new { x.Name, x.Age })
        .ToHashSet();
}
    
    public HashSet<UserClassEquatable> UniqueUsersUsingClassEquatable(ICollection<UserClassEquatable> users)
    {
        return users.ToHashSet();
    }
}