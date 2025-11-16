// See https://aka.ms/new-console-template for more information

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

    public static void Main(string[] args)
    {
        var numList = new List<int> {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
        var numbers = new Nums();
        var result = numbers.GetLastOddNumber(numList);
        Console.WriteLine(string.Join(", ", result));
    }
}