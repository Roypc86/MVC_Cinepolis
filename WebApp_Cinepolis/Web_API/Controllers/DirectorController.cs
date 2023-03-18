using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web_API.Controllers
{
    public class DirectorController : ApiController
    {

        [HttpGet]
        public IHttpActionResult Get()
        {
            List<ViewModel.DirectorViewModel> lst = new List<ViewModel.DirectorViewModel>();
            using (Models.API_DatabaseEntities db = new Models.API_DatabaseEntities())
            {
                lst = (from d in db.Director select new ViewModel.DirectorViewModel { Id = d.Id, Nombre = d.Nombre, Biografia = d.Biografia }).ToList();
            }

            return Ok(lst);
        }
    }
}

