  #Getting websites#
HtmlWeb web = new HtmlWeb();
HtmlDocument doc2 = web.Load("weather.comlink");
var nodes = doc2.DocumentNode.SelectNodes("//li");
  #lists#
List<string> info = new List<string>();
foreach (var item in nodes)
{
  info.Add(item.InnerText);
}
List<string> temps = new List<string>();
for (int i = 18; i < 23; i++)
{
  temps.Add(info[i]);
}
List<string> current = new List<string>();
  #stringsplitter#
for (int i = 1; i < temps.Count; i++)
{
    current.Add(temps[i].Substring(0, 6));
    int index = temps[i].IndexOf("°");
    current.Add(temps[i].Substring(6, index - 5));
    string newTemp = temps[i].Substring(index + 1);
    index = newTemp.IndexOf("°");
    current.Add(newTemp.Substring(0, index + 1));
    Console.WriteLine(temps[i]);
    newTemp = temps[i].Substring(temps[i].Length - 3);
    if (newTemp.Contains('n'))
    {
        newTemp = newTemp.Substring(1);
    }
    current.Add(newTemp);
}
