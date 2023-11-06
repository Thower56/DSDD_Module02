using srvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M01_Srv_Municipalite
{
    public class ManipulationMunicipalites
    {
        private IDepotMunicipalites m_depotMunicipalites;

        public ManipulationMunicipalites(IDepotMunicipalites p_depotMunicipalites)
        {
            this.m_depotMunicipalites = p_depotMunicipalites;
        }

        public Municipalite ObtenirMunicipalites(int p_codeGeographique)
        {
            return m_depotMunicipalites.ChercherMunicipaliteParCodeGeographique(p_codeGeographique);
        }
        public List<Municipalite> ListerMunicipalites()
        {
            return m_depotMunicipalites.ListerMunicipalites().ToList();
        }
        public void SupprimerMunicipalite(int p_codeGeographique)
        {
            m_depotMunicipalites.DesactiverMunicipalite(m_depotMunicipalites.ChercherMunicipaliteParCodeGeographique(p_codeGeographique));
        }
        public void AjouterMunicipalite(Municipalite p_municipalite)
        {
            m_depotMunicipalites.AjouterMunicipalite(p_municipalite);
        }
        public void MAJMunicipalite(Municipalite p_municipalite)
        {
            m_depotMunicipalites.MAJMunicipalite(p_municipalite);
        }
    }
}
