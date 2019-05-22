using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.IO;
using System.Dynamic;
using MalariaAPI.Models;

namespace MalariaAPI.Controllers
{
    [RoutePrefix("api/Vaccination")]
    public class VaccinationController : ApiController
    {
        //READ
        [HttpGet]
        [Route("AllVaccinationDetails")]
        public List<dynamic> getAllVaccination()
        {
            MalariaEntities1 db = new MalariaEntities1();
            db.Configuration.ProxyCreationEnabled = false;
            return getVaccinationList(db.Vaccinations.ToList());
        }

        private List<dynamic> getVaccinationList(List<Vaccination> forVaccination)
        {
            List<dynamic> dynamicVaccinations = new List<dynamic>();
            foreach (Vaccination vaccination in forVaccination)
            {
                dynamic dynamicVaccination = new ExpandoObject();
                dynamicVaccination.VaccinationID = vaccination.Vaccination_ID;
                dynamicVaccination.VaccinationDesc = vaccination.Vaccination_Description;
                dynamicVaccinations.Add(dynamicVaccination);
            }
            return dynamicVaccinations;
        }

        //UPDATE
        [HttpPut]
        [Route("UpdateVaccination")]
        public List<dynamic> UpdateVaccination([FromBody] Vaccination vaccination)
        {
            if (vaccination != null)
            {
                MalariaEntities1 db = new MalariaEntities1();
                db.Configuration.ProxyCreationEnabled = false;
                Vaccination objVac = db.Vaccinations.Where(p => p.Vaccination_ID == vaccination.Vaccination_ID).FirstOrDefault();
                objVac.Vaccination_Description = vaccination.Vaccination_Description;
                db.SaveChanges();
                return getAllVaccination();
            }
            else
            {
                return null;
            }

        }

        //DELETE
        [HttpDelete]
        [Route("DeleteVaccination")]
        public List<dynamic> DeleteVaccination(int ID)
        {
            MalariaEntities1 db = new MalariaEntities1();
            db.Configuration.ProxyCreationEnabled = false;
            Vaccination objVac = db.Vaccinations.Where(p => p.Vaccination_ID == ID).FirstOrDefault();
            if (objVac != null)
            {
                db.Vaccinations.Remove(objVac);
                db.SaveChanges();
                return getAllVaccination();
            }
            else
            {
                return null;
            }

        }
    }
}
