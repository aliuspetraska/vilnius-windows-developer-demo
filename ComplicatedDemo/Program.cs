using System;
using RestSharp;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ComplicatedDemo
{
    // xbuild /p:Configuration=Release ./ComplicatedDemo.csproj

    // mono ./bin/Release/ComplicatedDemo.exe

    class MainClass
    {
        public static void Main(string[] args)
        {
            // http://restsharp.org/
            var client = new RestClient("http://petraska.lt/");
            var request = new RestRequest("social-feed-wall/lrt.json", Method.GET);

            // execute the request
            var response = client.Execute(request);
            var content = response.Content;

			Console.WriteLine(response.Content);

            // write to file (let's make things more complicated)
            File.WriteAllText("Response.txt", content);

            try 
            {

                // http://www.newtonsoft.com/json
                var result = JsonConvert.DeserializeObject<RadioObject>(File.ReadAllText("Response.txt"));

                foreach(var item in result.radio)
                {
                    // list the results
                    Console.WriteLine(item.title);

                    // make fancy delay
                    Thread.Sleep(100);
                }
            } 
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    class Radio
    {
        public string start { get; set; }
        public string channel { get; set; }
        public string title { get; set; }
    }

    class RadioObject
    {
        public List<Radio> radio { get; set; }
    }
}
