namespace Assignment1.Tests;

public class IteratorsTests
{
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