using PetApp.Common;
using PetApp.Data;
using System;
using System.Collections.Generic;


namespace PetApp.Model
{
    public class PetInfo
    {
        PetAppAPIService peopleApi = new PetAppAPIService();

        /// <summary>
        /// Return the list of the people
        /// </summary>
        /// <returns></returns>
        public List<Person> GetPeople()
        {
            List<Person> people = peopleApi.GetAllPeople();
            return people;
        }


        /// <summary>
        /// Create the data model of Cat
        /// </summary>
        /// <param name="catStat"></param>
        /// <param name="gender"></param>
        /// <param name="catName"></param>
        private void AddCats(Dictionary<String, CatStat> catStat, String gender, String catName)
        {
            if (!catStat.ContainsKey(gender))
            {
                catStat.Add(gender, new CatStat(gender));
            }
            catStat[gender].CatNames.Add(catName);
        }

        /// <summary>
        /// Create and return data model of Cat 
        /// Cat are listed under owner gender
        /// </summary>
        /// <returns></returns>
        public Dictionary<String, CatStat> GetCatByGender()
        {
            List<Person> people = GetPeople();

            if (people == null)
                throw new Exception("People API did not return any result");

            Dictionary<String, CatStat> catStat = new Dictionary<String, CatStat>();           

            foreach (var person in people)
            {

                String gender = (person.Gender != null) ? person.Gender : "";
                if (person.Pets != null)
                {
                    foreach (var pet in person.Pets)
                    {
                        if (pet.Type.ToUpper() == "CAT")
                        {
                            AddCats(catStat, gender, pet.Name);
                        }
                    }
                }
            }
            foreach (var stat in catStat)
            {
                stat.Value.CatNames.Sort();
            }

            return catStat;
        }


    }
}
