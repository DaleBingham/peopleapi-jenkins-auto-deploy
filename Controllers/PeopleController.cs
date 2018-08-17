using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using peopleapi.Models;
using peopleapi.Data;
using Microsoft.EntityFrameworkCore;

namespace peopleapi.Controllers
{
    /// <summary>
    /// This class is the main API class that connects to a database to send back information on People.
    /// </summary>
    [Route("api/[controller]")]
    public class PeopleController : Controller
    {

        private readonly peopleAPIContext _context;

        public PeopleController(peopleAPIContext context) {
            // get the database context
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(await _context.Person.OrderBy(x => x.LastName).OrderBy(y => y.FirstName).ToListAsync());
        }

        // GET api/values/GUID-TO-PERSON
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
           return Json(await _context.Person.Where(z => z.PersonId == id).SingleOrDefaultAsync());
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Person value)
        {            
            if (value == null) {
                return BadRequest();
            }

            Person p = value;
            p.PersonId = Guid.NewGuid();
            _context.Person.Add(p);
            await _context.SaveChangesAsync();

            return CreatedAtRoute(new {id = p.PersonId}, p);
        }

        // PUT api/values/GUID-TO-PERSON
        [HttpPut]
        public async Task<IActionResult> Put(Guid id, [FromBody]Person value)
        {
            if (value.PersonId == null) {
                return BadRequest();
            }
            
            var person = await _context.Person.SingleOrDefaultAsync(x => x.PersonId == value.PersonId);
            if (person == null) {
                return NotFound();
            }
            // update the data
            person.FirstName = value.FirstName;
            person.MiddleName = value.MiddleName;
            person.LastName = value.LastName;
            person.Address = value.Address;
            person.CellPhone = value.CellPhone;
            person.City = value.City;
            person.Email = value.Email;
            person.Linkedin = value.Linkedin;
            person.State = value.State;
            person.Twitter = value.Twitter;
            person.WorkPhone = value.WorkPhone;
            person.ZipCode = value.ZipCode;
            // save the data
            _context.Person.Update(person);
            await _context.SaveChangesAsync();

            return new OkResult();
        }

        // DELETE api/values/GUID-TO-PERSON
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
             if (id == null) {
                    return BadRequest();
            }
            var p = await _context.Person.SingleOrDefaultAsync(x => x.PersonId == id);
            if (p == null) {
                return NotFound();
            }
            _context.Person.Remove(p);
            await _context.SaveChangesAsync();
            return new OkResult();
        }
    }
}
