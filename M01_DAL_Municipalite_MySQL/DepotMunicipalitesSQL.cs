using srvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M01_DAL_Municipalite_MySQL
{
    public class DepotMunicipalitesSQL : IDepotMunicipalites
    {
        private readonly MunicipaliteContextSQL m_dbContext;

        public DepotMunicipalitesSQL(MunicipaliteContextSQL p_context)
        {
            m_dbContext = p_context;
        }

        public void AjouterMunicipalite(srvm.Municipalite p_municipalite)
        {
            m_dbContext.Add(new MunicipaliteDTO(p_municipalite));
            m_dbContext.SaveChanges();
        }

        public Municipalite ChercherMunicipaliteParCodeGeographique(int p_codeGeograhpique)
        {
            return m_dbContext.MUNICIPALITES.Where(m => m.MunicipaliteID == p_codeGeograhpique).SingleOrDefault().VersEntite();
            
        }

        public void DesactiverMunicipalite(srvm.Municipalite p_municipalite)
        {
            m_dbContext.MUNICIPALITES.Where(m => m.MunicipaliteID == p_municipalite.CodeGeographique).SingleOrDefault().VersEntite().Actif = false;
            m_dbContext.SaveChanges();
        }

        public IEnumerable<srvm.Municipalite> ListerMunicipalites()
        {
            return m_dbContext.MUNICIPALITES.Select(m => m.VersEntite()).ToList();
        }

        public void MAJMunicipalite(srvm.Municipalite p_municipalite)
        {
            MunicipaliteDTO m = m_dbContext.MUNICIPALITES.Where(m => m.MunicipaliteID == p_municipalite.CodeGeographique).SingleOrDefault();

            m.MunicipaliteID = p_municipalite.CodeGeographique;
            m.NomMunicipalite = p_municipalite.NomMunicipalite;
            m.AdresseCourriel = p_municipalite.AdresseCourriel;
            m.AdresseWeb = p_municipalite.AdresseWeb;
            m.DateProchaineElection = p_municipalite.DateProchaineElection;

            m_dbContext.Update(m);
            m_dbContext.SaveChanges();
        }
    }
}
