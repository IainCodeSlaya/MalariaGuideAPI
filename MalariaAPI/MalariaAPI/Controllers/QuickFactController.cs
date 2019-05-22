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
    [RoutePrefix("api/QuickFact")]
    public class QuickFactController : ApiController
    {
        //READ
        [HttpGet]
        [Route("AllQuickFactDetails")]
        public List<dynamic> getAllQuickFact()
        {
            MalariaEntities1 db = new MalariaEntities1();
            db.Configuration.ProxyCreationEnabled = false;
            return getQuickFactList(db.Quick_Fact.ToList());
        }

        private List<dynamic> getQuickFactList(List<Quick_Fact> forFact)
        {
            List<dynamic> dynamicQuickFacts = new List<dynamic>();
            foreach (Quick_Fact quick_Fact in forFact)
            {
                dynamic dynamicQuickFact = new ExpandoObject();
                dynamicQuickFact.QuickFactID = quick_Fact.Quick_Fact_ID;
                dynamicQuickFact.QuickFact = quick_Fact.Fact;
                dynamicQuickFacts.Add(dynamicQuickFact);
            }
            return dynamicQuickFacts;
        }

        //UPDATE
        [HttpPut]
        [Route("UpdateQuickFact")]
        public List<dynamic> UpdateQuickFact([FromBody] Quick_Fact quick_Fact)
        {
            if (quick_Fact != null)
            {
                MalariaEntities1 db = new MalariaEntities1();
                db.Configuration.ProxyCreationEnabled = false;
                Quick_Fact objFact = db.Quick_Fact.Where(p => p.Quick_Fact_ID == quick_Fact.Quick_Fact_ID).FirstOrDefault();
                objFact.Fact = quick_Fact.Fact;
                db.SaveChanges();
                return getAllQuickFact();
            }
            else
            {
                return null;
            }

        }

        //DELETE
        [HttpDelete]
        [Route("DeleteQuickFact")]
        public List<dynamic> DeleteQuickFact(int ID)
        {
            MalariaEntities1 db = new MalariaEntities1();
            db.Configuration.ProxyCreationEnabled = false;
            Quick_Fact objFact = db.Quick_Fact.Where(p => p.Quick_Fact_ID == ID).FirstOrDefault();
            if (objFact != null)
            {
                db.Quick_Fact.Remove(objFact);
                db.SaveChanges();
                return getAllQuickFact();
            }
            else
            {
                return null;
            }

        }
    }
}
