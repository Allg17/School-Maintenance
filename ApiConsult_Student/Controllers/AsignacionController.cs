using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiConsult_Student.Controllers
{
    public class AsignacionController : ApiController
    {
        // GET: api/Asignacion/id
        public IHttpActionResult Get(string id)
        {
            return Ok(Models.AsignacionEstudiante.Get(id));
        }
    }
}
