using ApiPrueba1.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ApiPrueba1.Controllers
{
    [RoutePrefix("api/formato")]
    public class FormatoController: ApiController
    {

        private DTOFormato dtoFormato = new DTOFormato();

        public List<Models.Formato> GetFormatos()
        {
            return dtoFormato.GetFormatos();
        }


    }
}