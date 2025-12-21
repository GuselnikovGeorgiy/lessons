// See https://aka.ms/new-console-template for more information

using System.Collections;

namespace nums;

public class Nums
{
    public IEnumerable<int> GetOddNumbers(ICollection<int>? numbers)
    {
        if (numbers == null  || numbers.Count == 0)
        {
            return [];
        }
        return numbers.Where(n => n % 2 != 0);
    }

    public ICollection<int> GetPositiveNumbers(ICollection<int>? numbers)
    {
        if (numbers == null  || numbers.Count == 0)
        {
            return [];
        }
        return numbers.Where(n => n > 0).ToList();
    }

    public int? GetFirstOddNumber(ICollection<int>? numbers)
    {
        var res = numbers?.FirstOrDefault(n => n % 2 != 0);
        if (res == 0)
        {
            return null;
        }
        return res;
    }

    public int? GetLastOddNumber(ICollection<int>? numbers)
    {
        var res = numbers?.LastOrDefault(n => n % 2 != 0);
        if (res == 0)
        {
            return null;
        }
        return res;
    }

    public int? GetSingleOddNumber(ICollection<int>? numbers)
    {
        return numbers?.SingleOrDefault(n => n % 2 != 0);
    }

    public int? GetElementAtOrDefault(ICollection<int>? collection, int index)
    {
        return collection?.ElementAtOrDefault(index);
    }

    public ICollection<long> CastIntToLong(ICollection<int> list)
    {
        return list
            .Select(Convert.ToInt64)
            .ToList();
    }

    public int GetSum(int[] array)
    {
        return array.Aggregate(0, (total, next) => total + next);
    }

    public static void Main(string[] args)
    {
        List<int> intList = new List<int> { 1, 2, 3, 4, 5 };

        var longs = intList.Select(Convert.ToInt64);

        foreach (var elem in longs) 
        {
            Console.WriteLine($"{elem}, {elem.GetType()}");
        }

    }

    public bool AreSequenceEqual(ICollection<int> firstList, ICollection<int> secondList)
    {
        return firstList.SequenceEqual(secondList);
    }
}