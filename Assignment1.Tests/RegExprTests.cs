namespace Assignment1.Tests;

public class RegExprTests
{
    [Fact]
    public void Test_SplitLine()
    {
        // Given
        var list = new List<string>();
        list.Add("Hej med dig");
        list.Add("Margrethe II ");

        // When
        var words = RegExpr.SplitLine(list);
    
        // Then
        words.Should().BeEquivalentTo(new[]{"Hej", "med", "dig", "Margrethe", "II"});
    }

    [Fact]
    public void Test_Resolutions()
    {
        // Given
        var list = new List<string>();
        list.Add("1980x1020, 720x480");
        list.Add("100x200");
    
        // When
        var resolutions = RegExpr.Resolution(list);
    
        // Then
        resolutions.Should().BeEquivalentTo(new[]{(1980,1020), (720,480), (100,200)});
    }
}