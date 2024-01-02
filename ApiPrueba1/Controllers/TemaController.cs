using ApiPrueba1.Models;
using ApiPrueba1.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiPrueba1.Controllers
{

    [RoutePrefix("api/tema")]
    public class TemaController : ApiController
        
    {

        private DTOTema DtoTema = new DTOTema();

        [HttpGet]
        [Route("tema-controller")]
        public List<Tema> getTemas()
        {
            return DtoTema.GetTemas();
        }

        [HttpPost]
        [Route("tema-controller")]
        public string postTema([FromUri]string name)
        {
            if (name == null) throw new ArgumentNullException();
            if (DtoTema.PostTema(name))
            {
                return "value added";
            }
            return "Error";
        }


    }
}
