using GestionNotes_DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Mvc.HttpGetAttribute;

namespace GestionNotes_IHM.Controllers.API
{
    public class DataController : ApiController
    {
        
        [HttpGet]
        public float Get(long id)
        {
            float moyenne;
            GestionNotesContext ctx;

            ctx = new GestionNotesContext();
            moyenne = ctx.Evaluations.Where(o => o.IdEleve == id).Select(o => o.Note).DefaultIfEmpty(0).Average();

           // moyenne = (from i in ctx.Evaluations where o.IdEleve == id select o.Notes).DedaultIdEmpty(0).Average();

            return moyenne;
        }
    }
}
