using Moq;
using srvm;

namespace TestMunicipalite
{
    public class UnitTest1
    {
        [Fact]
        public void TestConsolidationDesDonnes()
        {
            Mock<IDepotImportationMunicipalites> mockImport = new Mock<IDepotImportationMunicipalites>();
            Mock<IDepotMunicipalites> mockDepot = new Mock<IDepotMunicipalites>();

            mockImport.Setup(i => i.LireMunicipalites());
            mockDepot.Setup(d => d.ListerMunicipalites());
            TraitementImporterDonneesMunicipalite traitement = new TraitementImporterDonneesMunicipalite(mockImport.Object, mockDepot.Object);
            StatistiquesImportationDonnees stats = traitement.Executer();

            mockImport.Verify(i => i.LireMunicipalites(), Times.Once);
            mockDepot.Verify(d => d.ListerMunicipalites(), Times.Once);
            mockImport.VerifyNoOtherCalls();
        }

        [Fact]
        public void TestSiConsoliderAjoutUneMunicipalite()
        {
            Mock<IDepotImportationMunicipalites> mockImport = new Mock<IDepotImportationMunicipalites>();
            Mock<IDepotMunicipalites> mockDepot = new Mock<IDepotMunicipalites>();
            Municipalite testMunicipalite = new Municipalite();
            List<Municipalite> mockList1 = new List<Municipalite>();
            List<Municipalite> mockList2 = new List<Municipalite>();
            mockList1.Add(testMunicipalite);

            mockImport.Setup(i => i.LireMunicipalites()).Returns(mockList1);
            mockDepot.Setup(d => d.ListerMunicipalites());
            TraitementImporterDonneesMunicipalite traitement = new TraitementImporterDonneesMunicipalite(mockImport.Object, mockDepot.Object);
            StatistiquesImportationDonnees stats = traitement.Executer();

            mockImport.Verify(i => i.LireMunicipalites(), Times.Once);
            mockDepot.Verify(d2 => d2.ListerMunicipalites(), Times.Once);
            mockDepot.Verify(d3 => d3.AjouterMunicipalite(testMunicipalite), Times.Once);
            mockDepot.VerifyNoOtherCalls();

            Assert.Equal(1, stats.NombreEnregistrementAjoutes);
        }

        [Fact]

        public void TestLaSourceNeContientPasMunicipaliteDoncEstDeactiver()
        {
            Mock<IDepotImportationMunicipalites> mockImport = new Mock<IDepotImportationMunicipalites>();
            Mock<IDepotMunicipalites> mockDepot = new Mock<IDepotMunicipalites>();
            Municipalite testMunicipalite = new Municipalite();
            List<Municipalite> mockList = new List<Municipalite>();
            mockList.Add(testMunicipalite);

            mockDepot.Setup(d => d.ListerMunicipalites()).Returns(mockList);
            TraitementImporterDonneesMunicipalite traitement = new TraitementImporterDonneesMunicipalite(mockImport.Object, mockDepot.Object);
            StatistiquesImportationDonnees stats = traitement.Executer();

            mockDepot.Verify(d => d.ListerMunicipalites(), Times.Once);
            mockDepot.Verify(d => d.DesactiverMunicipalite(testMunicipalite), Times.Once);
            mockDepot.VerifyNoOtherCalls();

            Assert.Equal(1, stats.NombreEnregistrementDesactives);
            Assert.Equal(0, stats.NombreEnregistrementAjoutes);
            Assert.Equal(0, stats.NombreEnregistrementModifies);
            Assert.Equal(0, stats.NombreEnregistrementImportees);
            Assert.Equal(0, stats.NombreEnregistrementNonModifies);
        }

        [Fact]

        public void TestLesDeuxListeContientLaMemeMunicipalite()
        {
            Mock<IDepotMunicipalites> mockDepot = new Mock<IDepotMunicipalites>();
            Mock<IDepotImportationMunicipalites> mockImport = new Mock<IDepotImportationMunicipalites>();
            Municipalite TestMunicipalite = new Municipalite();
            Municipalite TestMunicipalite2 = new Municipalite();
            List<Municipalite> mockList = new List<Municipalite>();
            List<Municipalite> mockList2 = new List<Municipalite>();
            TestMunicipalite.CodeGeographique = 1;
            TestMunicipalite.NomMunicipalite = "St-Gg";
            TestMunicipalite2.CodeGeographique = 1;
            TestMunicipalite2.NomMunicipalite = "St-Ff";
            mockList.Add(TestMunicipalite);
            mockList2.Add(TestMunicipalite2);

            mockImport.Setup(i => i.LireMunicipalites()).Returns(mockList);
            mockDepot.Setup(d1 => d1.ListerMunicipalites()).Returns(mockList2);

            TraitementImporterDonneesMunicipalite traitement = new TraitementImporterDonneesMunicipalite(mockImport.Object, mockDepot.Object);
            StatistiquesImportationDonnees stats = traitement.Executer();

            mockImport.Verify(i => i.LireMunicipalites(), Times.Once);
            mockDepot.Verify(d3 => d3.ListerMunicipalites(), Times.Once);
            mockDepot.Verify(d4 => d4.MAJMunicipalite(TestMunicipalite), Times.Once);
            mockDepot.VerifyNoOtherCalls();

            Assert.Equal(0, stats.NombreEnregistrementDesactives);
            Assert.Equal(0, stats.NombreEnregistrementAjoutes);
            Assert.Equal(1, stats.NombreEnregistrementModifies);
            Assert.Equal(1, stats.NombreEnregistrementImportees);
            Assert.Equal(0, stats.NombreEnregistrementNonModifies);
        }

        [Fact]

        public void Test_MunicipaliteEstAModifier_EtUneEstAAjouter()
        {
            Mock<IDepotMunicipalites> mockDepot = new Mock<IDepotMunicipalites>();
            Mock<IDepotImportationMunicipalites> mockImpot = new Mock<IDepotImportationMunicipalites>();
            Municipalite TestMunicipalite = new Municipalite();
            Municipalite TestMunicipalite2 = new Municipalite();
            Municipalite TestMunicipalite3 = new Municipalite();
            List<Municipalite> mockList = new List<Municipalite>();
            List<Municipalite> mockList2 = new List<Municipalite>();
            TestMunicipalite.CodeGeographique = 1;
            TestMunicipalite.NomMunicipalite = "St-Gg";
            TestMunicipalite2.CodeGeographique = 1;
            TestMunicipalite2.NomMunicipalite = "St-Ff";
            TestMunicipalite3.CodeGeographique = 3;

            mockList.Add(TestMunicipalite);
            mockList.Add(TestMunicipalite3);

            mockList2.Add(TestMunicipalite2);

            mockImpot.Setup(i => i.LireMunicipalites()).Returns(mockList);
            mockDepot.Setup(d1 => d1.ListerMunicipalites()).Returns(mockList2);

            TraitementImporterDonneesMunicipalite traitement = new TraitementImporterDonneesMunicipalite(mockImpot.Object, mockDepot.Object);
            StatistiquesImportationDonnees stats = traitement.Executer();

            mockDepot.Verify(d1 => d1.MAJMunicipalite(TestMunicipalite), Times.Once);
            mockDepot.Verify(d2 => d2.ListerMunicipalites(), Times.Once);
            mockDepot.Verify(d => d.AjouterMunicipalite(TestMunicipalite3), Times.Once);
            mockImpot.Verify(i => i.LireMunicipalites(), Times.Once);
            mockDepot.VerifyNoOtherCalls();

            Assert.Equal(0, stats.NombreEnregistrementDesactives);
            Assert.Equal(1, stats.NombreEnregistrementAjoutes);
            Assert.Equal(1, stats.NombreEnregistrementModifies);
            Assert.Equal(2, stats.NombreEnregistrementImportees);
            Assert.Equal(0, stats.NombreEnregistrementNonModifies);
        }
    }
}