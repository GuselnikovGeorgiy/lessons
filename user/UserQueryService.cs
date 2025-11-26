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

        if (take == 0)
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
}