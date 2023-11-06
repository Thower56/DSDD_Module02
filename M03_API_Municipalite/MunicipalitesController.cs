using M01_Srv_Municipalite;
using Microsoft.AspNetCore.Mvc;

namespace M03_API_Municipalite
{
    public class MunicipalitesController
    {
        private ManipulationMunicipalites m_manipulationMunicipalites;

        public MunicipalitesController(ManipulationMunicipalites manipulationMunicipalites)
        {
            m_manipulationMunicipalites = manipulationMunicipalites;
        }
        public ActionResult<IEnumerable<MunicipaliteModel>> Get()
        {
            return m_manipulationMunicipalites.ListerMunicipalites().Select(m => new MunicipaliteModel(m)).ToList();
        }
        public ActionResult<MunicipaliteModel> Get(int p_municipaliteId)
        {
            return new MunicipaliteModel(m_manipulationMunicipalites.ObtenirMunicipalites(p_municipaliteId));
        }
        public ActionResult Post(int p_municipaliteId, MunicipaliteModel p_municipalite) { }
        public ActionResult Put(int p_municipaliteId, MunicipaliteModel p_municipalite) { }
        public ActionResult Delete(int p_municipaliteId) { }
    }
}
