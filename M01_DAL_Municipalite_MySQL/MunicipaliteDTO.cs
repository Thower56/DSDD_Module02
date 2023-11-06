using srvm;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M01_DAL_Municipalite_MySQL
{
    public class MunicipaliteDTO
    {
        [Key]
        [Column("id")]
        public int MunicipaliteID { get; set; }
        public string NomMunicipalite { get; set; }
        public string? AdresseCourriel { get; set; }
        public string? AdresseWeb { get; set; }
        public DateTime? DateProchaineElection { get; set; }
        public MunicipaliteDTO()
        {
            
        }
        public MunicipaliteDTO(srvm.Municipalite p_municipalite)
        {
            MunicipaliteID = p_municipalite.CodeGeographique;
            NomMunicipalite = p_municipalite.NomMunicipalite;
            AdresseCourriel = p_municipalite.AdresseCourriel;
            AdresseWeb = p_municipalite.AdresseWeb;
            DateProchaineElection = p_municipalite.DateProchaineElection;
        }

        public MunicipaliteDTO(int municipaliteID, string nomMunicipalite, string? adresseCourriel, string? adresseWeb, DateTime? dateProchaineElection)
        {
            MunicipaliteID = municipaliteID;
            NomMunicipalite = nomMunicipalite;
            AdresseCourriel = adresseCourriel;
            AdresseWeb = adresseWeb;
            DateProchaineElection = dateProchaineElection;
        }

        public srvm.Municipalite VersEntite()
        {
            return new srvm.Municipalite(MunicipaliteID, NomMunicipalite, AdresseCourriel, AdresseWeb, DateProchaineElection);
        }
    }
}