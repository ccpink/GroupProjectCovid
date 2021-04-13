using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GroupProjectCovid
{
    public class FetchData
    {
        public List<CountryModel> countries;

        public async void GetData()
        {
            countries = new List<CountryModel>();

            string baseUrl = "https://covid-api.mmediagroup.fr/v1";

            try
            {
                using (HttpClient client = new HttpClient())
                {

                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {

                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            if(data != null)
                            {
                                var dataObj = JObject.Parse(data);
                                string country = 
                            }

                        }
                    }
                }
            }
            catch(Exception ex)
            {
                
            }

        }

        return countries;
    }
}
