using HtmlAgilityPack;
using MySql.Data.MySqlClient;
namespace webScrapingToUpload

{
    internal class Program
    {
        static void Main(string[] args)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc2 = web.Load("https://weather.com/en-GB/weather/today/l/0ea58c060f0f6522c01d626fde93ab4bff38410da8de58c9068e373327d128e91bdb47028a98b93188526f6bdecc918c");
            var nodes = doc2.DocumentNode.SelectNodes("//li");
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
            //[0]= date [1]=hightemp [2]=lowtemp [3]=rain chance
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
            foreach (string curstr in current)
            {
                Console.WriteLine(curstr);
            }
        }
    }
}