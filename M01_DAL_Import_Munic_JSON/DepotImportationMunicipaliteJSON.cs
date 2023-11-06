using M01_DAL_Municipalite_MySQL;
using Newtonsoft.Json;
using srvm;

namespace M01_DAL_Import_Munic_JSON
{
    public class DepotImportationMunicipaliteJSON : IDepotImportationMunicipalites
    {
        private string m_nomFichier;

        public DepotImportationMunicipaliteJSON()
        {
        }

        public DepotImportationMunicipaliteJSON(string p_nomFichier)
        {
            m_nomFichier = p_nomFichier;
        }

        public IEnumerable<Municipalite> LireMunicipalites()
        {
            List<Municipalite> listMunicipalite;

            if (File.Exists(m_nomFichier))
            {
                string json = File.ReadAllText(m_nomFichier);
                Rootobject rootObject = JsonConvert.DeserializeObject<Rootobject>(json);

                listMunicipalite = rootObject.result.records
                    .Select(m => new Municipalite(m.mcode, m.munnom, m.mcourriel, m.mweb, m.datelec))
                    .ToList();
            } 

            else
            {
                listMunicipalite = new List<Municipalite>();
            }

            return listMunicipalite;
            
        }
    }
}
