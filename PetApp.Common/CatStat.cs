using System;
using System.Collections.Generic;


namespace PetApp.Common
{
   public class CatStat
    {

        public CatStat(String gender)
        {
            OwnerGender = gender;
        }
        public String OwnerGender { get; set; }
        public List<String> CatNames  = new List<string>();
    }
}
