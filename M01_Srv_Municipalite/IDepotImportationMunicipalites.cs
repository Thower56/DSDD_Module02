using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace srvm
{
    public interface IDepotImportationMunicipalites
    {
        IEnumerable<Municipalite> LireMunicipalites();
    }
}
