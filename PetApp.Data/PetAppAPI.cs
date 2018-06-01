using PetApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PetApp.Data
{
    public class PetAppAPI
    {


        HttpClient _client = new HttpClient();
        const String _apiURL = "http://agl-developer-test.azurewebsites.net/people.json";


        /// <summary>
        /// Gets List of people from API endpoint
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
         async  Task<List<Person>> GetPeopleAsync(string path)
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

            try
            {
                _client.BaseAddress = new Uri(_apiURL);
                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                Task<List<Person>> task = Task.Run<List<Person>>(async () => await GetPeopleAsync(_apiURL));
                people = task.Result;
            }
            catch (Exception e)
            {
                throw e;

            }

            return people;
        }


    }
}
