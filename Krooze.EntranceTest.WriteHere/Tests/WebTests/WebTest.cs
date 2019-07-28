using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Linq;
using System.Collections.Generic;

namespace Krooze.EntranceTest.WriteHere.Tests.WebTests
{
    public class WebTest
    {
        public JObject GetAllMovies()
        {
            //TODO: Consume the following API: https://swapi.co/documentation using only .NET standard libraries (do not import the helpers on this page)
            // -Return the films object
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(String.Format("https://swapi.co/api/films")).Result;
            var jsonObj = new JObject();
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                jsonObj = JObject.Parse(result);
            }
            return jsonObj;
        }

        public string GetDirector()
        {
            //TODO: Consume the following API: https://swapi.co/documentation using only .NET standard libraries (do not import the helpers on this page)
            // -Return the name of person that directed the most star wars movies, based on the films object return

            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(String.Format("https://swapi.co/api/films")).Result;
            var jsonObj = new JObject();
            var director = string.Empty;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;

                //var groups = list.GroupBy(x => x).ToList();
                //var count = groups.Max(g => g.Count());

                //var items = groups.Where(g => g.Count() == count)
                //                  .Select(g => g.Key)
                //                  .ToList();

                jsonObj = JObject.Parse(result);

                director = jsonObj["results"].Value<JArray>().FirstOrDefault()["director"].Value<string>();
            }
            return director;
        }
    }
}
