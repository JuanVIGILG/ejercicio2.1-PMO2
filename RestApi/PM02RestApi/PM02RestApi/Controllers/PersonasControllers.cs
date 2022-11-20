using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PM02RestApi.Controllers
{
    public class PersonasControllers
    {
        public async static Task<List<Models.Personas>> getpersonas()
        {
            List<Models.Personas> listapersonas = new List<Models.Personas>();

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");
                if (response.IsSuccessStatusCode)
                {
                    var contenido = response.Content.ReadAsStringAsync().Result;
                    listapersonas = JsonConvert.DeserializeObject<List<Models.Personas>>(contenido);

                }
            }
            return listapersonas;
        }

    }
}
