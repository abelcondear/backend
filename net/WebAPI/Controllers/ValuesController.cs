using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace WebAPI.Controllers
{
    public class CoordinateObject
    {
        public long latitude { get; set; }
        public long longitude { get; set; }
    }

    public class DataObject
    {
        public string name { get; set; }
        public string capital { get; set; }
        public string region { get; set; }
        public string subregion { get; set; }
        public long population { get; set; }
        public long area { get; set; }
        
        public CoordinateObject coordinates { get; set; }

        public IEnumerable<string> borders { get; set; }
        public IEnumerable<string> timezones { get; set; }
        
        public string currency { get; set; }

        public IEnumerable<string> languages { get; set; }

        public string flag { get; set; }
    }

    public class ValuesController : ApiController
    {
        // GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        private static DataObject GetAPIContent(string path) { 
            HttpClient client = new HttpClient();
            Task<HttpResponseMessage> response = client.GetAsync(path);
            DataObject dataobject = new DataObject();

            if (response.Result.IsSuccessStatusCode)
            {
                var data = response.Result.Content.ReadAsAsync<JObject>().Result;

                dataobject.name = data["data"]["name"].ToString();

                dataobject.capital = data["data"]["capital"].ToString();

                dataobject.region = data["data"]["region"].ToString();

                dataobject.subregion = data["data"]["subregion"].ToString();

                dataobject.population = long.Parse(data["data"]["population"].ToString());

                dataobject.area = long.Parse(data["data"]["area"].ToString());

                dataobject.coordinates = new CoordinateObject();

                dataobject.coordinates.latitude = long.Parse(data["data"]["coordinates"]["latitude"].ToString().Replace(",",""));

                dataobject.coordinates.longitude = long.Parse(data["data"]["coordinates"]["longitude"].ToString().Replace(",", ""));

                dataobject.borders = data["data"]["borders"].Values<string>();

                dataobject.timezones = data["data"]["timezones"].Values<string>();

                dataobject.currency = data["data"]["currency"].ToString();

                dataobject.languages = data["data"]["languages"].Values<string>();

                dataobject.flag = data["data"]["flag"].ToString();
            }

            return dataobject;
        }

        ///Api/Values/?name=Brazil
        public string Get(string name)
        {
            CountriesModel countries = new CountriesModel();            
            DataObject dataobject = GetAPIContent($"https://countries-api-abhishek.vercel.app/countries/{name}");

            country country_entity = new country();
            country_entity.name = dataobject.name;
            country_entity.capital = dataobject.capital;
            country_entity.region = dataobject.region;
            country_entity.subregion = dataobject.subregion;
            country_entity.population = int.Parse(dataobject.population.ToString());
            country_entity.area = int.Parse(dataobject.area.ToString());
            country_entity.currency = dataobject.currency;
            country_entity.flag = dataobject.flag;
            countries.country.Add(country_entity);

            countries.SaveChanges();
            int country_id = country_entity.id;

            IEnumerator<string> iborder = dataobject.borders.GetEnumerator(); 
                        
            while (iborder.MoveNext()) { 
                border border_entity = new border();
                border_entity.country_id = country_id;
                border_entity.name = iborder.Current;                
                countries.border.Add(border_entity);
            }

            IEnumerator<string> ilanguages = dataobject.languages.GetEnumerator();

            language language_entity;

            while (ilanguages.MoveNext())
            {
                language_entity = new language();
                language_entity.country_id = country_id;
                language_entity.name = ilanguages.Current;               
                countries.language.Add(language_entity);
            }

            IEnumerator<string> itimezones = dataobject.timezones.GetEnumerator();

            timezone timezone_entity;

            while (itimezones.MoveNext())
            {
                timezone_entity = new timezone();
                timezone_entity.country_id = country_id;
                timezone_entity.name = itimezones.Current;
                countries.timezone.Add(timezone_entity);
            }


            coordinate coordinate_entity = new coordinate();
            coordinate_entity.country_id = country_id;
            coordinate_entity.latitude = long.Parse(dataobject.coordinates.latitude.ToString());
            coordinate_entity.longitude = long.Parse(dataobject.coordinates.longitude.ToString());
            countries.coordinate.Add(coordinate_entity);

            countries.SaveChanges();

            // then trying to use xml object from net framework to make it more sophisticated
            string content = dataobject.name;

            content = content + ';' + dataobject.capital;
            content = content + ';' + dataobject.region;
            content = content + ';' + dataobject.subregion;

            content = content + ';' + dataobject.population.ToString();
            content = content + ';' + dataobject.area.ToString();

            content = content + ';' + dataobject.coordinates.latitude.ToString();
            content = content + ';' + dataobject.coordinates.longitude.ToString();

            content = content + ';' + string.Join("-", dataobject.borders);
            content = content + ';' + string.Join("-", dataobject.timezones);

            content = content + ';' + dataobject.currency;

            content = content + ';' + string.Join("-", dataobject.languages);

            content = content + ';' + dataobject.flag;

            return content;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
