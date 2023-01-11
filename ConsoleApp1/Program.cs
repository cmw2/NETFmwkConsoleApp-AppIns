using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static TelemetryConfiguration configuration = TelemetryConfiguration.Active;
        static TelemetryClient telemetryClient = new TelemetryClient(configuration);

        static void Main(string[] args)
        {

            try
            {
                //try
                //{
                using (var operation = telemetryClient.StartOperation<RequestTelemetry>("myconsoleapp"))
                {
                    //try
                    //{
                    Console.WriteLine("Starting Main");
                    telemetryClient.TrackTrace("Starting Main");

                    Random rand = new Random();
                    int numRecords = rand.Next(50);
                    Console.WriteLine("NumRecods: " + numRecords.ToString());
                    telemetryClient.TrackTrace("NumRecods: " + numRecords.ToString());
                    telemetryClient.TrackMetric("NumRecords", numRecords);

                    for (int i = 0; i < 5; i++)
                    {
                        var content = client.GetStringAsync("http://api.openweathermap.org/data/2.5/weather?q=Lancaster&APPID=fe7e427fa3a74ac8fe2f7e47bb13c4c6").Result;
                        Console.WriteLine(content);                        
                        Thread.Sleep(1000);
                        //if (i == 3)
                        //{
                        //    throw new Exception("Test Exception");
                        //}
                    }
                    telemetryClient.StopOperation(operation);
                    //}
                    //catch (Exception ex)
                    //{
                    //    telemetryClient.TrackException(ex);
                    //    // other logging?
                    //}
                }
                //} 
                //catch (Exception ex)
                //{
                //    telemetryClient.TrackException(ex);
                //    // other logging?
                //}
            }
            finally
            {
                if (null != telemetryClient)
                {
                    telemetryClient.Flush();
                    Thread.Sleep(5000);
                }
            }
        }
    }
}
