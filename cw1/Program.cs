using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cw1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //string a = "e";
            //string b = "lo";
            //Console.WriteLine($"{a}{b}"); // concat
            //string path = @"https://github.com/s18579/cw1.git";
            //Console.WriteLine("Hello World!");
            //var newPerson = new Person { FirstName = "Jacek" };
            var url = "https://www.pja.edu.pl";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                //2xx
                var htmlContent = await response.Content.ReadAsStringAsync();
                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+", RegexOptions.IgnoreCase);
                var matches = regex.Matches(htmlContent);
                foreach(var match in matches)
                {
                    Console.WriteLine(match.ToString());
                }
            }
        }
    }
}
