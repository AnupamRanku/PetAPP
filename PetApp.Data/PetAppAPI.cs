using PetApp.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PetApp.Data
{
    public class PetAppAPIService
    {


        HttpClient _client = new HttpClient();
        const String _apisetting = "People_API_URL";
       

        private String APIURL
            {
            get {
                return ConfigurationManager.AppSettings[_apisetting];
            }
        }




        /// <summary>
        /// Gets List of people from API endpoint
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        async Task<List<Person>> GetPeopleAsync(string path)
        {
            
            HttpResponseMessage response = await _client.GetAsync(path);
            List<Person> people = null;
            if (response.IsSuccessStatusCode)
            {
                people = await response.Content.ReadAsAsync<List<Person>>();
            }
            else {
               Console.WriteLine(response.ToString());
            }

            return people;
        }

        /// <summary>
        /// Sync - return the people list
        /// </summary>
        /// <returns></returns>
        public List<Person> GetAllPeople()
        {
            List<Person> people = null;


            _client.BaseAddress = new Uri(APIURL);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Task<List<Person>> task = Task.Run<List<Person>>(async () => await GetPeopleAsync(APIURL));
            people = task.Result;
            return people;
        }


    }
}
