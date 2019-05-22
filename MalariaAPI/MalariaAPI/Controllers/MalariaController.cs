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
    [RoutePrefix("api/Malaria")]
    public class MalariaController : ApiController
    {
        //READ
        [HttpGet]
        [Route("AllMalariaDetails")]
        public List<dynamic> getAllMalaria()
        {
            MalariaEntities1 db = new MalariaEntities1();
            db.Configuration.ProxyCreationEnabled = false;
            return getMalariaList(db.Malarias.ToList());
        }

        private List<dynamic> getMalariaList(List<Malaria> forMalaria)
        {
            List<dynamic> dynamicMalarias = new List<dynamic>();
            foreach (Malaria malaria in forMalaria)
            {
                dynamic dynamicMalaria = new ExpandoObject();
                dynamicMalaria.MalariaID = malaria.Malaria_ID;
                dynamicMalaria.MalariaBG = malaria.Malaria_Background;
                dynamicMalarias.Add(dynamicMalaria);
            }
            return dynamicMalarias;
        }

        //UPDATE
        [HttpPut]
        [Route("UpdateMalaria")]
        public List<dynamic> UpdateMalaria([FromBody] Malaria malaria)
        {
            if (malaria != null)
            {
                MalariaEntities1 db = new MalariaEntities1();
                db.Configuration.ProxyCreationEnabled = false;
                Malaria objMal = db.Malarias.Where(p => p.Malaria_ID == malaria.Malaria_ID).FirstOrDefault();
                objMal.Malaria_Background = malaria.Malaria_Background;
                db.SaveChanges();
                return getAllMalaria();
            }
            else
            {
                return null;
            }

        }

        //DELETE
        [HttpDelete]
        [Route("DeleteMalaria")]
        public List<dynamic> DeleteMalaria(int ID)
        {
            MalariaEntities1 db = new MalariaEntities1();
            db.Configuration.ProxyCreationEnabled = false;
            Malaria objMal = db.Malarias.Where(p => p.Malaria_ID == ID).FirstOrDefault();
            if (objMal != null)
            {
                db.Malarias.Remove(objMal);
                db.SaveChanges();
                return getAllMalaria();
            }
            else
            {
                return null;
            }

        }
    }
}
