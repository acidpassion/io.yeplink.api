using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YeplinkAppApi.Model;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NotebookAppApi.Controllers
{
    public class ValuesController : Controller
    {
        // GET: api/values
        [Route("api/pankos")]
        [HttpGet]
        public IEnumerable<Panko> GetPankos()
        {
            List<Panko> pankos = new List<Panko>();
            pankos.Add(new Panko(){ Name = "半/一"});
            pankos.Add(new Panko() { Name = "一球" });
            pankos.Add(new Panko() { Name = "一球/球半" });
            return pankos;
        }

    }
}
