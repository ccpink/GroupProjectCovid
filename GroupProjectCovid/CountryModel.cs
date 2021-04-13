using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProjectCovid
{
    public class CountryModel
    {
        public string countryName { get; set; }
        public string countryPop { get; set; }
        public string countryCapitol { get; set; }

        public string cTotalCases { get; set; }
        public string cTotalRecovered { get; set; }
        public string cTotalDeaths { get; set; }

        public string cTotalVacines { get; set; }
        public string cTotalPartialVacines { get; set; }
        public string cTotalUnvaccinated { get; set; }


        public CountryModel(string name, string pop, string capitol, string totalCases, 
            string totalRecovered, string totalDeaths, string totalVac, string totalPartial, 
            string totalUnVac)
        {
            countryName = name;
            countryPop = pop;
            countryCapitol = capitol;
            cTotalCases = totalCases;
            cTotalRecovered = totalRecovered;
            cTotalDeaths = totalDeaths;
            cTotalVacines = totalVac;
            cTotalPartialVacines = totalPartial;
            cTotalUnvaccinated = totalUnVac;
        }



    }
}
