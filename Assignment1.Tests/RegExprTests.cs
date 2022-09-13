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

    [Fact]
    public void InnerText_One_Match()
    {
        // Given
        string html = "<html>Test</html><a>link</a>";
        string tag = "html";
    
        // When
        var listOfTagHTML = RegExpr.InnerText(html, tag);
    
        // Then
        listOfTagHTML.Should().BeEquivalentTo(new[]{"Test"});
    }
    
    [Fact]
    public void InnerText_with_tag_a_returns_innertext()
    {
        // Given
        string html = "<div><p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=\"https://en.wikipedia.org/wiki/Theoretical_computer_science\" title=\"Theoretical computer science\">theoretical computer science</a> and <a href=\"https://en.wikipedia.org/wiki/Formal_language\" title=\"Formal language\">formal language</a> theory, a sequence of <a href=\"https://en.wikipedia.org/wiki/Character_(computing)\" title=\"Character (computing)\">characters</a> that define a <i>search <a href=\"https://en.wikipedia.org/wiki/Pattern_matching\" title=\"Pattern matching\">pattern</a></i>. Usually this pattern is then used by <a href=\"https://en.wikipedia.org/wiki/String_searching_algorithm\" title=\"String searching algorithm\">string searching algorithms</a> for \"find\" or \"find and replace\" operations on <a href=\"https://en.wikipedia.org/wiki/String_(computer_science)\" title=\"String (computer science)\">strings</a>.</p></div>";
        string tag = "a";

        // When
        var listOfTagA = RegExpr.InnerText(html, tag);

        // Then
        listOfTagA.Should().BeEquivalentTo(new[]{"theoretical computer science", "formal language", "characters", "pattern", "string searching algorithms", "strings"});
    }

    [Fact]
    public void InnerText_With_Nested_Text()
    {
        // Given
        string html = "<div><p>The phrase <i>regular expressions</i> (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing <u>patterns</u> that matching <em>text</em> need to conform to.</p></div>";
        string tag = "p";

        // When
        var listOfTagP = RegExpr.InnerText(html, tag);
        
        // Then
        listOfTagP.Should().BeEquivalentTo(new[]{"The phrase regular expressions (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing patterns that matching text need to conform to."});
    }

    [Fact]
    public void URLs_From_HTML()
    {
        // Given
        string html = "<div><p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=\"https://en.wikipedia.org/wiki/Theoretical_computer_science\" title=\"Theoretical computer science\">theoretical computer science</a> and <a href=\"https://en.wikipedia.org/wiki/Formal_language\" title=\"Formal language\">formal language</a> theory, a sequence of <a href=\"https://en.wikipedia.org/wiki/Character_(computing)\" title=\"Character (computing)\">characters</a> that define a <i>search <a href=\"https://en.wikipedia.org/wiki/Pattern_matching\" title=\"Pattern matching\">pattern</a></i>. Usually this pattern is then used by <a href=\"https://en.wikipedia.org/wiki/String_searching_algorithm\" title=\"String searching algorithm\">string searching algorithms</a> for \"find\" or \"find and replace\" operations on <a href=\"https://en.wikipedia.org/wiki/String_(computer_science)\" title=\"String (computer science)\">strings</a>.</p></div>";
        
        // When
        var listOfUrlsWithTitles = RegExpr.Urls(html);

        // Then
        listOfUrlsWithTitles.Should().BeEquivalentTo(new[]{
            (new Uri("https://en.wikipedia.org/wiki/Theoretical_computer_science"), "Theoretical computer science"),
            (new Uri("https://en.wikipedia.org/wiki/Formal_language"), "Formal language"),
            (new Uri("https://en.wikipedia.org/wiki/Character_(computing)"), "Character (computing)"),
            (new Uri("https://en.wikipedia.org/wiki/Pattern_matching"), "Pattern matching"),
            (new Uri("https://en.wikipedia.org/wiki/String_searching_algorithm"), "String searching algorithm"),
            (new Uri("https://en.wikipedia.org/wiki/String_(computer_science)"), "String (computer science)")
        });
    }

    [Fact]
    public void Simple_URLs_From_HTML()
    {
        // Given
        string html = "<a href=\"https://www.google.com\" title=\"Google\"";
        
        // When
        var listOfUrlsWithTitles = RegExpr.Urls(html);

        // Then
        listOfUrlsWithTitles.Should().BeEquivalentTo(new[]{
            (new Uri("https://www.google.com"), "Google")
        });
    }

    [Fact]
    public void URLs_Where_Title_Has_Parentheses()
    {
        // Given
        string html = "<a href=\"https://www.google.com\" title=\"Google (Alphabet)\"";
        
        // When
        var listOfUrlsWithTitles = RegExpr.Urls(html);

        // Then
        listOfUrlsWithTitles.Should().BeEquivalentTo(new[]{
            (new Uri("https://www.google.com"), "Google (Alphabet)")
        });
    }

    [Fact]
    public void HTTP_URL_works()
    {
        // Given
        string html = "<a href=\"http://www.google.com\" title=\"Google (Alphabet)\"";
        
        // When
        var listOfUrlsWithTitles = RegExpr.Urls(html);

        // Then
        listOfUrlsWithTitles.Should().BeEquivalentTo(new[]{
            (new Uri("http://www.google.com"), "Google (Alphabet)")
        });
    }
}