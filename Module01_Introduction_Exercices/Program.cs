using M01_DAL_Import_Munic_CSV;
using M01_DAL_Import_Munic_JSON;
using M01_DAL_Import_Munic_REST_JSON;
using M01_DAL_Municipalite_MySQL;
using M01_DAL_Municipalite_SQL;
using srvm;
using Unity;

namespace Module01_Introduction_Exercices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            MunicipaliteContextSQL dbcontext = DALDbContextGeneration.ObtenirApplicationDBContext();
            string fichierJson = @"C:\Session4\Distrubution\DSDD_Module01\Municipalite.json";
            string fichierCSV = @"C:\Session4\Distrubution\DSDD_Module01\MUN.csv";

            if (args.Count() >= 1 && args[0] == "json")
            {
                container.RegisterType<IDepotImportationMunicipalites, DepotImportationMunicipaliteRESTJSON>(TypeLifetime.Singleton)
                    .RegisterType<IDepotMunicipalites, DepotMunicipalitesSQL>(TypeLifetime.Singleton, new Unity.Injection.InjectionConstructor(new object[] { dbcontext }));
            }
            else
            {
                container.RegisterType<IDepotImportationMunicipalites, DepotImportationMunicipaliteCSV>(TypeLifetime.Singleton, new Unity.Injection.InjectionConstructor(new object[] { fichierCSV }))
                    .RegisterType<IDepotMunicipalites, DepotMunicipalitesSQL>(TypeLifetime.Singleton, new Unity.Injection.InjectionConstructor(new object[] { dbcontext }));
            }

            TraitementImporterDonneesMunicipalite traitement = container.Resolve<TraitementImporterDonneesMunicipalite>();

            StatistiquesImportationDonnees stats = traitement.Executer();

            Console.WriteLine(stats.ToString());
            

        }
    }
}