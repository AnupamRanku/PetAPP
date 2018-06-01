using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
