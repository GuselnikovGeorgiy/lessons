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
}