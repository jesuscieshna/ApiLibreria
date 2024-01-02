using ApiPrueba1.Models;
using ApiPrueba1.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ApiPrueba1.Controllers
{
    [RoutePrefix("api/autor")]
    public class AutorController : ApiController
    {
        private DTOAutor DtoAutor = new DTOAutor();

        [HttpGet]
        [Route("autor-controller")]
        public List<Autor> getTemas()
        {
            return DtoAutor.getAutores();
        }
    }
}