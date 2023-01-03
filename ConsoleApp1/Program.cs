using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static HttpClient client = new HttpClient();
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            // call weather api to get today's forecast
            // call weather api to get tomorrow's forecast
            var content = client.GetStringAsync("http://api.openweathermap.org/data/2.5/weather?q=Lancaster&APPID=fe7e427fa3a74ac8fe2f7e47bb13c4c6").Result;
            Console.WriteLine(content);
            Console.ReadLine();
        }
    }
}
