using ApiPrueba1.Models;
using ApiPrueba1.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ApiPrueba1.Controllers
{
    [RoutePrefix("api/edicion")]
    public class EdicionController: ApiController
    {
        private DTOEdicion dtoEdicion = new DTOEdicion();

        [HttpGet]
        [Route("edicion-controller")]
        public List<Edicion> GetEdiciones()
        {
            return dtoEdicion.GetEdiciones();
        }
    }
}