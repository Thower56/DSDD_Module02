using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace srvm
{
    public class TraitementImporterDonneesMunicipalite
    {
        private IDepotMunicipalites m_depotMunicipalites;
        private IDepotImportationMunicipalites m_importationMunicipalites;
        public TraitementImporterDonneesMunicipalite(IDepotImportationMunicipalites p_depotImportationMunicipalites, IDepotMunicipalites p_depotMunicipalites)
        {
            m_depotMunicipalites = p_depotMunicipalites;
            m_importationMunicipalites = p_depotImportationMunicipalites;
        }

        public StatistiquesImportationDonnees Executer()
        {
            Dictionary<int, Municipalite> ImportationMunicipalite = new Dictionary<int, Municipalite>();
            Dictionary<int, Municipalite> DestinationMunicipalite = new Dictionary<int, Municipalite>();
            StatistiquesImportationDonnees statistiques = new StatistiquesImportationDonnees();

            foreach (Municipalite item in m_depotMunicipalites.ListerMunicipalites())
            {
                DestinationMunicipalite.Add(item.CodeGeographique, item);
            }

            foreach (Municipalite item in m_importationMunicipalites.LireMunicipalites())
            {
                ImportationMunicipalite.Add(item.CodeGeographique, item);
                statistiques.NombreEnregistrementImportees++;

                if (!DestinationMunicipalite.ContainsKey(item.CodeGeographique))
                {
                    m_depotMunicipalites.AjouterMunicipalite(item);
                    statistiques.NombreEnregistrementAjoutes++;
                }
                else 
                {
                    if (!item.Equals(DestinationMunicipalite[item.CodeGeographique]))
                    {
                        m_depotMunicipalites.MAJMunicipalite(item);
                        statistiques.NombreEnregistrementModifies++;
                    }
                    else
                    {
                        statistiques.NombreEnregistrementNonModifies++;
                    }
                }
            }

            foreach (KeyValuePair<int, Municipalite> m in DestinationMunicipalite)
            {
                if (!ImportationMunicipalite.ContainsKey(m.Key))
                {
                    m_depotMunicipalites.DesactiverMunicipalite(m.Value);
                    statistiques.NombreEnregistrementDesactives++;
                }
            }
            return statistiques;
        }
    }
}
