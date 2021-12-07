using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspSwaggerRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        List<Beer> beers = new List<Beer>()
        {
            new Beer(){Id=1, Name="cerveza 1"},
            new Beer(){Id=2, Name="cerveza 2"},
            new Beer(){Id=3, Name="cerveza 3"}
        };

        [HttpGet]
        public ActionResult<Beer> Get(int id)
        {
            var beer = beers.Where(b => b.Id == id).FirstOrDefault();
            if (beer == null) return NotFound();
            return beer;
        }
    }

    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
