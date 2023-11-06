using M01_DAL_Municipalite_MySQL;
using Microsoft.IdentityModel.Tokens;
using srvm;
using System.Linq;

namespace M01_DAL_Import_Munic_CSV
{
    public class DepotImportationMunicipaliteCSV : IDepotImportationMunicipalites
    {
        private string m_nomFichier;

        public DepotImportationMunicipaliteCSV()
        {
        }

        public DepotImportationMunicipaliteCSV(string nomFichier)
        {
            m_nomFichier = nomFichier;
        }

        public IEnumerable<Municipalite> LireMunicipalites()
        {
            List<string> informationMunicipalite = new List<string>();
            List<Municipalite> listeMunicipalite = new List<Municipalite>();

            string line;
            string[] Municipalite = File.ReadAllLines(m_nomFichier);

                
            listeMunicipalite = Municipalite.Skip(1).Select(m =>
            {
                string[] lineMunicipalite = m.Split("\",\"");
                return new Municipalite
                (
                    int.Parse(lineMunicipalite[0].Trim('"')), lineMunicipalite[1], lineMunicipalite[7], lineMunicipalite[8], lineMunicipalite[20].IsNullOrEmpty() ? null : DateTime.Parse(lineMunicipalite[20])
                );
            }).ToList();
                
            return listeMunicipalite;
        }
    }
}