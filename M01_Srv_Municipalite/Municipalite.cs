using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace srvm
{
    public class Municipalite
    {
        public int CodeGeographique { get; set; }
        public string NomMunicipalite { get; set; }
        public string? AdresseCourriel { get; set; }
        public string? AdresseWeb { get; set; }
        public DateTime? DateProchaineElection { get; set; }
        public bool Actif { get; set; }

        public Municipalite()
        {
            ;
        }
        public Municipalite(int codeGeographique, string nomMunicipalite, string? adresseCourriel, string? adresseWeb, DateTime? dateProchaineElection)
        {
            CodeGeographique = codeGeographique;
            NomMunicipalite = nomMunicipalite;
            AdresseCourriel = adresseCourriel;
            AdresseWeb = adresseWeb;
            DateProchaineElection = dateProchaineElection;

        }

        public Municipalite(int codeGeographique, string nomMunicipalite, string? adresseCourriel, string? adresseWeb, DateTime? dateProchaineElection, bool actif)
        {
            CodeGeographique = codeGeographique;
            NomMunicipalite = nomMunicipalite;
            AdresseCourriel = adresseCourriel;
            AdresseWeb = adresseWeb;
            DateProchaineElection = dateProchaineElection;
            Actif = actif;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Municipalite))
            {
                return false;
            }
            else
            {
                Municipalite m = (Municipalite)obj;
                return (m.CodeGeographique == CodeGeographique && m.NomMunicipalite == NomMunicipalite && m.AdresseCourriel == AdresseCourriel && m.AdresseWeb == AdresseWeb);
            }

        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CodeGeographique, NomMunicipalite, AdresseCourriel, AdresseWeb, DateProchaineElection);
        }
    }
}
