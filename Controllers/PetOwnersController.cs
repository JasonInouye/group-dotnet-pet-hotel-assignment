using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetOwnersController(ApplicationContext context) {
            _context = context;
        }

        // get all pet owners
        [HttpGet]
        public IEnumerable<PetOwner> GetAll() {
            return _context.PetOwners;
        }
        //get pet owner by id
        [HttpGet("{id}")]
        public ActionResult<PetOwner> GetById(int id)
        {
            PetOwner petOwner = _context.PetOwners
                .SingleOrDefault(petOwner => petOwner.id == id);

            if(petOwner == null){
                return NotFound();
            }

            return petOwner;
        }
        //post new pet owner
        [HttpPost]
        public PetOwner Post(PetOwner petOwner){
            _context.Add(petOwner);
            _context.SaveChanges();

            return petOwner;
        }
    }
}
