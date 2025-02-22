namespace Assignment1;

public static class RegExpr
{
    public static IEnumerable<string> SplitLine(IEnumerable<string> lines) {
        var pattern = "[a-zA-Z0-9]+";
        foreach(var line in lines) {
            foreach(var word in Regex.Matches(line, pattern)) {
                yield return word.ToString();
            }
        }
    }

    public static IEnumerable<(int width, int height)> Resolution(IEnumerable<string> resolutions) {
        var pattern = "(?<x>[0-9]+)x(?<y>[0-9]+)";
        foreach(var line in resolutions) {
            foreach(Match match in Regex.Matches(line, pattern)) {
                int x = Int32.Parse(match.Groups["x"].Value);
                int y = Int32.Parse(match.Groups["y"].Value);
                yield return (x,y);
            }
        }
    }

    public static IEnumerable<string> InnerText(string html, string tag) {
        var matchpattern = "<"+tag+"[^>]*>(?<innertext>.*?)</"+tag+">";
        var removepattern = "<.*?>";

        foreach (Match match in Regex.Matches(html, matchpattern)) {
            string matchtext = match.Groups["innertext"].Value;
            yield return Regex.Replace(matchtext, removepattern, "");
        }
    }

    public static IEnumerable<(Uri url, string title)> Urls(string html) {
        var pattern = "<a(( *href=\"(?<url>.*?)\" *| *title=\"(?<title>.*?)\" *)| *[^<>]*?=\".*?\" *?)*>(?<innertext>.*?)</a>";
        // var pattern = "<a[.((?:href=\")https?://[\\w\\./]*)()]*>(?<innerText>[^<]*)</a>";
        // var pattern = "<a(?<attributes>.*)>(?<innerText>.*)</a>";

        foreach (Match match in Regex.Matches(html, pattern)) {
            // yield return (new Uri(match.ToString()), match.ToString());
            yield return (new Uri(match.Groups["url"].Value), match.Groups["title"].Value != "" ? match.Groups["title"].Value : match.Groups["innertext"].Value);
            // yield return (new Uri(match.Groups["url"].Value), match.Groups["title"].Value);
        }
    }
}