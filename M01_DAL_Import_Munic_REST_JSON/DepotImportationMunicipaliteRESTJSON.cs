using Newtonsoft.Json;
using srvm;
using System.Diagnostics;

namespace M01_DAL_Import_Munic_REST_JSON
{
    public class DepotImportationMunicipaliteRESTJSON : IDepotImportationMunicipalites
    {
        private static HttpClient httpClient;

        public DepotImportationMunicipaliteRESTJSON()
        {
            httpClient = new HttpClient();
        }

        private static async Task<List<Municipalite>> Requete()
        {
            List<Municipalite> municipalites = null;

            httpClient.BaseAddress = new Uri("https://www.donneesquebec.ca");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await httpClient.GetAsync("/recherche/api/action/datastore_search?resource_id=19385b4e-5503-4330-9e59-f998f5918363&limit=3000");

            if (response.IsSuccessStatusCode)
            {
                string contenuJSON = await response.Content.ReadAsStringAsync();
                Rootobject rootObject = JsonConvert.DeserializeObject<Rootobject>(contenuJSON);

                municipalites = rootObject.result.records
                    .Select(m => new Municipalite(m.mcode, m.munnom, m.mcourriel, m.mweb, m.datelec))
                    .ToList();
            }

            return municipalites ?? new List<Municipalite>();
        }
        public IEnumerable<Municipalite> LireMunicipalites()
        {
            Task<List<Municipalite>> resultat = Requete();
            resultat.Wait();

            return resultat.Result;
        }
    }
}