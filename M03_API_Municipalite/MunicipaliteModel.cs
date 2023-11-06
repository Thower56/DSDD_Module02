using srvm;

namespace M03_API_Municipalite
{
    public class MunicipaliteModel
    {
        int MunicipaliteID { get; set; }
        string NomMunicipalite { get; set; }
        string AdresseCourriel { get; set; }
        string AdresseWeb { get; set; }
        DateTime? DateProchaineElection { get; set; }
        bool Actif { get; set; }

        public MunicipaliteModel()
        {
            
        }
        public MunicipaliteModel(Municipalite p_municipalite)
        {
            this.MunicipaliteID = p_municipalite.CodeGeographique;
            this.NomMunicipalite = p_municipalite.NomMunicipalite;
            this.AdresseCourriel = p_municipalite.AdresseCourriel;
            this.AdresseWeb = p_municipalite.AdresseWeb;
            this.DateProchaineElection = p_municipalite.DateProchaineElection;
            this.Actif = p_municipalite.Actif;
        }
        Municipalite VersEntite()
        {
            return new Municipalite()
            {
                CodeGeographique = this.MunicipaliteID,
                NomMunicipalite = this.NomMunicipalite,
                AdresseCourriel = this.AdresseCourriel,
                AdresseWeb = this.AdresseWeb,
                DateProchaineElection = this.DateProchaineElection,
                Actif = this.Actif
            };
        }
    }
}
