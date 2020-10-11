using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using QuotesDemoAPI.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuotesDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        public ApplicationDbContext _db { get; set; }
        private Random _rand;
        public QuoteController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET api/<QuoteController>
        // get random quote
        [HttpGet]
        public ActionResult<Quote> Get() 
        {
            _rand = new Random();
            
            ////dát do listu a vrátit z listu?
            //var list = new List<Quote>();
            //list = _db.Quotes.ToList();
            
            int max = _db.Quotes.Count();
            int rnd = _rand.Next(1, max);
            
            return _db.Quotes.Find(rnd);
        }

        // POST api/<QuoteController>
        // insert new quote (without tags)
        [HttpPost]
        public ActionResult<Quote> Insert([FromBody] Quote value)
        {
            if (value == null)
            {
                return NotFound();
            }
            else
            {
                _db.Quotes.Add(value);
                _db.SaveChangesAsync();
                return _db.Quotes.Find(value.Id);
            }
        }

        //// GET api/<QuoteController/5>
        //// get quote with id 5
        //[HttpGet("{id}")]
        //public ActionResult<Quote> Get(int id)
        //{

        //}

        //// DELETE api/<QuoteController>/5
        //// delete quote with id 5
        //[HttpDelete("{id?}")]
        //public ActionResult<Quote> Delete(int id)
        //{

        //}

        //// POST api/<QuoteController/5/tags>
        //// link new tags with quote 5
        //[HttpPost("{id}/tags")]
        //public ActionResult<IEnumerable<Tag>> InsertTags(int id, [FromBody] IEnumerable<int> tagIds)
        //{

        //}

        //// DELETE api/<QuoteController/5/tags>
        //// unlink tags connected with quote 5
        //[HttpDelete("{id}/tags")]
        //public ActionResult<IEnumerable<Tag>> DeleteTags(int id, [FromBody] IEnumerable<int> tagIds)
        //{

        //}

        //// GET api/<QuoteController/5/tags>
        //// get linked tags with quote 5
        //[HttpGet("{id}/tags")]
        //public ActionResult<IEnumerable<Tag>> GetTags(int id)
        //{

        //}
    }
}
