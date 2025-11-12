// See https://aka.ms/new-console-template for more information

public class Nums
{
    public IEnumerable<int> GetOddNumbers(IEnumerable<int> numbers)
    {
        if (numbers == null  || numbers.Count() == 0)
        {
            return [];
        }
        return numbers.Where(n => n % 2 != 0);
    }

    public static void Main(string[] args)
    {
        var numList = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9};
        var numbers = new Nums();
        var result = numbers.GetOddNumbers(numList);
        Console.WriteLine(string.Join(", ", result));
    }
}