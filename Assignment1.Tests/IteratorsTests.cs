namespace Assignment1.Tests;

public class IteratorsTests
{
    [Fact]
    public void Flatten_Given_List_Of_List_Strings_Returns_New_Joined_List()
    {
        List<List<string>> listOflists = new List<List<string>>
        {
            new List<string> { "1", "2" },
            new List<string> { "3", "4" }
        };

        var output = Iterators.Flatten<string>(listOflists);
        Assert.Equal(new List<string> { "1", "2", "3", "4" }, output);
    }

    [Fact]
    public void Flatten_Given_List_Of_List_Ints_Returns_New_List()
    {
        List<List<int>> listOflists = new List<List<int>>
        {
            new List<int> { 1, 2 },
            new List<int> { 3, 4, 5 },
            new List<int> { 6, 7, 8, 9 }
        };

        var output = Iterators.Flatten<int>(listOflists);
        Assert.Equal(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, output);
    }

    [Fact]
    public void Filter_Given_IntList_Return_Evens()
    {
        List<int> intList = new List<int> { -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        Predicate<int> even = Even;
        static bool Even(int number)
        {
            return number % 2 == 0;
        }

        var output = Iterators.Filter<int>(intList, even);
        Assert.Equal(new List<int> { -4, -2, 0, 2, 4, 6, 8, 10 }, output);
    }
    [Fact]
    public void Filter_Given_StringList_Return_Three_Letter_Words()
    {
        List<string> stringList = new List<string> {"hej","jeg","hedder","bo","og","jeg","spiser","is","med","ske"};
        Predicate<string> even = ThreeLetter;
        static bool ThreeLetter(string word)
        {
            return word.Length == 3;
        }

        var output = Iterators.Filter<string>(stringList, ThreeLetter);
        Assert.Equal(new List<string> {"hej","jeg","jeg","med","ske"}, output);
    }
    
    [Fact]
    public void Flatten_Makes_2d_1d()
    {
        // Given
        var x = new List<IEnumerable<string>>();
        var t = new List<string>();
        t.Add("Hello world");
        t.Add("Heej");
        t.Add("Test");
        var y = new List<string>();
        y.Add("Heyo");
        y.Add("Hello BDSA");
        x.Add(t);
        x.Add(y);

        // When
        var flattenedList = Iterators.Flatten(x);

        // Then
        flattenedList.Should().BeEquivalentTo(new[]{"Hello world", "Heej", "Test", "Heyo", "Hello BDSA"});
    }
    
    [Fact]
    public void Filter_Returns_Even_Elements()
    {
        // Given
        var list = new List<int>();
        list.Add(5);
        list.Add(4);
        list.Add(2);
        list.Add(1);

        Predicate<int> predicate = number => number % 2 == 0; 

        // When
        var filteredList = Iterators.Filter<int>(list, predicate);
    
        // Then
        filteredList.Should().BeEquivalentTo(new[]{4,2});
    }
}