namespace srvm
{
    public class StatistiquesImportationDonnees
    {
        public int NombreEnregistrementAjoutes { get; set; }
        public int NombreEnregistrementModifies { get; set; }
        public int NombreEnregistrementDesactives { get; set; }
        public int NombreEnregistrementNonModifies { get; set; }
        public int NombreEnregistrementImportees { get; set; }

        public override string? ToString()
        {
            return $"- Ajout:{NombreEnregistrementAjoutes} \n- Modifier:{NombreEnregistrementModifies} \n- Desactives:{NombreEnregistrementDesactives} \n" +
                            $"- Non Modifier:{NombreEnregistrementNonModifies} \n- Importer:{NombreEnregistrementImportees}";
        }
    }
}